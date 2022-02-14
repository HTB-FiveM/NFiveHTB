namespace NFive.Server.Storage.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NFive.SDK.Core.Models.Player;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).IsRequired();
            builder.Property(u => u.Created).IsRequired();
            builder.Property(u => u.License).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Name).IsRequired().HasMaxLength(50);

            builder.HasIndex(u => u.License).IsUnique();

        }
    }
}
