using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineShowCase.Models.Mapping
{
    public class PriceMap : EntityTypeConfiguration<Price>
    {
        public PriceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Price");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PriceTypeId).HasColumnName("PriceTypeId");
            this.Property(t => t.ItemId).HasColumnName("ItemId");
            this.Property(t => t.ItemPrice).HasColumnName("Price");
            this.Property(t => t.VatRate).HasColumnName("VatRate");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.Prices)
                .HasForeignKey(d => d.ItemId);
            this.HasOptional(t => t.PriceType)
                .WithMany(t => t.Prices)
                .HasForeignKey(d => d.PriceTypeId);

        }
    }
}
