using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caching
{
    [Serializable]
    public class Caching<T>
    {
        public String Key { get; set; }

        /// <summary>
        /// 过期时间(分钟,0为配置默认值)
        /// </summary>
        public int TimeOutMinutes { get; set; }

        public T Value { get; set; }

        public Caching() { }
    }
}
