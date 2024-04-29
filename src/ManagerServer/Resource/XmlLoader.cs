using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ManagerServer.Resource;
using ManagerServer.Resource.Xml;
using JLib.S4L.Constants;
using JLib.Constants;

namespace ManagerServer.Loader
{
    public class XmlLoader
    {
        public string ResourcePath { get; }

        public XmlLoader(string Path)
        {
            ResourcePath = Path;
        }

        public IEnumerable<ItemInfo> LoadItems()
        {
            var dto = Deserialize<ItemListDto>("xml/item.x7");
            var stringTable = Deserialize<StringTableDto>("language/xml/iteminfo_string_table.x7");

            return Transform();

            IEnumerable <ItemInfo> Transform()
            {
                foreach (var itemDto in dto.item)
                {
                    var id = new ItemNumber(itemDto.item_key);
                    ItemInfo item = new ItemInfo();

                    byte gender = 0;
                    switch (itemDto.@base.sex.ToLower())
                    {
                        case "man":
                            gender = 1;
                            break;

                        case "woman":
                            gender = 2;
                            break;

                        default:
                            gender = 0;
                            break;
                    }

                    var name = stringTable.@string.FirstOrDefault(s =>
                        s.key.Equals(itemDto.@base.name_key, StringComparison.InvariantCultureIgnoreCase)
                    );

                    item.ItemNumber = id;
                    item.Gender = gender;
                    item.Image = itemDto.graphic.icon_image;
                    item.Description = itemDto.@base.feature_comment_key;

                    if (string.IsNullOrWhiteSpace(name?.eng))
                    {
                        item.Name = name != null ? name.key : itemDto.@base.name;
                    }
                    else
                    {
                        item.Name = name.eng;
                    }

                    yield return item;
                }
            }
        }

        public IEnumerable<ItemInfo> LoadDumpedItems()
        {
            if (!File.Exists("xml/dumpeditems.xml"))
            {
                Console.WriteLine("No se encuentra el archivo dumpeditems.xml...");
                yield return new ItemInfo();
            }

            var dto2 = Deserialize<ItemInfoDto_3>("xml/dumpeditems.xml");
            var ids = new List<uint>();
            foreach (var itemdto in dto2.Item.Where(i => i.Name != "" || i.Name != "not trans"))
            {
                var iteminfo = new ItemInfo
                {
                    ItemNumber = itemdto.ID,
                    Name = itemdto.Name,
                    Colors = (int)itemdto.Color_Count,
                    Description = itemdto.Description
                };
                yield return iteminfo;
            }
        }

        public IEnumerable<DumpedEffect> LoadEffects()
        {
            var dto = Deserialize<DumpedEffectDto>("xml/dumpedeffects.xml");
            return dto.Effects.Select(x => new DumpedEffect(x.ID, x.Name, x.Power_Level));
        }

        public IEnumerable<DailyCapsules> LoadDailyCapsules()
        {
            if (!File.Exists("xml/DailyCapsules.xml"))
            {
                System.Console.WriteLine("No se encuentra el archivo DailyCapsules.xml...");
                yield return new DailyCapsules();
            }

            var dto = Deserialize<DailyCapsulesDto>("xml/DailyCapsules.xml");
            foreach (var c in dto.CapsuleDto)
            {
                var item = new DailyCapsules
                {
                    ItemNumber = c.ItemNumber,
                    ItemName = c.ItemName,
                    ItemPriceType = (ItemPriceType)c.PriceType,
                    ItemPeriodType = (ItemPeriodType)c.PeriodType,
                    ItemPeriod = c.Period,
                    ItemCount = c.Count,
                    ItemChangeForGet = c.ChanceForGet
                };
                yield return item;
            }
        }

        public IEnumerable<KeyCount> LoadKeyCount()
        {
            var dto = Deserialize<KeyCountDto>("xml/keycount.x7");
            var keyId = 0;
            return dto.StringDto.Select(k => new KeyCount
            {
                KeyId = keyId++,
                SceneFile = k.SceneFile,
                SceneCount = k.SceneCount
            });
        }

        public IEnumerable<FileLocation> LoadFileLocation()
        {
            var dto = Deserialize<FileLocationDto>("xml/filelocation.x7");
            var keyId = 0;
            return dto.LocationDto.Select(l => new FileLocation
            {
                KeyId = keyId++,
                FileName = l.FileName,
                Directory = l.Directory
            });
        }

