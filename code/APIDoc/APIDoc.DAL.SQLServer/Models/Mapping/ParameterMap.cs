using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APIDoc.DAL.SQLServer.Models.Mapping
{
    public class ParameterMap : EntityTypeConfiguration<DBParameter>
    {
        public ParameterMap()
        {
            // Primary Key
            this.HasKey(t => new { t.APIDocId, t.Type, t.Key });

            // Properties
            this.Property(t => t.Key)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ParameterType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Description)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Parameter");
            this.Property(t => t.APIDocId).HasColumnName("APIDocId");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Key).HasColumnName("Key");
            this.Property(t => t.ParameterType).HasColumnName("ParameterType");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Indispensable).HasColumnName("Indispensable");

            // Relationships
            this.HasRequired(t => t.APIDoc)
                .WithMany(t => t.Parameters)
                .HasForeignKey(d => d.APIDocId);

        }
    }
}
