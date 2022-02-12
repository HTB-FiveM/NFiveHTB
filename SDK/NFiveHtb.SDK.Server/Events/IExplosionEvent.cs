namespace NFiveHtb.SDK.Server.Events
{
	using JetBrains.Annotations;
    using NFiveHtb.SDK.Core.Models;

    
	public interface IExplosionEvent
	{
		int OwnerNetId { get; }

		int ExplosionType { get; }

		float DamageScale { get; }

		float CameraShake { get; }

		Position Position { get; }

		bool IsAudible { get; }

		bool IsInvisible { get; }

		void Cancel();
	}
}
