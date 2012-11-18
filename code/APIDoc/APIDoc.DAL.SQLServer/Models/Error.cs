using System;
using System.Collections.Generic;

namespace APIDoc.DAL.SQLServer.Models
{
    public class DBError
    {
        public DBError()
        {
            this.APIDocs = new List<DBAPIDoc>();
        }

        public int ErrorCode { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public System.Guid DomainId { get; set; }
        public virtual ICollection<DBAPIDoc> APIDocs { get; set; }
    }
}
