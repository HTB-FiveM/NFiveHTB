namespace NFive.SDK.Server
{
	using NFive.SDK.Core;
	using JetBrains.Annotations;

	
	public class ServerPluginAttribute : PluginAttribute
	{
		/// <inheritdoc />
		/// <summary>
		/// Initializes a new instance of the <see cref="ServerPluginAttribute" /> class.
		/// </summary>
		/// <param name="target">The target server SDK version number.</param>
		public ServerPluginAttribute(uint target) : base(target) { }
	}
}
