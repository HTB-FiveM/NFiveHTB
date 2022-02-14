namespace NFive.Server.Models
{
    using NFive.SDK.Core.Helpers;
    using JetBrains.Annotations;
    using System;
    using System.ComponentModel.DataAnnotations;

    
	public class BootHistory
	{
		[Key]
		[Required]
		public Guid Id { get; set; }

		[Required]
		public DateTime Created { get; set; }

		public DateTime LastActive { get; set; }

		public BootHistory()
		{
			this.Id = GuidGenerator.GenerateTimeBasedGuid();
			this.Created = DateTime.UtcNow;
			this.LastActive = DateTime.UtcNow;
		}
	}
}
