namespace NFiveHtb.SDK.Client.Communications
{
	using JetBrains.Annotations;

	[PublicAPI]
	public interface ICommunicationMessage
	{
		/// <summary>
		/// Replies to the event with the specified payloads.
		/// </summary>
		/// <param name="payloads">The payloads to reply to the event with.</param>
		void Reply(params object[] payloads);
	}
}
