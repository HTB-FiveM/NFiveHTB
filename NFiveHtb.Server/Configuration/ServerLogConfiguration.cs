using JetBrains.Annotations;

namespace NFiveHtb.Server.Configuration
{
	[PublicAPI]
	public static class ServerLogConfiguration
	{
		public static CoreConfiguration.LogOutputConfiguration Output { get; set; }
	}
}
