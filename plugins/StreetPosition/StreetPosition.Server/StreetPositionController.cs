namespace StreetPosition.Server
{
	using NFive.SDK.Core.Diagnostics;
    using NFive.SDK.Server.Communications;
    using NFive.SDK.Server.Controllers;
	using StreetPosition.Shared;

	/// <inheritdoc />

	public class StreetPositionController : ConfigurableController<Configuration>
	{
		private readonly ICommunicationManager _comms;
		public override string Name => "egertaia/street-position";
		
		/// <inheritdoc />
		public StreetPositionController(ILogger logger, ICommunicationManager comms, Configuration configuration) : base(logger, configuration)
		{
			_comms = comms;

			comms.Event(StreetPositionEvents.GetConfig).FromClients().OnRequest(e =>
			{
				logger.Trace($"StreetPositionController - returning config");
				e.Reply(this.Configuration);			
			});
		}        

		/// <inheritdoc />
		public override void Reload(Configuration configuration)
		{
			_comms.Event(StreetPositionEvents.GetConfig).ToClients().Emit(configuration);
		}
	}
}
