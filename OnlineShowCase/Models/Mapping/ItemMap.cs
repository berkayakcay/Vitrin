using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineShowCase.Models.Mapping
{
    public class ItemMap : EntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Item");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.BrandId).HasColumnName("BrandId");
            this.Property(t => t.ItemDescriptionId).HasColumnName("ItemDescriptionId");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");

            // Relationships
            this.HasOptional(t => t.Brand)
                .WithMany(t => t.Items)
                .HasForeignKey(d => d.BrandId);
            this.HasOptional(t => t.ItemDescription)
                .WithMany(t => t.Items)
                .HasForeignKey(d => d.ItemDescriptionId);
            this.HasOptional(t => t.Category)
                .WithMany(t => t.Items)
                .HasForeignKey(d => d.CategoryId);

        }
    }
}
