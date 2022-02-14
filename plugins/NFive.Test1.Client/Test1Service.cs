namespace NFive.Test1.Client.Plugin
{
    using NFive.SDK.Client.Commands;
    using NFive.SDK.Client.Communications;
    using NFive.SDK.Client.Events;
    using NFive.SDK.Client.Interface;
    using NFive.SDK.Client.Services;
    using NFive.SDK.Core.Diagnostics;
    using NFive.SDK.Core.Models.Player;
    using System;
    using System.Threading.Tasks;

    public class Test1Service : Service
    {
        //public override string Name => "NFive/plugin-test1";

        public Test1Service(ILogger logger, ITickManager ticks, ICommunicationManager comms, ICommandManager commands, IOverlayManager overlayManager, User user) : base(logger, ticks, comms, commands, overlayManager, user)
        {
        }

        public override Task Loaded()
        {
            Logger.Info("Client plugin Test1Service LOADED");
            Console.WriteLine("Snootch");

            return Task.FromResult(0);
        }

        public override Task Started()
        {
            Logger.Info("Client plugin Test1Service STARTED");
            Console.WriteLine("To the nootch");

            return Task.FromResult(0);
        }


    }
}
