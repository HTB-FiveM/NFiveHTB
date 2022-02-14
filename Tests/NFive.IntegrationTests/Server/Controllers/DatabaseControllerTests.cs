namespace NFive.IntegrationTests.Server.Controllers
{
    using NFive.SDK.Core.Diagnostics;
    using NFive.Server;
    using NFive.Server.Controllers;
    using NSubstitute;
    using Xunit;
    using NFive.Server.Configuration;
    using NFive.Plugins.Configuration;
    using NFive.SDK.Server.Communications;

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