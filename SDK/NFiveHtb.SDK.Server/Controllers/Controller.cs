namespace NFiveHtb.SDK.Server.Controllers
{
    using CitizenFX.Core;
    using NFiveHtb.SDK.Core.Diagnostics;
    using NFiveHtb.SDK.Core.Locales;
    using NFiveHtb.SDK.Server.Configuration;
    using NFiveHtb.SDK.Server.Locales;
    using JetBrains.Annotations;
    using NGettext;
    using NGettext.Loaders;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    
    public abstract class Controller
	{
		protected static ILocaleCatalog Catalog;

		/// <summary>
		/// The message logger,
		/// </summary>
		protected readonly ILogger Logger;

		public abstract string Name { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Controller" /> class.
		/// </summary>
		/// <param name="logger">The message logger.</param>
		protected Controller(ILogger logger)
		{
			this.Logger = logger;

			Catalog = new LocaleCatalog(new Catalog(CultureInfo.InvariantCulture));

			var type = GetType();
			var catalogs = type.Assembly.GetManifestResourceNames();

			if (!catalogs.Any()) return;

			var matches = ServerConfiguration.Locale.Culture.Where(c => catalogs.Contains($"{type.Namespace}.Locales.{c.Name}.mo")).ToList();

			foreach (var culture in matches)
			{
				using (var resourceStream = type.Assembly.GetManifestResourceStream($"{type.Namespace}.Locales.{culture.Name}.mo"))
				{
					if (resourceStream == null) continue;

					try
					{
						Catalog = new LocaleCatalog(new Catalog(new MoLoader(resourceStream, new MoFileParser(Encoding.UTF8, false)), culture));

						this.Logger.Debug($"Loaded locale: {type.Namespace}.Locales.{culture.Name}.mo");

						break;
					}
					catch (Exception ex)
					{
						this.Logger.Error(ex, $"Loading plugin locale catalog \"{type.Namespace}.Locales.{culture.Name}.mo\" failed");
					}
				}
			}
		}

		public static string _(string text) => Catalog.GetString(text);

		public static string _(string text, params object[] args) => Catalog.GetString(text, args);

		public static string _n(string text, string pluralText, long n) => Catalog.GetPluralString(text, pluralText, n);

		public static string _n(string text, string pluralText, long n, params object[] args) => Catalog.GetPluralString(text, pluralText, n, args);

		public static string _p(string context, string text) => Catalog.GetParticularString(context, text);

		public static string _p(string context, string text, params object[] args) => Catalog.GetParticularString(context, text, args);

		public static string _pn(string context, string text, string pluralText, long n) => Catalog.GetParticularPluralString(context, text, pluralText, n);

		public static string _pn(string context, string text, string pluralText, long n, params object[] args) => Catalog.GetParticularPluralString(context, text, pluralText, n, args);

		public virtual Task Loaded() => Task.CompletedTask;

		public virtual Task Started() => Task.CompletedTask;

		/// <summary>
		/// Reloads this controllers configuration.
		/// </summary>
		public virtual void Reload() { }

		protected async Task Delay(int ms)
		{
			await BaseScript.Delay(ms);
		}

		protected async Task Delay(TimeSpan delay)
		{
			await BaseScript.Delay((int)delay.TotalMilliseconds);
		}
	}
}
