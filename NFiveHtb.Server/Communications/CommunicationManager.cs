namespace NFiveHtb.Server.Communications
{
	using NFiveHtb.SDK.Server.Communications;
	using NFiveHtb.Server.Events;


	//[Component(Lifetime = Lifetime.Singleton)]
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
