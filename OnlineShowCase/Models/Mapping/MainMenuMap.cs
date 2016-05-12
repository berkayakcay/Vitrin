using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineShowCase.Models.Mapping
{
    public class MainMenuMap : EntityTypeConfiguration<MainMenu>
    {
        public MainMenuMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(250);

            this.Property(t => t.Description)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("MainMenu");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SubMenuId).HasColumnName("SubMenuId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Link).HasColumnName("Link");
            this.Property(t => t.ForAdmin).HasColumnName("ForAdmin");
            this.Property(t => t.ForMod).HasColumnName("ForMod");
            this.Property(t => t.ForUser).HasColumnName("ForUser");

            // Relationships
            this.HasOptional(t => t.MainMenu2)
                .WithMany(t => t.MainMenu1)
                .HasForeignKey(d => d.SubMenuId);
        }
    }
}
