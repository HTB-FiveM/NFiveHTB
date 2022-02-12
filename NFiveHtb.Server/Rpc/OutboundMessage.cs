namespace NFiveHtb.Server.Rpc
{
    using NFiveHtb.SDK.Server.Communications;
    using JetBrains.Annotations;
    using Newtonsoft.Json;
    using System;
	using System.Collections.Generic;

	
	public class OutboundMessage
	{
		public Guid Id { get; set; }

		[JsonIgnore]
		public IClient Target { get; set; }

		public string Event { get; set; }

		public List<string> Payloads { get; set; } = new List<string>();

		public byte[] Pack() => RpcPacker.Pack(this);
	}
}
