namespace NFiveHtb.SDK.Client.Interface
{
	using System;

	public class OverlayEventArgs : EventArgs
	{
		public Overlay Overlay { get; protected set; }

		public OverlayEventArgs(Overlay overlay)
		{
			this.Overlay = overlay;
		}
	}
}
