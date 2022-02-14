namespace StreetPosition.Client.Overlays
{
	using NFive.SDK.Client.Interface;
	public class StreetPositionOverlay : Overlay
	{
		public StreetPositionOverlay(IOverlayManager manager) : base(manager, "StreetPositionOverlay.html") { }

		public void Set(string htmlForOverlay)
		{
			Emit("set", htmlForOverlay);
		}

		public bool Visible { get; set; }

    }
}
