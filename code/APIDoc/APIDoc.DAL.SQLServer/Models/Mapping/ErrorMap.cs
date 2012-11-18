using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APIDoc.DAL.SQLServer.Models.Mapping
{
    public class ErrorMap : EntityTypeConfiguration<DBError>
    {
        public ErrorMap()
        {
            // Primary Key
            this.HasKey(t => t.ErrorCode);

            // Properties
            this.Property(t => t.ErrorCode)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Description)
                .IsRequired();

            this.Property(t => t.Message)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Error");
            this.Property(t => t.ErrorCode).HasColumnName("ErrorCode");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.DomainId).HasColumnName("DomainId");
        }
    }
}
