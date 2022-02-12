namespace NFiveHtb.SDK.Server
{
	using CitizenFX.Core;

	public interface IBaseScriptProxy
	{
		EventHandlerDictionary EventHandlers { get; }

		ExportDictionary Exports { get; }

		PlayerList Players { get; }
	}
}
