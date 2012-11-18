using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APIDoc.DAL.SQLServer.Models.Mapping
{
    public class APIDocMap : EntityTypeConfiguration<DBAPIDoc>
    {
        public APIDocMap()
        {
            // Primary Key
            this.HasKey(t => t.APIDocId);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Description)
                .IsRequired();

            this.Property(t => t.RequestUrl)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.ActionTypes)
                .IsRequired()
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("APIDoc");
            this.Property(t => t.APIDocId).HasColumnName("APIDocId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.RequestUrl).HasColumnName("RequestUrl");
            this.Property(t => t.RequestType).HasColumnName("RequestType");
            this.Property(t => t.NeedAuth).HasColumnName("NeedAuth");
            this.Property(t => t.ActionTypes).HasColumnName("ActionTypes");

            // Relationships
            this.HasMany(t => t.Errors)
                .WithMany(t => t.APIDocs)
                .Map(m =>
                    {
                        m.ToTable("APIDocErrorCode");
                        m.MapLeftKey("APIDocId");
                        m.MapRightKey("ErrorCode");
                    });

            this.HasRequired(t => t.Category)
                .WithMany(t => t.APIDocs)
                .HasForeignKey(d => d.CategoryId);

        }
    }
}
