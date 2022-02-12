namespace NFiveHtb.SDK.Server.Events
{
    using JetBrains.Annotations;
    using NFiveHtb.SDK.Server.Communications;
    using System;

	
	public class ClientEventArgs : EventArgs
	{
		/// <summary>
		/// Gets the client.
		/// </summary>
		/// <value>
		/// The client.
		/// </value>
		public IClient Client { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ClientEventArgs" /> class.
		/// </summary>
		/// <param name="client">The client.</param>
		public ClientEventArgs(IClient client)
		{
			this.Client = client;
		}
	}
}
