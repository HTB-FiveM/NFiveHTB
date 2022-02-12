namespace NFiveHtb.Server.Rpc
{
    using JetBrains.Annotations;
    using System;
	using System.Collections.Generic;

	
	public class InboundMessage
	{
		public Guid Id { get; set; }

		public int Source { get; set; }

		public string Event { get; set; }

		public List<string> Payloads { get; set; }

		public static InboundMessage From(byte[] data) => RpcPacker.Unpack(data);
	}
}
