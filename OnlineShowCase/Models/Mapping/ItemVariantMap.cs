using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineShowCase.Models.Mapping
{
    public class ItemVariantMap : EntityTypeConfiguration<ItemVariant>
    {
        public ItemVariantMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ItemVariant");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ItemId).HasColumnName("ItemId");
            this.Property(t => t.ItemColorId).HasColumnName("ItemColorId");
            this.Property(t => t.ItemDimId).HasColumnName("ItemDimId");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.ItemVariants)
                .HasForeignKey(d => d.ItemId);
            this.HasOptional(t => t.ItemColor)
                .WithMany(t => t.ItemVariants)
                .HasForeignKey(d => d.ItemColorId);
            this.HasOptional(t => t.ItemDim)
                .WithMany(t => t.ItemVariants)
                .HasForeignKey(d => d.ItemDimId);

        }
    }
}
