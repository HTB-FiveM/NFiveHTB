namespace NFiveHtb.Server.Controllers
{
    using NFiveHtb.SDK.Core.Diagnostics;
    using NFiveHtb.SDK.Server.Communications;
    using NFiveHtb.SDK.Server.Configuration;
    using NFiveHtb.SDK.Server.Controllers;
    using NFiveHtb.SDK.Server.Events;
    using NFiveHtb.Server.Configuration;
    using NFiveHtb.Server.Models;
    using NFiveHtb.Server.Storage;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Migrations;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using X4D.Diagnostics;

    public class DatabaseController : ConfigurableController<DatabaseConfiguration>
	{
		private readonly BootHistory currentBoot;
		public override string Name => "NFive/Database";

		public DatabaseController(ILogger logger, DatabaseConfiguration configuration, ICommunicationManager comms) : base(logger, configuration)
		{
			// Set global database options
			ServerConfiguration.DatabaseConnection = this.Configuration.Connection.ToString();
			ServerConfiguration.AutomaticMigrations = this.Configuration.Migrations.Automatic;

			// Enable SQL query logging
			//////////MySqlTrace.Switch.Level = SourceLevels.All;
			//////////MySqlTrace.Listeners.Add(new ConsoleTraceListener()); // TODO: Not available in netstandard 2.0 - 3rd party one being used here

			BootHistory lastBoot;

			using (var context = new StorageContext())
			{
                // Create database if needed
                if (!context.Database.CanConnect())
                {
                    this.Logger.Info($"No existing database found, creating new database \"{this.Configuration.Connection.Database}\"");
                } 

				if (!context.Database.IsInMemory())
				{
					var pendingMigrations = context.Database.GetPendingMigrations();
					if (pendingMigrations.Any())
					{
						var migrator = context.Database.GetService<IMigrator>();
						foreach (var migration in pendingMigrations)
						{
							migrator.Migrate(migration);
						}
					}
				}

				lastBoot = context.BootHistory.OrderByDescending(b => b.Created).FirstOrDefault() ?? new BootHistory();

				this.currentBoot = new BootHistory();
				context.BootHistory.Add(this.currentBoot);
				context.SaveChanges();
			}

			Task.Factory.StartNew(UpdateBootHistory);

            comms.Event(BootEvents.GetTime).FromServer().On(e => e.Reply(this.currentBoot.Created));
            comms.Event(BootEvents.GetLastTime).FromServer().On(e => e.Reply(lastBoot.Created));
            comms.Event(BootEvents.GetLastActiveTime).FromServer().On(e => e.Reply(lastBoot.LastActive));
        }
		       

        private async Task UpdateBootHistory()
		{
			while (true)
			{
				try
				{
					using (var context = new StorageContext())
					using (var transaction = context.Database.BeginTransaction())
					{
						this.currentBoot.LastActive = DateTime.UtcNow;
						context.BootHistory.Update(this.currentBoot);
						await context.SaveChangesAsync();
						transaction.Commit();
					}
				}
				catch (Exception ex)
				{
					this.Logger.Error(ex);
				}
				finally
				{
					await Task.Delay(this.Configuration.BootHistory.UpdateFrequency);
				}
			}
		}
	}
}
