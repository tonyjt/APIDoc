using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APIDoc.DAL.SQLServer.Models.Mapping
{
    public class DomainMap : EntityTypeConfiguration<DBDomain>
    {
        public DomainMap()
        {
            // Primary Key
            this.HasKey(t => t.DomainId);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Description)
                .IsRequired();

            this.Property(t => t.RootUrl)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Domain");
            this.Property(t => t.DomainId).HasColumnName("DomainId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.RootUrl).HasColumnName("RootUrl");
        }
    }
}
