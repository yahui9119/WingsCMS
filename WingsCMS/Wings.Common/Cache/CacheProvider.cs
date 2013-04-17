using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Common.Cache
{
    /// <summary>
    /// 缓存管理器
    /// <para>
    ///     请在Config文件中配置要使用哪种缓存类型,对于非WEB应用程序来说,只能使用APP类型
    /// </para>
    /// </summary>
    public class CacheProvider
    {
        private volatile static ICache iwebcache;

        public static ICache Cache
        {
            get
            {
                if (iwebcache == null)
                {
                    iwebcache = WebCache.GetCacheService(true);
                }
                return iwebcache;
            }
        }
    }

    /// <summary>
    /// 缓存类型
    /// </summary>
    public enum CacheType
    {
        /// <summary>
        /// 基于WEB的缓存
        /// </summary>
        Web,

        /// <summary>
        /// 基于MemCached
        /// </summary>
        MemCached
    }
}
