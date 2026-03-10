using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplySync.Models;

namespace SupplySync.Config.Configurations
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.ContactInfo).IsRequired().HasMaxLength(255);

            builder.Property(x => x.Category).HasConversion<string>().HasMaxLength(30);
            builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(20);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");
        }
    }

    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.Property(x => x.Value).HasPrecision(18, 2);
            builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(20);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(x => x.Vendor)
                   .WithMany()
                   .HasForeignKey(x => x.VendorID)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();
        }
    }
}