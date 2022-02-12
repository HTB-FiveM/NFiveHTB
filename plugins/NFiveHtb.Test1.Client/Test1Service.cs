namespace NFiveHtb.Test1.Client.Plugin
{
    using NFiveHtb.SDK.Client.Commands;
    using NFiveHtb.SDK.Client.Communications;
    using NFiveHtb.SDK.Client.Events;
    using NFiveHtb.SDK.Client.Interface;
    using NFiveHtb.SDK.Client.Services;
    using NFiveHtb.SDK.Core.Diagnostics;
    using NFiveHtb.SDK.Core.Models.Player;
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

            return Task.CompletedTask;
        }

        public override Task Started()
        {
            Logger.Info("Client plugin Test1Service STARTED");
            Console.WriteLine("To the nootch");

            return Task.CompletedTask;
        }


    }
}
