namespace NFiveHtb.SDK.Server.Communications
{
	using JetBrains.Annotations;

	[PublicAPI]
	public interface ICommunicationManager
	{
		ICommunicationTarget Event(string @event);
	}
}
