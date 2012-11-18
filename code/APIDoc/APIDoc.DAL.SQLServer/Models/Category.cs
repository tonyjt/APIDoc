using System;
using System.Collections.Generic;

namespace APIDoc.DAL.SQLServer.Models
{
    public class DBCategory
    {
        public DBCategory()
        {
            this.APIDocs = new List<DBAPIDoc>();
        }

        public System.Guid CategoryId { get; set; }
        public string Title { get; set; }
        public Nullable<System.Guid> ParentId { get; set; }
        public System.Guid DomainId { get; set; }
        public virtual ICollection<DBAPIDoc> APIDocs { get; set; }
        public virtual DBDomain Domain { get; set; }
    }
}
