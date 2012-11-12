using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caching
{
    [Serializable]
    public class Caching<TKey,TValue>
    {
        public CachingIndex Index { get; set; }

        public TValue Value { get; set; }

        public TKey Key
        {
            get
            {
                return (TKey)Index.Key;
            }
        }

        public Caching(TKey key, TValue value, int Duration)
        {
            this.Value = value;
            Index = new CachingIndex
            {
                IndexKey = key.ToString(),
                CreateDate = DateTime.Now,
                Duration = Duration,
                KeyType = key.GetType()
            };
        }
        public Caching() { }
    }
}
