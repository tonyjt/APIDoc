using System;
using System.Collections.Generic;

namespace APIDoc.DAL.SQLServer.Models
{
    public class DBResponseDemo
    {
        public System.Guid APIDocId { get; set; }
        public byte ResponseType { get; set; }
        public string Demo { get; set; }
        public virtual DBAPIDoc APIDoc { get; set; }
    }
}
