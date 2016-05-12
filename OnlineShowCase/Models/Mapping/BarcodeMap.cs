using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineShowCase.Models.Mapping
{
    public class BarcodeMap : EntityTypeConfiguration<Barcode>
    {
        public BarcodeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ItemBarcode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Barcode");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ItemVariantId).HasColumnName("ItemVariantId");
            this.Property(t => t.BarcodeTypeId).HasColumnName("BarcodeTypeId");
            this.Property(t => t.ItemBarcode).HasColumnName("ItemBarcode");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");

            // Relationships
            this.HasOptional(t => t.BarcodeType)
                .WithMany(t => t.Barcodes)
                .HasForeignKey(d => d.BarcodeTypeId);
            this.HasOptional(t => t.ItemVariant)
                .WithMany(t => t.Barcodes)
                .HasForeignKey(d => d.ItemVariantId);

        }
    }
}
