namespace NFiveHtb.SDK.Server.Events
{
	using JetBrains.Annotations;

	
	public static class BootEvents
	{
		/// <summary>
		/// Event which is used to request the timestamp of when the server started this boot.
		/// </summary>
		public const string GetTime = "nfive:server:boot:getTime";

		/// <summary>
		/// Event which is used to request the timestamp of when the server started last boot.
		/// </summary>
		public const string GetLastTime = "nfive:server:boot:getLastTime";

		/// <summary>
		/// Event which is used to request the timestamp of when the server shutdown last boot.
		/// </summary>
		public const string GetLastActiveTime = "nfive:server:boot:getLastActiveTime";
	}
}
