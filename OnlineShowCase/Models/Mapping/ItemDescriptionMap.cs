using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineShowCase.Models.Mapping
{
    public class ItemDescriptionMap : EntityTypeConfiguration<ItemDescription>
    {
        public ItemDescriptionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.SortDescription)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("ItemDescription");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SortDescription).HasColumnName("SortDescription");
            this.Property(t => t.Description1).HasColumnName("Description1");
            this.Property(t => t.Description2).HasColumnName("Description2");
            this.Property(t => t.Description3).HasColumnName("Description3");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");



        }
    }
}
