using System;
using System.Runtime.Caching;
using System.Linq;
using System.Collections.Generic;

namespace FengSharp.Tool
{
    public static class MemoryCacheEx
    {
        private static readonly Object _locker = new object();

        public static T GetCacheItem<T>(String key, Func<T> cachePopulate, TimeSpan? slidingExpiration = null, DateTime? absoluteExpiration = null)
        {
            if (String.IsNullOrWhiteSpace(key)) throw new ArgumentException("Invalid cache key");
            if (cachePopulate == null) throw new ArgumentNullException("cachePopulate");
            if (slidingExpiration == null && absoluteExpiration == null) throw new ArgumentException("Either a sliding expiration or absolute must be provided");

            if (MemoryCache.Default[key] == null)
            {
                lock (_locker)
                {
                    if (MemoryCache.Default[key] == null)
                    {
                        var resultValue = cachePopulate();
                        if (resultValue != null)
                        {
                            var item = new CacheItem(key, resultValue);
                            var policy = CreatePolicy(slidingExpiration, absoluteExpiration);
                            MemoryCache.Default.Add(item, policy);
                        }
                    }
                }
            }
            return (T)MemoryCache.Default[key];
        }
        public static T GetCacheItem<T>(String key, Func<T> cachePopulate)
        {
            return GetCacheItem<T>(key, cachePopulate, null, DateTime.MaxValue);
        }
        public static bool HasCache(string key)
        {
            if (MemoryCache.Default[key] != null)
                return true;
            return false;
        }
        public static T GetCache<T>(string Key)
        {
            return (T)MemoryCache.Default[Key];
        }
        public static void RemoveCache(String key)
        {
            if (String.IsNullOrWhiteSpace(key)) throw new ArgumentException("Invalid cache key");
            if (MemoryCache.Default[key] != null)
            {
                lock (_locker)
                {
                    if (MemoryCache.Default[key] != null)
                    {
                        MemoryCache.Default.Remove(key);
                    }
                }
            }
        }
        public static void ClearCache()
        {
            ObjectCache cache = MemoryCache.Default;
            System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>
                items = cache.AsEnumerable();
            foreach (KeyValuePair<string, object> item in items)
            {
                MemoryCache.Default.Remove(item.Key);
            }
            //MemoryCache.Default.Trim(100);
        }
        private static CacheItemPolicy CreatePolicy(TimeSpan? slidingExpiration, DateTime? absoluteExpiration)
        {
            var policy = new CacheItemPolicy();

            if (absoluteExpiration.HasValue)
            {
                policy.AbsoluteExpiration = absoluteExpiration.Value;
            }
            else if (slidingExpiration.HasValue)
            {
                policy.SlidingExpiration = slidingExpiration.Value;
            }

            policy.Priority = CacheItemPriority.Default;

            return policy;
        }

    }
}
