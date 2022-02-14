namespace NFive.Server.Storage.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NFive.Server.Models;

    public class BootHistoryConfiguration : IEntityTypeConfiguration<BootHistory>
    {
        public void Configure(EntityTypeBuilder<BootHistory> builder)
        {
            builder.ToTable("boothistory");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.Created).IsRequired();
            builder.Property(b => b.LastActive).IsRequired();

        }
    }
}
