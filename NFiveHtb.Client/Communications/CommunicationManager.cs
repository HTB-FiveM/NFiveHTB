namespace NFiveHtb.Client.Communications
{
	using NFiveHtb.Client.Events;
	using NFiveHtb.SDK.Client.Communications;


	public class CommunicationManager : ICommunicationManager
	{
		private readonly EventManager eventManager;

		public CommunicationManager(EventManager eventManager)
		{
			this.eventManager = eventManager;
		}

		public ICommunicationTarget Event(string @event) => new CommunicationTarget(this.eventManager, @event);
	}
}
