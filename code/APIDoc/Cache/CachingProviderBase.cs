using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;

namespace Caching
{
    public abstract class CachingProviderBase: ProviderBase
    {
        private static Object obj = new object();

        /// <summary>
        /// 获取缓存索引字典
        /// </summary>
        /// <returns></returns>
        protected abstract Dictionary<String, CachingIndex> GetCachingIndexDictionary();
        /// <summary>
        /// 设置缓存索引字典
        /// </summary>
        /// <param name="dicCachingIndex"></param>
        /// <returns></returns>
        protected abstract bool SetCachingIndexDictionary(Dictionary<String, CachingIndex> dicCachingIndex);

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
        protected abstract TValue GetCachingValue<TKey, TValue>(TKey key);

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
            //lock (obj)
            //{
                Dictionary<String, CachingIndex> dicCachingIdnex = GetCachingIndexDictionary();
                if (dicCachingIdnex == null) return false;
                dicCachingIdnex[cachingIndex.IndexKey] = cachingIndex;

                return SetCachingIndexDictionary(dicCachingIdnex);
            //}
        }

        /// <summary>
        /// 设置缓存值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="caching"></param>
        protected abstract bool SetCachingValue<TKey, TValue>(Caching<TKey, TValue> caching);

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
            //lock (obj)
            //{
                Dictionary<String, CachingIndex> dicCachingIdnex = GetCachingIndexDictionary();
                if (dicCachingIdnex == null) return false;
                dicCachingIdnex.Remove(key);
                return SetCachingIndexDictionary(dicCachingIdnex);
            //}
        }
        /// <summary>
        /// 删除缓存值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        protected abstract bool DeleteCachingValue<TKey>(TKey key);


        public bool DeleteExpiredCachings()
        {
            bool result = true;
            lock (obj)
            {

                //Copy 目录, 以防影响原目录
                Dictionary<String, CachingIndex> dicCachingIndexCopy = new Dictionary<string, CachingIndex>();

                Dictionary<String, CachingIndex> dicCachingIndexSource = GetCachingIndexDictionary();

                if (dicCachingIndexSource == null) return false;

                foreach (KeyValuePair<String, CachingIndex> index in dicCachingIndexSource)
                {
                    dicCachingIndexCopy.Add(index.Key, index.Value);
                }



                for (int i = 0; i < dicCachingIndexCopy.Count; i++)
                {
                    KeyValuePair<String, CachingIndex> caIndex = dicCachingIndexCopy.ElementAt(i);

                    if (caIndex.Value.Expired)
                    {
                        result = DeleteCaching(Convert.ChangeType(caIndex.Key, caIndex.Value.KeyType));
                    }
                }
            }
            return result;
        }


    }
}
