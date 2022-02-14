namespace NFive.Server
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using CitizenFX.Core;
    using CitizenFX.Core.Native;
    using NFive.SDK.Server.Configuration;
    using NFive.SDK.Core.Diagnostics;
    using NFive.SDK.Core.Plugins;
    using NFive.Plugins;
    using NFive.Plugins.Configuration;
    using NFive.Server.Configuration;
    using NFive.Server.Diagnostics;
    using NFive.SDK.Server.Controllers;
    using NFive.SDK.Server;
    using Newtonsoft.Json;
    using NFive.SDK.Core.Controllers;
    using NFive.Server.Rpc;
    using NFive.Server.Events;
    using NFive.Server.Communications;
    using NFive.Server.Rcon;
    using NFive.Server.Controllers;
    using NFive.SDK.Server.Rcon;
    using NFive.SDK.Server.Communications;
    using NFive.SDK.Core.Events;
    using NFive.SDK.Server.Events;
    using Autofac;

    public class ServerMain : BaseScript
    {
        private readonly Dictionary<Name, List<Controller>> _controllers = new Dictionary<Name, List<Controller>>();


        public ServerMain()
        {
            Startup();    

        }

        private async void Startup()
        {
            Debug.WriteLine("Server running the Startup process");

            // Set the AppDomain working directory to the current resource root
            Environment.CurrentDirectory = Path.GetFullPath(API.GetResourcePath(API.GetCurrentResourceName()));

            new Logger().Info($"NFiveHtb {typeof(ServerMain).Assembly.GetCustomAttributes<AssemblyInformationalVersionAttribute>().First().InformationalVersion}");

            var config = ConfigurationManager.Load<CoreConfiguration>("core.yml");

            // Use configured culture for output
            Thread.CurrentThread.CurrentCulture = config.Locale.Culture.First();
            CultureInfo.DefaultThreadCurrentCulture = config.Locale.Culture.First();

            ServerConfiguration.Locale = config.Locale;
            ServerLogConfiguration.Output = config.Log.Output;

            var logger = new Logger(config.Log.Core);

            API.SetGameType(config.Display.Game);
            API.SetMapName(config.Display.Map);


            // Setup RPC handlers
            RpcManager.Configure(config.Log.Comms, this.EventHandlers, this.Players);

            // IoC
            var builder = new ContainerBuilder();
            builder.Register(_ => new Logger(config.Log.Core)).As<ILogger>();

            // Register base ControllerConfigurations
            builder.RegisterInstance<CoreConfiguration>(config);

            builder.Register<DatabaseConfiguration>(
                _ => ConfigurationManager.Load<DatabaseConfiguration>("database.yml")
            ).SingleInstance();

            builder.Register<SessionConfiguration>(
                _ => ConfigurationManager.Load<SessionConfiguration>("session.yml")
            ).SingleInstance();

            builder.Register(ctx =>
            {
                var commsInstance = ctx.Resolve<ICommunicationManager>();
                var rconInstance = new RconManager(commsInstance);
                return rconInstance;
            }).As<IRconManager>().SingleInstance();

            builder.Register(_ =>
                new BaseScriptProxy(this.EventHandlers, this.Exports, this.Players)
            ).As<IBaseScriptProxy>();

            builder.Register(ctx =>
            {
                var coreConfig = ctx.Resolve<CoreConfiguration>();
                var events = new EventManager(coreConfig.Log.Comms);
                var commsInstance = new CommunicationManager(events);
                return commsInstance;
            }).As<ICommunicationManager>().SingleInstance();

            builder.Register(ctx =>
            {
                var commsInstance = ctx.Resolve<ICommunicationManager>();
                var clientListInstance = new ClientList(new Logger(config.Log.Core, "ClientList"), commsInstance);
                return clientListInstance;
            }).As<IClientList>().SingleInstance();
            

            // Find all plugins
            var pluginDefaultLogLevel = config.Log.Plugins.ContainsKey("default") ? config.Log.Plugins["default"] : LogLevel.Info;
            var graph = DefinitionGraph.Load();

            LoadPlugins(logger, graph, builder);

            // Scan all loaded assemblies for Controllers to be registered in IoC
            var controllersForRegistration = new List<Type>(
                FindControllerTypes(logger)
            );
            foreach (var ctrlType in controllersForRegistration)
            {
                builder.RegisterType(ctrlType).As<Controller>();
            }

             var container = builder.Build();

            // Get Instances to all the Controllers and ConfigurableControllers
            var controllerInstances = container.Resolve<IEnumerable<Controller>>();
            foreach (var controller in controllerInstances)
            {
                logger.Trace($"Controller Instance Created - {controller.Name}");
                _controllers.Add(controller.Name, new List<Controller> { controller });
                await controller.Loaded();
            }


            await Task.WhenAll(_controllers.SelectMany(c => c.Value).Select(s => s.Started()));

            var rcon = container.Resolve<IRconManager>();
            rcon.Controllers = _controllers;

            var comms = container.Resolve<ICommunicationManager>();
            comms.Event(CoreEvents.ClientPlugins).FromClients().OnRequest(e => e.Reply(graph.Plugins));

            logger.Info($"{graph.Plugins.Count.ToString(CultureInfo.InvariantCulture)} plugin(s) loaded, {_controllers.Count.ToString(CultureInfo.InvariantCulture)} controller(s) created");

            comms.Event(ServerEvents.ServerInitialized).ToServer().Emit();

            logger.Info("NFiveHtb Server Ready");



        }

        private static List<Type> FindControllerTypes(Logger logger)
        {
            var ret = new List<Type>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Distinct())
            {
                var types = assembly.GetTypes().Where(t => !t.IsAbstract && t.IsClass).ToList();
                var controllers = types.Where(t => t.IsSubclassOf(typeof(Controller)));

                ret.AddRange(controllers);

            }

            return ret;
        }

        private static void LoadPlugins(Logger logger, DefinitionGraph graph, ContainerBuilder builder)
        {
            foreach (var plugin in graph.Plugins)
            {
                logger.Info($"Loading {plugin.FullName}");

                // Load include files
                Assembly asmInc = null;
                foreach (var includeName in plugin.Server?.Include ?? new List<string>())
                {
                    var includeFile = Path.Combine("plugins", plugin.Name.Vendor, plugin.Name.Project, $"{includeName}.net.dll");
                    if (!File.Exists(includeFile)) throw new FileNotFoundException(includeFile);

                    AppDomain.CurrentDomain.Load(File.ReadAllBytes(includeFile));
                    asmInc = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName.Contains($"{includeName}.net"));
                }

                // Load all the plugin dlls
                foreach (var mainName in plugin.Server?.Main ?? new List<string>())
                {
                    var mainFile = Path.Combine("plugins", plugin.Name.Vendor, plugin.Name.Project, $"{mainName}.net.dll");
                    logger.Info(mainFile);
                    if (!File.Exists(mainFile)) throw new FileNotFoundException(mainFile);

                    var asm = Assembly.LoadFrom(mainFile);
                    if(asm == null)
                    {
                        throw new Exception($"Unable to load the SDK plugin assembly: '{mainFile}'");
                    }

                    var sdkVersion = asm.GetCustomAttribute<ServerPluginAttribute>();
                    if (sdkVersion == null)
                    {
                        throw new Exception($"Unable to determine the SDK plugin version: '{mainName}'");
                    }

                    if (sdkVersion.Target != SDK.Version)
                    {
                        throw new Exception($"Unable to load outdated SDK plugin: '{mainName}'");
                    }

                    // Register the ControllerConfiguration class for the controller
                    var types = asm.GetTypes()
                        .Where(t => !t.IsAbstract && t.IsClass)
                        .ToList();
                    if(asmInc != null)
                        types.AddRange(asmInc.GetTypes()
                            .Where(t => !t.IsAbstract && t.IsClass)
                            .ToList());

                    var configInterface = typeof(IControllerConfiguration);
                    var cfgTypes = types.Where(t => configInterface.IsAssignableFrom(t)).ToList();

                    foreach (var cfgType in cfgTypes)
                    {
                        var cfg = (ControllerConfiguration)Activator.CreateInstance(cfgType);

                        // Get the actual subclass type for registration
                        var theType = cfg.GetType();

                        // Create an instance of the configuration writing out a new file if it doesn't already exist
                        var pluginConfig = ConfigurationManager.InitializeConfig(plugin.Name, theType);

                        // Register the configuration so it can be injected into the controller
                        builder.RegisterInstance(pluginConfig).As(theType);

                    }

                }

            }

        }




        // Delegate method
        //private async void OnPlayerConnecting([FromSource] Player player, string playerName, dynamic setKickReason, dynamic deferrals)
        //{
        //    deferrals.defer();

        //    // mandatory wait!
        //    await Delay(0);

        //    var licenseIdentifier = player.Identifiers["license"];

        //    Debug.WriteLine($"A player with the name {playerName} (Identifier: [{licenseIdentifier}]) is connecting to the server.");

        //    deferrals.update($"Hello {playerName}, your license [{licenseIdentifier}] is being checked");

        //    // Checking ban list
        //    // - assuming you have a function called IsBanned of type Task<bool>
        //    // - normally you'd do a database query here, which might take some time
        //    if (await IsBanned(licenseIdentifier))
        //    {
        //        deferrals.done($"You have been kicked (Reason: [Banned])! Please contact the server administration (Identifier: [{licenseIdentifier}]).");
        //    }

        //    deferrals.done();
        //}


    }
}
