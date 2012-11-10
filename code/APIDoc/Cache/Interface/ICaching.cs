using System;
using System.Text;
using System.Collections.Generic;

namespace Caching
{
    interface ICaching
    {
        public T GetObject<T>(string key);

        public void SetObject<T>(string key, T value);
    }
}
