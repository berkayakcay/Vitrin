using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineShowCase.Models.Mapping
{
    public class StockMap : EntityTypeConfiguration<Stock>
    {
        public StockMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Stock");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ItemVariantId).HasColumnName("ItemVariantId");
            this.Property(t => t.In_Qty).HasColumnName("In_Qty");
            this.Property(t => t.Out_Qty).HasColumnName("Out_Qty");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");

            // Relationships
            this.HasOptional(t => t.ItemVariant)
                .WithMany(t => t.Stocks)
                .HasForeignKey(d => d.ItemVariantId);

        }
    }
}
