namespace NFive.Test1.Server.Plugin
{
    using NFive.SDK.Core.Controllers;
    using NFive.SDK.Core.Diagnostics;
    using NFive.SDK.Server.Communications;
    using NFive.SDK.Server.Controllers;
    using NFive.SDK.Server.Events;
    using NFive.SDK.Server.Rcon;
    using NFive.Server.Events;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using static CitizenFX.Core.Native.API;

    public class Test1Controller : ConfigurableController<Test1Configuration>
    {

        public Test1Controller(ILogger logger, Test1Configuration config, ICommunicationManager comms) : base(logger, config)
        {
            comms.Event(ServerEvents.PlayerConnecting).FromServer().On<IClient, ConnectionDeferrals>(OnPlayerConnecting);

        }

        private void OnPlayerConnecting(ICommunicationMessage e, IClient client, ConnectionDeferrals deferrals)
        {
            Logger.Debug($"=== Connecting - Name: {client.Name}, Steam: {client.SteamId}, License: {client.License}");
        }

        public override string Name => "NFive/plugin-test1";

        public override Task Started()
        {
            Logger.Debug("Test1Controller Started === Snootch to the nootch!!");

            
            RegisterCommand("boo", new Action<int, List<object>, string>((source, args, raw) =>
            {
                Logger.Info("Well hello there govna!!");
            }), false);


            return Task.CompletedTask;
        }

    }

    public class Test1Configuration : ControllerConfiguration
    {
        public override string FileName => "test1";

        public string Nootch { get; set; } = "Hooby dooby!!!";
        public string Message { get; set; }


    }

}
