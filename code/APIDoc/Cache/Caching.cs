using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caching
{
    public class Caching<TKey,TValue>
    {
        public CachingIndex Index { get; set; }

        public TValue Value { get; set; }

        public TKey Key
        {
            get;
            set;
        }
    }
}
