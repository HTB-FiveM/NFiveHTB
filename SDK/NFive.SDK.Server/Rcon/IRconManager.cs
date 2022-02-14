namespace NFive.SDK.Server.Rcon
{
	using System;
	using System.Collections.Generic;
	using JetBrains.Annotations;
    using NFive.SDK.Core.Plugins;
    using NFive.SDK.Server.Controllers;

    
	public interface IRconManager
	{
		void Register(string command, Action callback);

		void Register(string command, Action<string> callback);

		void Register(string command, Action<IEnumerable<string>> callback);

		Dictionary<Name, List<Controller>> Controllers { get; set; }

	}
}
