using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace Caching
{
    public class MemoryCachingProvider : CachingProviderBase
    {
        private static Dictionary<String, CachingIndex> DicCachingIndex = new Dictionary<string, CachingIndex>();

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
        }

        /// <summary>
        /// 获取缓存索引字典
        /// </summary>
        /// <returns></returns>
        protected override Dictionary<String, CachingIndex> GetCachingIndexDictionary()
        {
            return DicCachingIndex;
        }

        /// <summary>
        /// 设置缓存索引字典
        /// </summary>
        /// <param name="dicCachingIndex"></param>
        /// <returns></returns>
        protected override bool SetCachingIndexDictionary(Dictionary<string, CachingIndex> dicCachingIndex)
        {
            DicCachingIndex = dicCachingIndex;
            return true;
        }
      
        
        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override TValue GetCachingValue<TKey, TValue>(TKey key)
        {
            if (HttpRuntime.Cache != null)
            {
                return (TValue)HttpRuntime.Cache[key.ToString()];
            }
            else
                return default(TValue);
        }

        /// <summary>
        /// 设置缓存值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="caching"></param>
        protected override bool SetCachingValue<TKey, TValue>(Caching<TKey, TValue> caching)
        {
            if (HttpRuntime.Cache != null)
            {
                HttpRuntime.Cache[caching.Key.ToString()] = caching.Value;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 删除缓存值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override bool DeleteCachingValue<TKey>(TKey key)
        {
            if (HttpRuntime.Cache != null)
            {
                HttpRuntime.Cache.Remove(key.ToString());
                return true;
            }
            else
                return false;
        }
    }
}
