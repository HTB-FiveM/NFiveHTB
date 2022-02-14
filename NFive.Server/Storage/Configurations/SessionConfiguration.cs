namespace NFive.Server.Storage.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NFive.SDK.Core.Models.Player;

    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("sessions");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.IpAddress).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Created).IsRequired();
            builder.Property(s => s.DisconnectReason).HasMaxLength(1000);

            builder.HasOne(s => s.User)
                .WithMany(u => u.Sessions)
                .HasForeignKey(s => s.UserId);

        }
    }
}
