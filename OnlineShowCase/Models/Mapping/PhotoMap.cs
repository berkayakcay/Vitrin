using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineShowCase.Models.Mapping
{
    public class PhotoMap : EntityTypeConfiguration<Photo>
    {
        public PhotoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.PhotoPath_S)
                .HasMaxLength(250);

            this.Property(t => t.PhotoPath_M)
                .HasMaxLength(250);

            this.Property(t => t.PhotoPath_B)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Photo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ItemId).HasColumnName("ItemId");
            this.Property(t => t.PhotoPath_S).HasColumnName("PhotoPath_S");
            this.Property(t => t.PhotoPath_M).HasColumnName("PhotoPath_M");
            this.Property(t => t.PhotoPath_B).HasColumnName("PhotoPath_B");
            this.Property(t => t.IsDefault).HasColumnName("IsDefault");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.Photos)
                .HasForeignKey(d => d.ItemId);

        }
    }
}
