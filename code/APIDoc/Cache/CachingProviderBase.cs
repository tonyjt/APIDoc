using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;

namespace Caching
{
    public abstract class CachingProviderBase: ProviderBase
    {
        /// <summary>
        /// 获取缓存索引字典
        /// </summary>
        /// <returns></returns>
        public abstract Dictionary<String, CachingIndex> GetCachingIndexDictionary();
        /// <summary>
        /// 设置缓存索引字典
        /// </summary>
        /// <param name="dicCachingIndex"></param>
        /// <returns></returns>
        public abstract bool SetCachingIndexDictionary(Dictionary<String, CachingIndex> dicCachingIndex);
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public Caching<TKey, TValue> GetCaching<TKey,TValue>(TKey key)
        {
            Caching<TKey,TValue> caching = new Caching<TKey,TValue>();

            caching.Index = GetCachingIndex(key.ToString());
            caching.Value = GetCachingValue<TKey,TValue>(key);
            return caching;
        }
        /// <summary>
        /// 获取缓存索引
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        private CachingIndex GetCachingIndex(String key)
        {
            Dictionary<String, CachingIndex> dicCachingIdnex = GetCachingIndexDictionary();
            if (dicCachingIdnex == null) return null;
            return dicCachingIdnex[key];
        }

        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public abstract TValue GetCachingValue<TKey, TValue>(TKey key);

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="caching"></param>
        public bool SetCaching<TKey, TValue>(Caching<TKey, TValue> caching)
        {
            bool result = false;
            if (SetCachingIndex(caching.Index))
            {
                if (!SetCachingValue<TKey, TValue>(caching))
                {
                    DeleteCachingValue(caching.Key);
                }
                else
                    result = true;
            }
            return result;
        }

        /// <summary>
        /// 设置缓存索引
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="cachingIndex"></param>
        private bool SetCachingIndex(CachingIndex cachingIndex)
        {
            Dictionary<String, CachingIndex> dicCachingIdnex = GetCachingIndexDictionary();
            if (dicCachingIdnex == null) return false;
            dicCachingIdnex[cachingIndex.Key] = cachingIndex;

            return SetCachingIndexDictionary(dicCachingIdnex);
        }

        /// <summary>
        /// 设置缓存值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="caching"></param>
        public abstract bool SetCachingValue<TKey, TValue>(Caching<TKey, TValue> caching);

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DeleteCaching<TKey>(TKey key)
        {
            bool result = false;

            CachingIndex index = GetCachingIndex(key.ToString());

            if (DeleteCachingValue<TKey>(key))
            {
                if (!DeleteCachingIndex(key.ToString()))
                {
                    SetCachingIndex(index);
                }
                else
                    result = true;
            }
            return result;
        }
        /// <summary>
        /// 删除缓存索引
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool DeleteCachingIndex(String key)
        {
            Dictionary<String, CachingIndex> dicCachingIdnex = GetCachingIndexDictionary();
            if (dicCachingIdnex == null) return false;
            dicCachingIdnex.Remove(key);
            return SetCachingIndexDictionary(dicCachingIdnex);
        }
        /// <summary>
        /// 删除缓存值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public abstract bool DeleteCachingValue<TKey>(TKey key);


        public bool DeleteExpiredCachings()
        {
            Dictionary<String, CachingIndex> dicCachingIdnex = GetCachingIndexDictionary();

            if(dicCachingIdnex == null) return false;

            for(int i =0;i<dicCachingIdnex.Count;)
            {
                KeyValuePair<String, CachingIndex> caIndex = dicCachingIdnex.ElementAt(i);

                if (caIndex.Value.Expired)
                {
                    dicCachingIdnex.Remove(caIndex.Key);
                }
                else
                    i++;
            }
            return SetCachingIndexDictionary(dicCachingIdnex);
        }
    }
}
