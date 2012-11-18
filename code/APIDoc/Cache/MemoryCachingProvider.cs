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
        //private static Dictionary<String, CachingIndex> DicCachingIndex = new Dictionary<string, CachingIndex>();
        private ExpirationType expirationType;

        private int timeout;

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
            foreach (KeyValuePair<string, string> cfg in config)
            {
                switch (cfg.Key.ToLower())
                {
                    case "expirationtype":
                        expirationType = (ExpirationType)Convert.ToByte(cfg.Value);
                        break;
                    case "timeout":
                        timeout = Convert.ToInt32(cfg.Value);
                        break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// 获取缓存索引字典
        /// </summary>
        /// <returns></returns>
        //protected override Dictionary<String, CachingIndex> GetCachingIndexDictionary()
        //{
        //    return DicCachingIndex;
        //}

        /// <summary>
        /// 设置缓存索引字典
        /// </summary>
        /// <param name="dicCachingIndex"></param>
        /// <returns></returns>
        //protected override bool SetCachingIndexDictionary(Dictionary<string, CachingIndex> dicCachingIndex)
        //{
        //    DicCachingIndex = dicCachingIndex;
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
            if (HttpRuntime.Cache != null)
            {
                object obj = HttpRuntime.Cache[key];
                if (obj != null)
                    return (T)obj;
            }
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
            if (HttpRuntime.Cache != null)
            {
                DateTime dtAbsolute;
                TimeSpan tsSliding;

                switch (expirationType)
                {
                    case ExpirationType.Never:
                        if(caching.TimeOutMinutes == 0)
                        {
                            dtAbsolute = Cache.NoAbsoluteExpiration;
                            tsSliding = Cache.NoSlidingExpiration;
                        }

                        break;
                    case ExpirationType.Absolute:
                        dtAbsolute = DateTime.Now.AddSeconds(caching.TimeOutMinutes);
                        tsSliding = Cache.NoSlidingExpiration;
                        break;
                    case ExpirationType.Sliding:
                        dtAbsolute = Cache.NoAbsoluteExpiration;
                        tsSliding = new TimeSpan(0, 0, caching.TimeOutMinutes);
                        break;
                }


                //HttpRuntime.Cache.Add(caching.Key,caching.Value,null,dtAbsolute,tsSliding,CacheItemPriority.
               
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
        //protected override bool DeleteCachingValue<TKey>(TKey key)
        //{
        //    if (HttpRuntime.Cache != null)
        //    {
        //        HttpRuntime.Cache.Remove(key.ToString());
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        //private DateTime GetCacheSpan<T>(Caching<T> caching)
        //{
        //    DateTime span;
            
        //}
    }
}
