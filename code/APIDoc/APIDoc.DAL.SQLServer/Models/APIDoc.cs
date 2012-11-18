using System;
using System.Collections.Generic;

namespace APIDoc.DAL.SQLServer.Models
{
    public class DBAPIDoc
    {
        public DBAPIDoc()
        {
            this.Parameters = new List<DBParameter>();
            this.ResponseDemoes = new List<DBResponseDemo>();
            this.Errors = new List<DBError>();
        }

        public System.Guid APIDocId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.Guid CategoryId { get; set; }
        public string RequestUrl { get; set; }
        public byte RequestType { get; set; }
        public bool NeedAuth { get; set; }
        public string ActionTypes { get; set; }
        public virtual DBCategory Category { get; set; }
        public virtual ICollection<DBParameter> Parameters { get; set; }
        public virtual ICollection<DBResponseDemo> ResponseDemoes { get; set; }
        public virtual ICollection<DBError> Errors { get; set; }
    }
}
