namespace NFiveHtb.SDK.Server.Rcon
{
	using System;
	using System.Collections.Generic;
	using JetBrains.Annotations;
    using NFiveHtb.SDK.Core.Plugins;
    using NFiveHtb.SDK.Server.Controllers;

    
	public interface IRconManager
	{
		void Register(string command, Action callback);

		void Register(string command, Action<string> callback);

		void Register(string command, Action<IEnumerable<string>> callback);

		Dictionary<Name, List<Controller>> Controllers { get; set; }

	}
}
