namespace NFiveHtb.SDK.Server.Events
{
	using JetBrains.Annotations;

	[PublicAPI]
	public interface IConnectionDeferrals
	{
		string Message { set; }

		void Defer();

		void ShowCard(string json);

		void Allow();

		void Reject(string message);
	}
}
