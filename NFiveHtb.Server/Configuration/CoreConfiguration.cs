namespace NFiveHtb.Server.Configuration
{
    using NFiveHtb.SDK.Core.Configuration;
    using NFiveHtb.SDK.Core.Controllers;
    using NFiveHtb.SDK.Core.Diagnostics;
    using JetBrains.Annotations;
    using System.Collections.Generic;
    using System.Globalization;
    using TimeZoneConverter;

    
    public class CoreConfiguration : ControllerConfiguration
	{
		public override string FileName => "core";

		public DisplayConfiguration Display { get; set; } = new DisplayConfiguration();

		public LocaleConfiguration Locale { get; set; } = new LocaleConfiguration
		{
			Culture = new List<CultureInfo>
			{
				new CultureInfo("en-US")
			},
			TimeZone = TZConvert.GetTimeZoneInfo("Pacific Standard Time")
		};

		public LogConfiguration Log { get; set; } = new LogConfiguration();

		
		public class DisplayConfiguration
		{
			public string Name { get; set; } = "NFive";

			public string Game { get; set; } = "Custom";

			public string Map { get; set; } = "Los Santos";
		}

		
		public class LogConfiguration
		{
			public LogOutputConfiguration Output { get; set; } = new LogOutputConfiguration();

			public LogLevel Core { get; set; } = LogLevel.Info;

			public LogLevel Comms { get; set; } = LogLevel.Info;

			public Dictionary<string, LogLevel> Plugins { get; set; } = new Dictionary<string, LogLevel>
			{
				{ "default", LogLevel.Info }
			};
		}

		
		public class LogOutputConfiguration
		{
			public LogLevel ClientConsole { get; set; } = LogLevel.Warn;

			public LogLevel ClientMirror { get; set; } = LogLevel.Warn;

			public LogLevel ServerConsole { get; set; } = LogLevel.Warn;
		}
	}
}
