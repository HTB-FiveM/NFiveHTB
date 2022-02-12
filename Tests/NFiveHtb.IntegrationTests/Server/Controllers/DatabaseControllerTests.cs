namespace NFiveHtb.IntegrationTests.Server.Controllers
{
    using NFiveHtb.SDK.Core.Diagnostics;
    using NFiveHtb.Server;
    using NFiveHtb.Server.Controllers;
    using NSubstitute;
    using Xunit;
    using NFiveHtb.Server.Configuration;
    using NFiveHtb.Plugins.Configuration;
    using NFiveHtb.SDK.Server.Communications;

    public class DatabaseControllerTests
    {
        [Fact]
        public void Test1()
        {
            var logger = Substitute.For<ILogger>();
            var comms = Substitute.For<ICommunicationManager>();

            //var sut = new DatabaseController(
            //    logger,
            //    ConfigurationManager.Load<DatabaseConfiguration>("database.yml"),
            //    comms);



        }
    }
}