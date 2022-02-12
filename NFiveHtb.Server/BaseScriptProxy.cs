namespace NFiveHtb.Server
{
    using CitizenFX.Core;
    using NFiveHtb.SDK.Server;

	internal class BaseScriptProxy : IBaseScriptProxy
	{
		public EventHandlerDictionary EventHandlers { get; }

		public ExportDictionary Exports { get; }

		public PlayerList Players { get; }

		public BaseScriptProxy(EventHandlerDictionary eventHandlers, ExportDictionary exports, PlayerList players)
		{
			this.EventHandlers = eventHandlers;
			this.Exports = exports;
			this.Players = players;
		}
	}
}
