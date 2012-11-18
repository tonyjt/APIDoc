using System;
using System.Collections.Generic;

namespace APIDoc.DAL.SQLServer.Models
{
    public class DBParameter
    {
        public System.Guid APIDocId { get; set; }
        public byte Type { get; set; }
        public string Key { get; set; }
        public string ParameterType { get; set; }
        public string Description { get; set; }
        public bool Indispensable { get; set; }
        public virtual DBAPIDoc APIDoc { get; set; }
    }
}