        public IEnumerable<ItemCapsule> LoadItemCapsules()
        {
            var dto = Deserialize<ItemCapsuleDto>("xml/_sa_item_tooltip_addcapsule.x7");
            var itemsKey = new List<uint>();
            return dto.item.Select(x =>
            {
                var itemCapsule = new ItemCapsule(x.id);
                if (!itemsKey.Contains(x.id))
                    itemsKey.Add(x.id);
                else
                    Console.WriteLine(x.id);
                // item
                itemCapsule.ItemId.Add(x?.items?.ID_1 ?? 0);
                itemCapsule.ItemId.Add(x?.items?.ID_2 ?? 0);
                itemCapsule.ItemId.Add(x?.items?.ID_3 ?? 0);
                itemCapsule.ItemId.Add(x?.items?.ID_4 ?? 0);
                itemCapsule.ItemId.Add(x?.items?.ID_5 ?? 0);
                itemCapsule.ItemId.Add(x?.items?.ID_6 ?? 0);
                itemCapsule.ItemId.Add(x?.items?.ID_7 ?? 0);
                itemCapsule.ItemId.Add(x?.items?.ID_8 ?? 0);
                itemCapsule.ItemId.Add(x?.items?.ID_9 ?? 0);
                itemCapsule.ItemId.Add(x?.items?.ID_10 ?? 0);

                // slot
                itemCapsule.ItemSlot.Add((byte)x.groups.slot_1);
                itemCapsule.ItemSlot.Add((byte)x.groups.slot_2);
                itemCapsule.ItemSlot.Add((byte)x.groups.slot_3);
                itemCapsule.ItemSlot.Add((byte)x.groups.slot_4);
                itemCapsule.ItemSlot.Add((byte)x.groups.slot_5);
                itemCapsule.ItemSlot.Add((byte)x.groups.slot_6);
                itemCapsule.ItemSlot.Add((byte)x.groups.slot_7);
                itemCapsule.ItemSlot.Add((byte)x.groups.slot_8);
                itemCapsule.ItemSlot.Add((byte)x.groups.slot_9);
                itemCapsule.ItemSlot.Add((byte)x.groups.slot_10);

                // effects
                itemCapsule.ItemEffect.Add(x.results.effect_key_1);
                itemCapsule.ItemEffect.Add(x.results.effect_key_2);
                itemCapsule.ItemEffect.Add(x.results.effect_key_3);
                itemCapsule.ItemEffect.Add(x.results.effect_key_4);
                itemCapsule.ItemEffect.Add(x.results.effect_key_5);
                itemCapsule.ItemEffect.Add(x.results.effect_key_6);
                itemCapsule.ItemEffect.Add(x.results.effect_key_7);
                itemCapsule.ItemEffect.Add(x.results.effect_key_8);
                itemCapsule.ItemEffect.Add(x.results.effect_key_9);
                itemCapsule.ItemEffect.Add(x.results.effect_key_10);

                // color
                itemCapsule.ItemColor.Add((byte)x.colors.color_1);
                itemCapsule.ItemColor.Add((byte)x.colors.color_2);
                itemCapsule.ItemColor.Add((byte)x.colors.color_3);
                itemCapsule.ItemColor.Add((byte)x.colors.color_4);
                itemCapsule.ItemColor.Add((byte)x.colors.color_5);
                itemCapsule.ItemColor.Add((byte)x.colors.color_6);
                itemCapsule.ItemColor.Add((byte)x.colors.color_7);
                itemCapsule.ItemColor.Add((byte)x.colors.color_8);
                itemCapsule.ItemColor.Add((byte)x.colors.color_9);
                itemCapsule.ItemColor.Add((byte)x.colors.color_10);

                return itemCapsule;
            });
        }

        public IEnumerable<ItemToolTipBase> LoadItemToolTipBase()
        {
            var dto = Deserialize<ItemToolTipBaseDto>("xml/_eu_item_tooltip_base.x7");
            var itemkeyslist = new List<uint>();

            foreach (var item in dto.ItemDtos)
            {
                if (itemkeyslist.Contains(item.id))
                {
                    Console.WriteLine("ItemToolTipBaseDto Contains Id={0}", item.id);
                    continue;
                }

                itemkeyslist.Add(item.id);
                yield return new ItemToolTipBase
                {
                    Id = new ItemNumber(item.id),
                    Base = new ItemToolTipItemBaseBase
                    {
                        DiffKey = item.@base.diffi_key,
                        AttribAP = item.@base.effect_attrib_cash_key,
                        AttribPen = item.@base.effect_attrib_pen_key
                    }
                };
            }
        }

        private T Deserialize<T>(string fileName)
        {
            var serializer = new XmlSerializer(typeof(T));
            var path = Path.Combine(ResourcePath, fileName.Replace('/', Path.DirectorySeparatorChar));
            using (var r = new StreamReader(path))
                return (T)serializer.Deserialize(r);
        }
    }
}
