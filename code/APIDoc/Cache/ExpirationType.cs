using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caching
{
    public enum ExpirationType:byte
    {
        Never = 1,//永不过期

        Absolute = 2,//绝对时间

        Sliding = 3 //距最后一次访问时间
    }
}
