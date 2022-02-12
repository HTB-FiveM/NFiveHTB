namespace NFiveHtb.SDK.Server.Configuration
{
    using NFiveHtb.SDK.Core.Configuration;
    using NFiveHtb.SDK.Core.Diagnostics;
    using JetBrains.Annotations;

    
	public static class ServerConfiguration
	{
		/// <summary>
		/// Gets or sets the default log level.
		/// </summary>
		/// <value>
		/// The default log level.
		/// </value>
		public static LogLevel LogLevel { get; set; } = LogLevel.Debug;

		/// <summary>
		/// Gets or sets the database connection string.
		/// </summary>
		/// <value>
		/// The database connection string.
		/// </value>
		public static string DatabaseConnection { get; set; } = "Host=localhost";

		/// <summary>
		/// Gets or sets a value indicating whether automatic database migrations are enabled.
		/// </summary>
		/// <value>
		/// <c>true</c> if automatic database migrations are enabled; otherwise, <c>false</c>.
		/// </value>
		public static bool AutomaticMigrations { get; set; }

		public static LocaleConfiguration Locale { get; set; } = new LocaleConfiguration();
	}
}
