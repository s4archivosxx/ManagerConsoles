using System;
using System.Collections.Generic;
using System.Linq;
using JLib.Caching;
using ManagerProgram.Loader;
using JLib.Console;

namespace ManagerProgram.Resource
{
    internal class XmlCache
    {
        private readonly XmlLoader _loader;
        private readonly ICache _cache = new MemoryCache();
        private readonly CLog s_logger;

        public XmlCache()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            _loader = new XmlLoader(path);
            s_logger = CLog.Logger.SetSourceContext("XML");
        }
        
        public void PreCache()
        {
            s_logger.InfoMsg("Obteniendo Caché: ConfigApp");
            GetConfigApp();
        }

        public IReadOnlyDictionary<int, CProgram> GetConfigApp()
        {
            var value = _cache.Get<IReadOnlyDictionary<int, CProgram>>(XmlCacheType.ConfigApp);
            if (value == null)
            {
                s_logger.InfoMsg("Caching...");
                value = _loader.GetConfigApp().ToDictionary(f => f.Number);
                _cache.Set(XmlCacheType.ConfigApp, value);
            }

            return value;
        }
    }

    internal static class XmlCacheExtensions
    {
        public static T Get<T>(this ICache cache, XmlCacheType type)
            where T : class
        {
            return cache.Get<T>(type.ToString());
        }

        public static void Set(this ICache cache, XmlCacheType type, object value)
        {
            cache.Set(type.ToString(), value);
        }

        public static void Set(this ICache cache, XmlCacheType type, object value, TimeSpan ts)
        {
            cache.Set(type.ToString(), value, ts);
        }
    }
}
