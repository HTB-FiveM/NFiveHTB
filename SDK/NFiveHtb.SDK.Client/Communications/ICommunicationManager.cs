namespace NFiveHtb.SDK.Client.Communications
{
	using JetBrains.Annotations;

	
	public interface ICommunicationManager
	{
		ICommunicationTarget Event(string @event);
	}
}
