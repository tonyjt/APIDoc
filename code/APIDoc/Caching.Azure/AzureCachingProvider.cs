using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationServer.Caching;

namespace Caching.Azure
{
    public class AzureCachingProvider : CachingProviderBase
    {
        //private string indexKey = "Caching.Azure.IndexKey";

        private string cacheKey = "Caching.Azure.CacheKey";

        private DataCache cache;
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);

            foreach (KeyValuePair<string,string> cfg in config)
            {
                switch (cfg.Key.ToLower())
                {
                    case "cachekey":
                        cacheKey = cfg.Value;
                        break;
                    default: break;
                }
            }
            CustomInit();
        }

        private void CustomInit()
        {
            DataCacheFactory cacheFactory = new DataCacheFactory();
            cache = cacheFactory.GetCache(cacheKey);
        }
        /// <summary>
        /// 获取缓存索引字典
        /// </summary>
        /// <returns></returns>
        //protected override Dictionary<String, CachingIndex> GetCachingIndexDictionary()
        //{
        //    Dictionary<String, CachingIndex> dicIndex;

        //    object objIndex = cache.Get(indexKey);

        //    if (objIndex == null)
        //    {
        //        Dictionary<String, CachingIndex> index = new Dictionary<string, CachingIndex>();

        //        if (SetCachingIndexDictionary(index))
        //        {
        //            objIndex = cache.Get(indexKey);
        //        }
        //        else
        //            objIndex = (object)index;
        //    }

        //    dicIndex = (Dictionary<String, CachingIndex>)objIndex;

        //    return dicIndex;
        //}

        /// <summary>
        /// 设置缓存索引字典
        /// </summary>
        /// <param name="dicCachingIndex"></param>
        /// <returns></returns>
        //protected override bool SetCachingIndexDictionary(Dictionary<string, CachingIndex> dicCachingIndex)
        //{
        //    cache.Put(indexKey, dicCachingIndex);

        //    return true;
        //}


        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override T GetCachingValue<T>(String key)
        {
            object obj = cache.Get(key);

            if (obj == null)
            {
                return (T)obj;
            }
            else
                return default(T);
        }

        /// <summary>
        /// 设置缓存值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="caching"></param>
        protected override bool SetCachingValue<T>(Caching<T> caching)
        {
            if (caching.TimeOutMinutes > 0)
            {
                cache.Put(caching.Key.ToString(), caching.Value, TimeSpan.FromMinutes(caching.TimeOutMinutes));
            }
            else
                cache.Put(caching.Key.ToString(), caching.Value);
            return true;
        }

    
    }
}
