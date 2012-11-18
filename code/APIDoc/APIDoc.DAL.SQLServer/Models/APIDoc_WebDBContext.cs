using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using APIDoc.DAL.SQLServer.Models.Mapping;

namespace APIDoc.DAL.SQLServer.Models
{
    public class APIDoc_WebDBContext : DbContext
    {
        static APIDoc_WebDBContext()
        {
            Database.SetInitializer<APIDoc_WebDBContext>(null);
        }

		public APIDoc_WebDBContext()
			: base("Name=APIDoc_WebDBContext")
		{
		}

        public DbSet<DBC__RefactorLog> C__RefactorLog { get; set; }
        public DbSet<DBAPIDoc> APIDocs { get; set; }
        public DbSet<DBCategory> Categories { get; set; }
        public DbSet<DBDomain> Domains { get; set; }
        public DbSet<DBError> Errors { get; set; }
        public DbSet<DBParameter> Parameters { get; set; }
        public DbSet<DBResponseDemo> ResponseDemoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new C__RefactorLogMap());
            modelBuilder.Configurations.Add(new APIDocMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new DomainMap());
            modelBuilder.Configurations.Add(new ErrorMap());
            modelBuilder.Configurations.Add(new ParameterMap());
            modelBuilder.Configurations.Add(new ResponseDemoMap());
        }
    }
}
