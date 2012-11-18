using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APIDoc.DAL.SQLServer.Models.Mapping
{
    public class ResponseDemoMap : EntityTypeConfiguration<DBResponseDemo>
    {
        public ResponseDemoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.APIDocId, t.ResponseType });

            // Properties
            this.Property(t => t.Demo)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ResponseDemo");
            this.Property(t => t.APIDocId).HasColumnName("APIDocId");
            this.Property(t => t.ResponseType).HasColumnName("ResponseType");
            this.Property(t => t.Demo).HasColumnName("Demo");

            // Relationships
            this.HasRequired(t => t.APIDoc)
                .WithMany(t => t.ResponseDemoes)
                .HasForeignKey(d => d.APIDocId);

        }
    }
}
