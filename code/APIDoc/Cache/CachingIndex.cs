using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caching
{
    [Serializable]
    public class CachingIndex
    {
        public String IndexKey { get; set; }

        public DateTime CreateDate { get; set; }

        public int Duration { get; set; }

        public DateTime ExpiredDate
        {
            get
            {
                return CreateDate.AddSeconds(Duration);
            }
        }
        public bool Expired
        {
            get
            {
                return DateTime.Now.CompareTo(ExpiredDate) > 0;
            }
        }

        public Type KeyType { get; set; }

        public Object Key
        {
            get
            {
                return Convert.ChangeType(IndexKey, KeyType);
            }
        }
    }
}
