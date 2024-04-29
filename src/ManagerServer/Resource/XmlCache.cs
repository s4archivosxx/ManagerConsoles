using System;
using System.Collections.Generic;
using System.Linq;
using BlubLib.Caching;
using ManagerServer.Loader;
using CLog;
using JLib.Constants;
using System.IO;
using System.Xml.Serialization;

namespace ManagerServer.Resource
{
    internal class XmlCache
    {
        private readonly string _path;
        private readonly XmlLoader _loader;
        private readonly ICache _cache;
        private readonly IClog _logger;

        public XmlCache(ILogger logger)
        {
            _path = Program._baseDirectory;
            _cache = new MemoryCache();
            _logger = logger.Context(nameof(XmlCache));
            _loader = new XmlLoader(_path);
        }
        
        public void PreCache()
        {
            _logger.Information("Obteniendo items...");
            GetItems();

            _logger.Information("Obteniendo Dumpeditems...");
            GetDumpedItems();

            //_logger.InfoMsg("Obteniendo effects...");

            //_logger.InfoMsg("Obteniendo DailyCapsules");
            //GetDailyCapsules();

            //_logger.InfoMsg("Obteniendo KeyCount");
            //GetKeyCount();

            //_logger.InfoMsg("Obteniendo FileLocation");
            //GetFileLocation();

            //_logger.InfoMsg("Obteniendo Capsules");
            //GetItemCapsules();

            //_logger.InfoMsg("Obteniendo ItemToolTipBase");
            //GetItemToolTipBases();
        }

        public IReadOnlyDictionary<ItemNumber, ItemInfo> GetItems()
        {
            var value = _cache.Get<IReadOnlyDictionary<ItemNumber, ItemInfo>>(XmlCacheType.ItemList);
            if (value == null)
            {
                value = _loader.LoadItems().ToDictionary(item => item.ItemNumber);
                _cache.Set(XmlCacheType.ItemList, value);
                _logger.Information("{count} items", value.Count);
            }
            return value;
        }

        public IReadOnlyDictionary<ItemNumber, ItemInfo> GetDumpedItems()
        {
            var value = _cache.Get<IReadOnlyDictionary<ItemNumber, ItemInfo>>(XmlCacheType.DumpedItems);
            if (value == null)
            {
                value = _loader.LoadDumpedItems().ToDictionary(item => item.ItemNumber);
                _cache.Set(XmlCacheType.DumpedItems, value);
                _logger.Information("{count} Dumpeditems", value.Count);
            }

            return value;
        }

        public IReadOnlyDictionary<uint, DumpedEffect> GetEffects()
        {
            var value = _cache.Get<IReadOnlyDictionary<uint, DumpedEffect>>(XmlCacheType.DumpedEffects);
            if (value == null)
            {
                value = _loader.LoadEffects().ToDictionary(x => x.Id);
                _cache.Set(XmlCacheType.DumpedItems, value);
                _logger.Information("{count} effects", value.Count);
            }

            return value;
        }

        public IReadOnlyDictionary<int, DailyCapsules> GetDailyCapsules()
        {
            var value = _cache.Get<IReadOnlyDictionary<int, DailyCapsules>>(XmlCacheType.DailyCapsules);
            if (value == null)
            {
                value = _loader.LoadDailyCapsules().ToDictionary(c => c.ItemChangeForGet);
                _cache.Set(XmlCacheType.DailyCapsules, value);
                _logger.Information("{count} DailyCapsules", value.Count);
            }

            return value;
        }

        public IReadOnlyDictionary<int, KeyCount> GetKeyCount()
        {
            var value = _cache.Get<IReadOnlyDictionary<int, KeyCount>>(XmlCacheType.KeyCount);
            if (value == null)
            {
                value = _loader.LoadKeyCount().ToDictionary(k => k.KeyId);
                _cache.Set(XmlCacheType.KeyCount, value);
                _logger.Information("{count} KeyCount", value.Count);
            }

            return value;
        }

        public IReadOnlyDictionary<int, FileLocation> GetFileLocation()
        {
            var value = _cache.Get<IReadOnlyDictionary<int, FileLocation>>(XmlCacheType.FileLocation);
            if (value == null)
            {
                value = _loader.LoadFileLocation().ToDictionary(k => k.KeyId);
                _cache.Set(XmlCacheType.FileLocation, value);
                _logger.Information("{count} FileLocation", value.Count);
            }

            return value;
        }

        public IReadOnlyDictionary<ItemNumber, ItemCapsule> GetItemCapsules()
        {
            var value = _cache.Get<IReadOnlyDictionary<ItemNumber, ItemCapsule>>(XmlCacheType.ItemCapsule);
            if (value == null)
            {
                value = _loader.LoadItemCapsules().ToDictionary(i => i.Capsule);
                _cache.Set(XmlCacheType.ItemCapsule, value);
                _logger.Information("{count} Capsules", value.Count);
            }

            return value;
        }

        public IReadOnlyDictionary<ItemNumber, ItemToolTipBase> GetItemToolTipBases()
        {
            var value = _cache.Get<IReadOnlyDictionary<ItemNumber, ItemToolTipBase>>(XmlCacheType.ItemToolTip);
            if (value == null)
            {
                value = _loader.LoadItemToolTipBase().ToDictionary(i => i.Id);
                _cache.Set(XmlCacheType.ItemToolTip, value);
                _logger.Information("{count} bases", value.Count);
            }

            return value;
        }

        public T Deserialize<T>(string fileName)
        {
            var serializer = new XmlSerializer(typeof(T));
            var path = Path.Combine(_path, fileName.Replace('/', Path.DirectorySeparatorChar));
            using (var r = new StreamReader(path))
                return (T)serializer.Deserialize(r);
        }

        public void Serialize<T>(T @object, string fileName)
        {
            var serializer = new XmlSerializer(@object.GetType());
            var path = Path.Combine(_path, fileName.Replace('/', Path.DirectorySeparatorChar));
            using (var w = new StreamWriter(path))
                serializer.Serialize(w, @object);
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
