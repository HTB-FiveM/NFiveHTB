﻿
namespace NFive.SDK.Client
{
	using JetBrains.Annotations;
    using NFive.SDK.Core;

    /// <inheritdoc />
    /// <summary>
    /// Specifies the client SDK version number the assembly was built against.
    /// </summary>
    
	public class ClientPluginAttribute : PluginAttribute
	{
		/// <inheritdoc />
		/// <summary>
		/// Initializes a new instance of the <see cref="ClientPluginAttribute" /> class.
		/// </summary>
		/// <param name="target">The target client SDK version number.</param>
		public ClientPluginAttribute(uint target) : base(target) { }
	}
}