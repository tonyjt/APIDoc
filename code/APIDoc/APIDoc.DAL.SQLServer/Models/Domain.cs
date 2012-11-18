using System;
using System.Collections.Generic;

namespace APIDoc.DAL.SQLServer.Models
{
    public class DBDomain
    {
        public DBDomain()
        {
            this.Categories = new List<DBCategory>();
        }

        public System.Guid DomainId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RootUrl { get; set; }
        public virtual ICollection<DBCategory> Categories { get; set; }
    }
}
