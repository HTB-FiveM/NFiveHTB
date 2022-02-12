namespace NFiveHtb.SDK.Client.Communications
{
	using JetBrains.Annotations;

	[PublicAPI]
	public interface ICommunicationManager
	{
		ICommunicationTarget Event(string @event);
	}
}
