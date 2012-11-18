using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APIDoc.DAL.SQLServer.Models.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<DBCategory>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryId);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Category");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.DomainId).HasColumnName("DomainId");

            // Relationships
            this.HasRequired(t => t.Domain)
                .WithMany(t => t.Categories)
                .HasForeignKey(d => d.DomainId);

        }
    }
}
