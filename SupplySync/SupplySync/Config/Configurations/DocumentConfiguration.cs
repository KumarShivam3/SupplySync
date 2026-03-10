using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplySync.Models;

namespace SupplySync.Config.Configurations
{
    public class VendorDocumentConfiguration : IEntityTypeConfiguration<VendorDocument>
    {
        public void Configure(EntityTypeBuilder<VendorDocument> builder)
        {
            builder.Property(x => x.DocType).HasConversion<string>().HasMaxLength(30);
            builder.Property(x => x.VerificationStatus).HasConversion<string>().HasMaxLength(20);

            builder.Property(x => x.FileURI).IsRequired();

            builder.Property(x => x.UploadedDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(x => x.Vendor)
                   .WithMany()
                   .HasForeignKey(x => x.VendorID)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();
        }
    }

    public class ContractTermConfiguration : IEntityTypeConfiguration<ContractTerm>
    {
        public void Configure(EntityTypeBuilder<ContractTerm> builder)
        {
            builder.Property(x => x.Description).IsRequired();

            builder.Property(x => x.ComplianceFlag).HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(x => x.Contract)
                   .WithMany()
                   .HasForeignKey(x => x.ContractID)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();
        }
    }
}