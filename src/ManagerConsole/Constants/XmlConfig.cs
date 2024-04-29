using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleMJ.Constants
{
    internal class XmlConfig
    {
        public static XmlDocument Doc { get; set; } = new XmlDocument();
        private const string _path = @"Original\\reward_messages.x7";
        private const string _path2 = @"Original\\CapsuleSystem.xml";

        public XmlConfig()
        { }

        public static void LvlReward(string nlvl, int lvl)
        {
            Doc.Load(_path);

            XmlElement RwdMessage = Doc.CreateElement($"reward_message_{lvl}");

            XmlElement TextViewer = Doc.CreateElement("text_viewer");
            TextViewer.SetAttribute("x", "20");
            TextViewer.SetAttribute("y", "0");
            TextViewer.SetAttribute("width", "360");
            TextViewer.SetAttribute("height", "100");

            XmlElement Ame = Doc.CreateElement("ame");
            Ame.SetAttribute("value", "{A-C}{F-2002_20}{S-S}{CB-73,158,255,255}" + string.Format("{0} {1} rank up!", nlvl, lvl));

            XmlElement Eng = Doc.CreateElement("eng");
            Eng.SetAttribute("value", "{A-C}{F-2002_20}{S-S}{CB-73,158,255,255}" + string.Format("{0} {1} rank up!", nlvl, lvl));

            XmlElement Fre = Doc.CreateElement("fre");
            Fre.SetAttribute("value", "{A-C}{F-2002_20}{S-S}{CB-73,158,255,255}" + string.Format("{0} {1} rank up!", nlvl, lvl));

            XmlElement Ger = Doc.CreateElement("ger");
            Ger.SetAttribute("value", "{A-C}{F-2002_20}{S-S}{CB-73,158,255,255}" + string.Format("{0} {1} rank erreicht!", nlvl, lvl));

            XmlElement Ita = Doc.CreateElement("ita");
            Ita.SetAttribute("value", "{A-C}{F-2002_20}{S-S}{CB-73,158,255,255}" + string.Format("{0} {1} rank up!", nlvl, lvl));

            XmlElement Kor = Doc.CreateElement("kor");
            Kor.SetAttribute("value", "{A-C}{F-2002_20}{S-S}{CB-73,158,255,255}" + string.Format("{0} {1} 랭크 업!", nlvl, lvl));

            XmlElement Rus = Doc.CreateElement("rus");
            Rus.SetAttribute("value", "{A-C}{F-2002_20}{S-S}{CB-73,158,255,255}" + string.Format("Достигнут ранг {0} {1}!", nlvl, lvl));

            XmlElement Spa = Doc.CreateElement("spa");
            Spa.SetAttribute("value", "{A-C}{F-2002_20}{S-S}{CB-73,158,255,255}" + string.Format("{0} {1} rank up!", nlvl, lvl));

            XmlElement Cns = Doc.CreateElement("cns");
            Cns.SetAttribute("value", "{A-C}{F-2002_20}{S-S}{CB-73,158,255,255}" + string.Format("{0} {1} rank up!", nlvl, lvl));

            XmlElement Jap = Doc.CreateElement("jap");
            Jap.SetAttribute("value", "{A-C}{F-2002_20}{S-S}{CB-73,158,255,255}" + string.Format("{0} {1}にランクアップ!", nlvl, lvl));

            XmlElement Twn = Doc.CreateElement("twn");
            Twn.SetAttribute("value", "{A-C}{F-2002_20}{S-S}{CB-73,158,255,255}" + string.Format("{0} {1}等級 !", nlvl, lvl));

            XmlElement Tur = Doc.CreateElement("tur");
            Tur.SetAttribute("value", "{A-C}{F-2002_20}{S-S}{CB-73,158,255,255}" + string.Format("{0} {1} rank up!", nlvl, lvl));

            TextViewer.AppendChild(Ame);
            TextViewer.AppendChild(Eng);
            TextViewer.AppendChild(Fre);
            TextViewer.AppendChild(Ger);
            TextViewer.AppendChild(Ita);
            TextViewer.AppendChild(Kor);
            TextViewer.AppendChild(Rus);
            TextViewer.AppendChild(Spa);
            TextViewer.AppendChild(Cns);
            TextViewer.AppendChild(Jap);
            TextViewer.AppendChild(Twn);
            TextViewer.AppendChild(Tur);

            XmlElement TextViewer2 = Doc.CreateElement("text_viewer");
            TextViewer2.SetAttribute("x", "20");
            TextViewer2.SetAttribute("y", "80");
            TextViewer2.SetAttribute("width", "360");
            TextViewer2.SetAttribute("height", "25");

            XmlElement Ame2 = Doc.CreateElement("ame");
            Ame2.SetAttribute("value", "{A-C}{F-2002_13}{S-S}{CB-134,188,227,255}");

            XmlElement Ger2 = Doc.CreateElement("ger");
            Ger2.SetAttribute("value", "{A-C}{F-2002_13}{S-S}{CB-134,188,227,255}Du hast eine Level-up Reward Capsule erhalten!");

            XmlElement Fre2 = Doc.CreateElement("fre");
            Fre2.SetAttribute("value", "{A-C}{F-2002_13}{S-S}{CB-134,188,227,255}Vous avez reçu une capsule bonus pour votre nouveau niveau !");

            XmlElement Eng2 = Doc.CreateElement("eng");
            Eng2.SetAttribute("value", "{A-C}{F-2002_13}{S-S}{CB-134,188,227,255}You received a level-up reward capsule!");

            XmlElement Ita2 = Doc.CreateElement("ita");
            Ita2.SetAttribute("value", "{A-C}{F-2002_13}{S-S}{CB-134,188,227,255}Hai ricevuto la Capsule per il nuovo livello!");

            XmlElement Kor2 = Doc.CreateElement("kor");
            Kor2.SetAttribute("value", "{A-C}{F-2002_13}{S-S}{CB-134,188,227,255}레벨 보상 캡슐 아이템을 획득 하였습니다!");

            XmlElement Rus2 = Doc.CreateElement("rus");
            Rus2.SetAttribute("value", "{A-C}{F-2002_13}{S-S}{CB-134,188,227,255}Ты получаешь наградную капсулу за переход на новый уровень!");

            XmlElement Spa2 = Doc.CreateElement("spa");
            Spa2.SetAttribute("value", "{A-C}{F-2002_13}{S-S}{CB-134,188,227,255}Recibiste una Reward Capsule para subir de nivel!");

            XmlElement Cns2 = Doc.CreateElement("cns");
            Cns2.SetAttribute("value", "{A-C}{F-2002_13}{S-S}{CB-134,188,227,255}");

            XmlElement Twn2 = Doc.CreateElement("twn");
            Twn2.SetAttribute("value", "{A-C}{F-2002_13}{S-S}{CB-134,188,227,255}");

            XmlElement Tha2 = Doc.CreateElement("tha");
            Tha2.SetAttribute("value", "{A-C}{F-2002_13}{S-S}{CB-134,188,227,255}");

            XmlElement Jap2 = Doc.CreateElement("jap");
            Jap2.SetAttribute("value", "{A-C}{F-2002_13}{S-S}{CB-134,188,227,255}レベルアップお祝いのカプセルアイテムを獲得しました！");

            XmlElement Tur2 = Doc.CreateElement("tur");
            Tur2.SetAttribute("value", "{A-C}{F-2002_13}{S-S}{CB-134,188,227,255}You received a level-up reward capsule!");

            TextViewer2.AppendChild(Ame2);
            TextViewer2.AppendChild(Eng2);
            TextViewer2.AppendChild(Fre2);
            TextViewer2.AppendChild(Ger2);
            TextViewer2.AppendChild(Ita2);
            TextViewer2.AppendChild(Kor2);
            TextViewer2.AppendChild(Rus2);
            TextViewer2.AppendChild(Spa2);
            TextViewer2.AppendChild(Cns2);
            TextViewer2.AppendChild(Jap2);
            TextViewer2.AppendChild(Twn2);
            TextViewer2.AppendChild(Tur2);

            XmlElement TextViewer3 = Doc.CreateElement("text_viewer");
            TextViewer3.SetAttribute("x", "20");
            TextViewer3.SetAttribute("y", "140");
            TextViewer3.SetAttribute("width", "360");
            TextViewer3.SetAttribute("height", "25");

            XmlElement Ame3 = Doc.CreateElement("ame");
            Ame3.SetAttribute("value", "{A-C}{F-2002_12}{S-S}{CB-255,255,0,255}");

            XmlElement Ger3 = Doc.CreateElement("ger");
            Ger3.SetAttribute("value", "{A-C}{F-2002_12}{S-S}{CB-255,255,0,255}Sichere dir deine Belohnung,{N} indem du die Reward Capsule in deinem Inventar öffnest.");

            XmlElement Fre3 = Doc.CreateElement("fre");
            Fre3.SetAttribute("value", "{A-C}{F-2002_12}{S-S}{CB-255,255,0,255}Reçois ta récompense {N} en ouvrant la capsule dans ton inventaire");

            XmlElement Eng3 = Doc.CreateElement("eng");
            Eng3.SetAttribute("value", "{A-C}{F-2002_12}{S-S}{CB-255,255,0,255}Get your reward item {N} by opening the reward capsule in your inventory");

            XmlElement Ita3 = Doc.CreateElement("ita");
            Ita3.SetAttribute("value", "{A-C}{F-2002_12}{S-S}{CB-255,255,0,255}Ritira il tuo premio{N}aprendo la Capsule nel tuo inventario.");

            XmlElement Kor3 = Doc.CreateElement("kor");
            Kor3.SetAttribute("value", "{A-C}{F-2002_12}{S-S}{CB-255,255,0,255}인벤토리에서 습득한 보상 캡슐을 사용하여{N}레벨 보상 아이템을 지급 받으세요!");

            XmlElement Rus3 = Doc.CreateElement("rus");
            Rus3.SetAttribute("value", "{A-C}{F-2002_12}{S-S}{CB-255,255,0,255}Чтобы забрать награду,{N}открой наградную капсулу в инвентаре");

            XmlElement Spa3 = Doc.CreateElement("spa");
            Spa3.SetAttribute("value", "{A-C}{F-2002_12}{S-S}{CB-255,255,0,255}Recibe tu artículo recompensa {N} abriendo la Reward Capsule en tu inventario.");

            XmlElement Cns3 = Doc.CreateElement("cns");
            Cns3.SetAttribute("value", "{A-C}{F-2002_12}{S-S}{CB-255,255,0,255}");

            XmlElement Twn3 = Doc.CreateElement("twn");
            Twn3.SetAttribute("value", "{A-C}{F-2002_12}{S-S}{CB-255,255,0,255}");

            XmlElement Tha3 = Doc.CreateElement("tha3");
            Tha3.SetAttribute("value", "{A-C}{F-2002_12}{S-S}{CB-255,255,0,255}");

            XmlElement Jap3 = Doc.CreateElement("jap");
            Jap3.SetAttribute("value", "{A-C}{F-2002_12}{S-S}{CB-255,255,0,255}受信したカプセルが所持品の中に保管されました。{N}カプセルを使ってプレゼントアイテムを獲得しましょう！");

            XmlElement Tur3 = Doc.CreateElement("tur");
            Tur3.SetAttribute("value", "{A-C}{F-2002_12}{S-S}{CB-255,255,0,255}Get your reward item {N} by opening the reward capsule in your inventory");

            TextViewer3.AppendChild(Ame3);
            TextViewer3.AppendChild(Eng3);
            TextViewer3.AppendChild(Fre3);
            TextViewer3.AppendChild(Ger3);
            TextViewer3.AppendChild(Ita3);
            TextViewer3.AppendChild(Kor3);
            TextViewer3.AppendChild(Rus3);
            TextViewer3.AppendChild(Spa3);
            TextViewer3.AppendChild(Cns3);
            TextViewer3.AppendChild(Jap3);
            TextViewer3.AppendChild(Twn3);
            TextViewer3.AppendChild(Tur3);

            XmlElement Image = Doc.CreateElement("image");
            Image.SetAttribute("x", "150");
            Image.SetAttribute("y", "195");
            Image.SetAttribute("width", "100");
            Image.SetAttribute("height", "100");
            Image.SetAttribute("texture_file", "Resources/Image/OneTimeCharge/icon_g_levelreward.dds");
            Image.SetAttribute("u1", "0");
            Image.SetAttribute("v1", "0");
            Image.SetAttribute("u2", "1");
            Image.SetAttribute("v2", "1");

            RwdMessage.AppendChild(TextViewer);
            RwdMessage.AppendChild(TextViewer2);
            RwdMessage.AppendChild(TextViewer3);
            RwdMessage.AppendChild(Image);

            Doc.DocumentElement.AppendChild(RwdMessage);
            Doc.Save(_path);
        }

        internal class CapsuleSystem
        {
            public static long Id { get; set; } 
            public static byte Type { get; set; }
            public static long ItemId { get; set; }
            public static int PriceType { get; set; }
            public static uint PeriodType { get; set; }
            public static uint Amount { get; set; }
            public static byte Color { get; set; }
            public static uint Effect { get; set; }
            public static uint ChanceForGet { get; set; }
            public static byte Gender { get; set; }

            public CapsuleSystem() { }

            public static void Insert(long _id, byte _type, long _itemid, int _pricetype, uint _periodtype, uint _amount, byte _color, uint effect, uint _chanceforget)
            {
                Doc.Load(_path2);



                Doc.Save(_path2);
            }

            public static void InsertC(long _id, long _itemid)
            {
                Doc.Load(_path2);

                XmlElement Capsule = Doc.CreateElement("Capsule");
                Capsule.SetAttribute("Id", _id.ToString());

                XmlElement Group = Doc.CreateElement("Group");

                XmlElement Rewards = Doc.CreateElement("Rewards");
                Rewards.SetAttribute("Type", "1");
                Rewards.SetAttribute("ItemId", "4031151");
                Rewards.SetAttribute("PriceType", "1");
                Rewards.SetAttribute("PeriodType", "4");
                Rewards.SetAttribute("Amount", "1000");
                Rewards.SetAttribute("Color", "0");
                Rewards.SetAttribute("Effect", "0");
                Rewards.SetAttribute("ChanceForGet", "50");

                XmlElement Rewards2 = Doc.CreateElement("Rewards");
                Rewards2.SetAttribute("Type", "1");
                Rewards2.SetAttribute("ItemId", "4031152");
                Rewards2.SetAttribute("PriceType", "1");
                Rewards2.SetAttribute("PeriodType", "4");
                Rewards2.SetAttribute("Amount", "1500");
                Rewards2.SetAttribute("Color", "0");
                Rewards2.SetAttribute("Effect", "0");
                Rewards2.SetAttribute("ChanceForGet", "45");

                XmlElement Rewards3 = Doc.CreateElement("Rewards");
                Rewards3.SetAttribute("Type", "1");
                Rewards3.SetAttribute("ItemId", "4031177");
                Rewards3.SetAttribute("PriceType", "1");
                Rewards3.SetAttribute("PeriodType", "4");
                Rewards3.SetAttribute("Amount", "2000");
                Rewards3.SetAttribute("Color", "0");
                Rewards3.SetAttribute("Effect", "0");
                Rewards3.SetAttribute("ChanceForGet", "40");

                XmlElement Rewards4 = Doc.CreateElement("Rewards");
                Rewards4.SetAttribute("Type", "2");
                Rewards4.SetAttribute("ItemId", _itemid.ToString());
                Rewards4.SetAttribute("PriceType", "3");
                Rewards4.SetAttribute("PeriodType", "4");
                Rewards4.SetAttribute("Amount", "1");
                Rewards4.SetAttribute("Color", "0");
                Rewards4.SetAttribute("Effect", "0");
                Rewards4.SetAttribute("ChanceForGet", "25");

                Group.AppendChild(Rewards);
                Group.AppendChild(Rewards2);
                Group.AppendChild(Rewards3);
                Group.AppendChild(Rewards4);

                XmlElement Group2 = Doc.CreateElement("Group");

                XmlElement Rewards5 = Doc.CreateElement("Rewards");
                Rewards5.SetAttribute("Type", "2");
                Rewards5.SetAttribute("ItemId", "4040001");
                Rewards5.SetAttribute("PriceType", "3");
                Rewards5.SetAttribute("PeriodType", "4");
                Rewards5.SetAttribute("Amount", "2");
                Rewards5.SetAttribute("Color", "0");
                Rewards5.SetAttribute("Effect", "0");
                Rewards5.SetAttribute("ChanceForGet", "60");

                XmlElement Rewards6 = Doc.CreateElement("Rewards");
                Rewards6.SetAttribute("Type", "2");
                Rewards6.SetAttribute("ItemId", "4040001");
                Rewards6.SetAttribute("PriceType", "3");
                Rewards6.SetAttribute("PeriodType", "4");
                Rewards6.SetAttribute("Amount", "3");
                Rewards6.SetAttribute("Color", "0");
                Rewards6.SetAttribute("Effect", "0");
                Rewards6.SetAttribute("ChanceForGet", "40");

                XmlElement Rewards7 = Doc.CreateElement("Rewards");
                Rewards7.SetAttribute("Type", "2");
                Rewards7.SetAttribute("ItemId", "4040001");
                Rewards7.SetAttribute("PriceType", "3");
                Rewards7.SetAttribute("PeriodType", "4");
                Rewards7.SetAttribute("Amount", "5");
                Rewards7.SetAttribute("Color", "0");
                Rewards7.SetAttribute("Effect", "0");
                Rewards7.SetAttribute("ChanceForGet", "30");

                Group2.AppendChild(Rewards5);
                Group2.AppendChild(Rewards6);
                Group2.AppendChild(Rewards7);

                Capsule.AppendChild(Group);
                Capsule.AppendChild(Group2);

                Doc.DocumentElement.PrependChild(Capsule);

                Doc.Save(_path2);
            }

            /// <summary>
            /// Solo para las cápsulas de set completo [hair, face, coat, pants, gloves, shoes and accesory]
            /// </summary>
            /// <param name="_id"></param>
            /// <param name="_itemid"></param>
            /// <param name="_color"></param>
            /// <param name="_color2"></param>
            public static void InsertS(long _id, int _itemid, byte _color, byte _color2)
            {
                Doc.Load(_path2);

                XmlComment Comment = Doc.CreateComment($"Set Gender[{Gender}]");

                XmlElement Capsule = Doc.CreateElement("Capsule");
                Capsule.SetAttribute("Id", _id.ToString());

                XmlElement Group = Doc.CreateElement("Group");

                XmlElement Rewards = Doc.CreateElement("Rewards");
                Rewards.SetAttribute("Type", "2");
                Rewards.SetAttribute("ItemId", $"100{_itemid}");
                Rewards.SetAttribute("PriceType", "3");
                Rewards.SetAttribute("PeriodType", "1");
                Rewards.SetAttribute("Amount", "0");
                Rewards.SetAttribute("Color", _color.ToString());
                Rewards.SetAttribute("Effect", "10002");
                Rewards.SetAttribute("ChanceForGet", "100");

                Group.AppendChild(Rewards);

                XmlElement Group2 = Doc.CreateElement("Group");

                XmlElement Rewards2 = Doc.CreateElement("Rewards");
                Rewards2.SetAttribute("Type", "2");
                Rewards2.SetAttribute("ItemId", $"101{_itemid}");
                Rewards2.SetAttribute("PriceType", "3");
                Rewards2.SetAttribute("PeriodType", "1");
                Rewards2.SetAttribute("Amount", "0");
                Rewards2.SetAttribute("Color", _color2.ToString() ?? "0");
                Rewards2.SetAttribute("Effect", "16002");
                Rewards2.SetAttribute("ChanceForGet", "100");

                Group2.AppendChild(Rewards2);

                XmlElement Group3 = Doc.CreateElement("Group");

                XmlElement Rewards3 = Doc.CreateElement("Rewards");
                Rewards3.SetAttribute("Type", "2");
                Rewards3.SetAttribute("ItemId", $"102{_itemid}");
                Rewards3.SetAttribute("PriceType", "3");
                Rewards3.SetAttribute("PeriodType", "1");
                Rewards3.SetAttribute("Amount", "0");
                Rewards3.SetAttribute("Color", _color.ToString());
                Rewards3.SetAttribute("Effect", "12002");
                Rewards3.SetAttribute("ChanceForGet", "100");

                Group3.AppendChild(Rewards3);

                XmlElement Group4 = Doc.CreateElement("Group");

                XmlElement Rewards4 = Doc.CreateElement("Rewards");
                Rewards4.SetAttribute("Type", "2");
                Rewards4.SetAttribute("ItemId", $"103{_itemid}");
                Rewards4.SetAttribute("PriceType", "3");
                Rewards4.SetAttribute("PeriodType", "1");
                Rewards4.SetAttribute("Amount", "0");
                Rewards4.SetAttribute("Color", _color.ToString());
                Rewards4.SetAttribute("Effect", "13002");
                Rewards4.SetAttribute("ChanceForGet", "100");

                Group4.AppendChild(Rewards4);

                XmlElement Group5 = Doc.CreateElement("Group");

                XmlElement Rewards5 = Doc.CreateElement("Rewards");
                Rewards5.SetAttribute("Type", "2");
                Rewards5.SetAttribute("ItemId", $"104{_itemid}");
                Rewards5.SetAttribute("PriceType", "3");
                Rewards5.SetAttribute("PeriodType", "1");
                Rewards5.SetAttribute("Amount", "0");
                Rewards5.SetAttribute("Color", _color.ToString());
                Rewards5.SetAttribute("Effect", "14002");
                Rewards5.SetAttribute("ChanceForGet", "100");

                Group5.AppendChild(Rewards5);

                XmlElement Group6 = Doc.CreateElement("Group");

                XmlElement Rewards6 = Doc.CreateElement("Rewards");
                Rewards6.SetAttribute("Type", "2");
                Rewards6.SetAttribute("ItemId", $"105{_itemid}");
                Rewards6.SetAttribute("PriceType", "3");
                Rewards6.SetAttribute("PeriodType", "1");
                Rewards6.SetAttribute("Amount", "0");
                Rewards6.SetAttribute("Color", _color.ToString());
                Rewards6.SetAttribute("Effect", "15002");
                Rewards6.SetAttribute("ChanceForGet", "100");

                Group6.AppendChild(Rewards6);

                XmlElement Group7 = Doc.CreateElement("Group");

                XmlElement Rewards7 = Doc.CreateElement("Rewards");
                Rewards7.SetAttribute("Type", "2");
                Rewards7.SetAttribute("ItemId", $"106{_itemid}");
                Rewards7.SetAttribute("PriceType", "3");
                Rewards7.SetAttribute("PeriodType", "1");
                Rewards7.SetAttribute("Amount", "0");
                Rewards7.SetAttribute("Color", _color2.ToString() ?? "0");
                Rewards7.SetAttribute("Effect", "16002");
                Rewards7.SetAttribute("ChanceForGet", "100");

                Group7.AppendChild(Rewards7);

                Capsule.AppendChild(Group);
                Capsule.AppendChild(Group2);
                Capsule.AppendChild(Group3);
                Capsule.AppendChild(Group4);
                Capsule.AppendChild(Group5);
                Capsule.AppendChild(Group6);
                Capsule.AppendChild(Group7);

                Doc.DocumentElement.PrependChild(Capsule);
                Doc.DocumentElement.PrependChild(Comment);

                Doc.Save(_path2);
            }

            /// <summary>
            /// Solo para las cápsulas que contienen [hair, coat, pants, gloves, shoes and accesory]
            /// </summary>
            /// <param name="_id"></param>
            /// <param name="_itemid"></param>
            /// <param name="_color"></param>
            /// <param name="_color2"></param>
            public static void InsertS2(long _id, int _itemid, byte _color, byte _color2)
            {
                Doc.Load(_path2);

                XmlComment Comment = Doc.CreateComment($"Set Gender[{Gender}]");

                XmlElement Capsule = Doc.CreateElement("Capsule");
                Capsule.SetAttribute("Id", _id.ToString());

                XmlElement Group = Doc.CreateElement("Group");

                XmlElement Rewards = Doc.CreateElement("Rewards");
                Rewards.SetAttribute("Type", "2");
                Rewards.SetAttribute("ItemId", $"100{_itemid}");
                Rewards.SetAttribute("PriceType", "3");
                Rewards.SetAttribute("PeriodType", "1");
                Rewards.SetAttribute("Amount", "0");
                Rewards.SetAttribute("Color", _color.ToString());
                Rewards.SetAttribute("Effect", "10002");
                Rewards.SetAttribute("ChanceForGet", "100");

                Group.AppendChild(Rewards);

                XmlElement Group3 = Doc.CreateElement("Group");

                XmlElement Rewards3 = Doc.CreateElement("Rewards");
                Rewards3.SetAttribute("Type", "2");
                Rewards3.SetAttribute("ItemId", $"102{_itemid}");
                Rewards3.SetAttribute("PriceType", "3");
                Rewards3.SetAttribute("PeriodType", "1");
                Rewards3.SetAttribute("Amount", "0");
                Rewards3.SetAttribute("Color", _color.ToString());
                Rewards3.SetAttribute("Effect", "12002");
                Rewards3.SetAttribute("ChanceForGet", "100");

                Group3.AppendChild(Rewards3);

                XmlElement Group4 = Doc.CreateElement("Group");

                XmlElement Rewards4 = Doc.CreateElement("Rewards");
                Rewards4.SetAttribute("Type", "2");
                Rewards4.SetAttribute("ItemId", $"103{_itemid}");
                Rewards4.SetAttribute("PriceType", "3");
                Rewards4.SetAttribute("PeriodType", "1");
                Rewards4.SetAttribute("Amount", "0");
                Rewards4.SetAttribute("Color", _color.ToString());
                Rewards4.SetAttribute("Effect", "13002");
                Rewards4.SetAttribute("ChanceForGet", "100");

                Group4.AppendChild(Rewards4);

                XmlElement Group5 = Doc.CreateElement("Group");

                XmlElement Rewards5 = Doc.CreateElement("Rewards");
                Rewards5.SetAttribute("Type", "2");
                Rewards5.SetAttribute("ItemId", $"104{_itemid}");
                Rewards5.SetAttribute("PriceType", "3");
                Rewards5.SetAttribute("PeriodType", "1");
                Rewards5.SetAttribute("Amount", "0");
                Rewards5.SetAttribute("Color", _color.ToString());
                Rewards5.SetAttribute("Effect", "14002");
                Rewards5.SetAttribute("ChanceForGet", "100");

                Group5.AppendChild(Rewards5);

                XmlElement Group6 = Doc.CreateElement("Group");

                XmlElement Rewards6 = Doc.CreateElement("Rewards");
                Rewards6.SetAttribute("Type", "2");
                Rewards6.SetAttribute("ItemId", $"105{_itemid}");
                Rewards6.SetAttribute("PriceType", "3");
                Rewards6.SetAttribute("PeriodType", "1");
                Rewards6.SetAttribute("Amount", "0");
                Rewards6.SetAttribute("Color", _color.ToString());
                Rewards6.SetAttribute("Effect", "15002");
                Rewards6.SetAttribute("ChanceForGet", "100");

                Group6.AppendChild(Rewards6);

                XmlElement Group7 = Doc.CreateElement("Group");

                XmlElement Rewards7 = Doc.CreateElement("Rewards");
                Rewards7.SetAttribute("Type", "2");
                Rewards7.SetAttribute("ItemId", $"106{_itemid}");
                Rewards7.SetAttribute("PriceType", "3");
                Rewards7.SetAttribute("PeriodType", "1");
                Rewards7.SetAttribute("Amount", "0");
                Rewards7.SetAttribute("Color", _color2.ToString() ?? "0");
                Rewards7.SetAttribute("Effect", "16002");
                Rewards7.SetAttribute("ChanceForGet", "100");

                Group7.AppendChild(Rewards7);

                Capsule.AppendChild(Group);
                Capsule.AppendChild(Group3);
                Capsule.AppendChild(Group4);
                Capsule.AppendChild(Group5);
                Capsule.AppendChild(Group6);
                Capsule.AppendChild(Group7);

                Doc.DocumentElement.PrependChild(Capsule);
                Doc.DocumentElement.PrependChild(Comment);

                Doc.Save(_path2);
            }

            /// <summary>
            /// Solo para las cápsulas que contienen [face, coat, pants, gloves, shoes and accesory]
            /// </summary>
            /// <param name="_id"></param>
            /// <param name="_itemid"></param>
            /// <param name="_color"></param>
            /// <param name="_color2"></param>
            public static void InsertS3(long _id, int _itemid, byte _color, string _color2)
            {
                Doc.Load(_path2);

                XmlComment Comment = Doc.CreateComment($"Set Gender[{Gender}]");

                XmlElement Capsule = Doc.CreateElement("Capsule");
                Capsule.SetAttribute("Id", _id.ToString());

                XmlElement Group3 = Doc.CreateElement("Group");

                XmlElement Rewards3 = Doc.CreateElement("Rewards");
                Rewards3.SetAttribute("Type", "2");
                Rewards3.SetAttribute("ItemId", $"102{_itemid}");
                Rewards3.SetAttribute("PriceType", "3");
                Rewards3.SetAttribute("PeriodType", "1");
                Rewards3.SetAttribute("Amount", "0");
                Rewards3.SetAttribute("Color", _color.ToString());
                Rewards3.SetAttribute("Effect", "12002");
                Rewards3.SetAttribute("ChanceForGet", "100");

                Group3.AppendChild(Rewards3);

                XmlElement Group4 = Doc.CreateElement("Group");

                XmlElement Rewards4 = Doc.CreateElement("Rewards");
                Rewards4.SetAttribute("Type", "2");
                Rewards4.SetAttribute("ItemId", $"103{_itemid}");
                Rewards4.SetAttribute("PriceType", "3");
                Rewards4.SetAttribute("PeriodType", "1");
                Rewards4.SetAttribute("Amount", "0");
                Rewards4.SetAttribute("Color", _color.ToString());
                Rewards4.SetAttribute("Effect", "13002");
                Rewards4.SetAttribute("ChanceForGet", "100");

                Group4.AppendChild(Rewards4);

                XmlElement Group5 = Doc.CreateElement("Group");

                XmlElement Rewards5 = Doc.CreateElement("Rewards");
                Rewards5.SetAttribute("Type", "2");
                Rewards5.SetAttribute("ItemId", $"104{_itemid}");
                Rewards5.SetAttribute("PriceType", "3");
                Rewards5.SetAttribute("PeriodType", "1");
                Rewards5.SetAttribute("Amount", "0");
                Rewards5.SetAttribute("Color", _color.ToString());
                Rewards5.SetAttribute("Effect", "14002");
                Rewards5.SetAttribute("ChanceForGet", "100");

                Group5.AppendChild(Rewards5);

                XmlElement Group6 = Doc.CreateElement("Group");

                XmlElement Rewards6 = Doc.CreateElement("Rewards");
                Rewards6.SetAttribute("Type", "2");
                Rewards6.SetAttribute("ItemId", $"105{_itemid}");
                Rewards6.SetAttribute("PriceType", "3");
                Rewards6.SetAttribute("PeriodType", "1");
                Rewards6.SetAttribute("Amount", "0");
                Rewards6.SetAttribute("Color", _color.ToString());
                Rewards6.SetAttribute("Effect", "15002");
                Rewards6.SetAttribute("ChanceForGet", "100");

                Group6.AppendChild(Rewards6);

                XmlElement Group7 = Doc.CreateElement("Group");

                XmlElement Rewards7 = Doc.CreateElement("Rewards");
                Rewards7.SetAttribute("Type", "2");
                Rewards7.SetAttribute("ItemId", $"106{_itemid}");
                Rewards7.SetAttribute("PriceType", "3");
                Rewards7.SetAttribute("PeriodType", "1");
                Rewards7.SetAttribute("Amount", "0");
                Rewards7.SetAttribute("Color", _color.ToString());
                Rewards7.SetAttribute("Effect", "16002");
                Rewards7.SetAttribute("ChanceForGet", "100");

                Group7.AppendChild(Rewards7);

                XmlElement Group2 = Doc.CreateElement("Group");

                XmlElement Rewards2 = Doc.CreateElement("Rewards");
                Rewards2.SetAttribute("Type", "2");
                Rewards2.SetAttribute("ItemId", $"101{_itemid}");
                Rewards2.SetAttribute("PriceType", "3");
                Rewards2.SetAttribute("PeriodType", "1");
                Rewards2.SetAttribute("Amount", "0");
                Rewards2.SetAttribute("Color", _color2 ?? "0");
                Rewards2.SetAttribute("Effect", "16002");
                Rewards2.SetAttribute("ChanceForGet", "100");

                Group2.AppendChild(Rewards2);

                Capsule.AppendChild(Group3);
                Capsule.AppendChild(Group4);
                Capsule.AppendChild(Group5);
                Capsule.AppendChild(Group6);
                Capsule.AppendChild(Group7);
                Capsule.AppendChild(Group2);

                Doc.DocumentElement.PrependChild(Capsule);
                Doc.DocumentElement.PrependChild(Comment);

                Doc.Save(_path2);
            }

            /// <summary>
            /// Solo para las cápsulas que contienen [hair, coat, pants, gloves and shoes]
            /// </summary>
            /// <param name="_id"></param>
            /// <param name="_itemid"></param>
            /// <param name="_color"></param>
            /// <param name="_color2"></param>
            public static void InsertS4(long _id, int _itemid, byte _color, byte _color2)
            {
                Doc.Load(_path2);

                XmlComment Comment = Doc.CreateComment($"Set Gender[{Gender}]");

                XmlElement Capsule = Doc.CreateElement("Capsule");
                Capsule.SetAttribute("Id", _id.ToString());

                XmlElement Group3 = Doc.CreateElement("Group");

                XmlElement Rewards3 = Doc.CreateElement("Rewards");
                Rewards3.SetAttribute("Type", "2");
                Rewards3.SetAttribute("ItemId", $"102{_itemid}");
                Rewards3.SetAttribute("PriceType", "3");
                Rewards3.SetAttribute("PeriodType", "1");
                Rewards3.SetAttribute("Amount", "0");
                Rewards3.SetAttribute("Color", _color.ToString());
                Rewards3.SetAttribute("Effect", "12002");
                Rewards3.SetAttribute("ChanceForGet", "100");

                Group3.AppendChild(Rewards3);

                XmlElement Group4 = Doc.CreateElement("Group");

                XmlElement Rewards4 = Doc.CreateElement("Rewards");
                Rewards4.SetAttribute("Type", "2");
                Rewards4.SetAttribute("ItemId", $"103{_itemid}");
                Rewards4.SetAttribute("PriceType", "3");
                Rewards4.SetAttribute("PeriodType", "1");
                Rewards4.SetAttribute("Amount", "0");
                Rewards4.SetAttribute("Color", _color.ToString());
                Rewards4.SetAttribute("Effect", "13002");
                Rewards4.SetAttribute("ChanceForGet", "100");

                Group4.AppendChild(Rewards4);

                XmlElement Group5 = Doc.CreateElement("Group");

                XmlElement Rewards5 = Doc.CreateElement("Rewards");
                Rewards5.SetAttribute("Type", "2");
                Rewards5.SetAttribute("ItemId", $"104{_itemid}");
                Rewards5.SetAttribute("PriceType", "3");
                Rewards5.SetAttribute("PeriodType", "1");
                Rewards5.SetAttribute("Amount", "0");
                Rewards5.SetAttribute("Color", _color.ToString());
                Rewards5.SetAttribute("Effect", "14002");
                Rewards5.SetAttribute("ChanceForGet", "100");

                Group5.AppendChild(Rewards5);

                XmlElement Group6 = Doc.CreateElement("Group");

                XmlElement Rewards6 = Doc.CreateElement("Rewards");
                Rewards6.SetAttribute("Type", "2");
                Rewards6.SetAttribute("ItemId", $"105{_itemid}");
                Rewards6.SetAttribute("PriceType", "3");
                Rewards6.SetAttribute("PeriodType", "1");
                Rewards6.SetAttribute("Amount", "0");
                Rewards6.SetAttribute("Color", _color.ToString());
                Rewards6.SetAttribute("Effect", "15002");
                Rewards6.SetAttribute("ChanceForGet", "100");

                Group6.AppendChild(Rewards6);

                XmlElement Group = Doc.CreateElement("Group");

                XmlElement Rewards = Doc.CreateElement("Rewards");
                Rewards.SetAttribute("Type", "2");
                Rewards.SetAttribute("ItemId", $"100{_itemid}");
                Rewards.SetAttribute("PriceType", "3");
                Rewards.SetAttribute("PeriodType", "1");
                Rewards.SetAttribute("Amount", "0");
                Rewards.SetAttribute("Color", _color.ToString());
                Rewards.SetAttribute("Effect", "10002");
                Rewards.SetAttribute("ChanceForGet", "100");

                Group.AppendChild(Rewards);

                Capsule.AppendChild(Group3);
                Capsule.AppendChild(Group4);
                Capsule.AppendChild(Group5);
                Capsule.AppendChild(Group6);
                Capsule.AppendChild(Group);

                Doc.DocumentElement.PrependChild(Capsule);
                Doc.DocumentElement.PrependChild(Comment);

                Doc.Save(_path2);
            }

            /// <summary>
            /// Solo para las cápsulas que contienen [face, coat, pants, gloves and shoes]
            /// </summary>
            /// <param name="_id"></param>
            /// <param name="_itemid"></param>
            /// <param name="_color"></param>
            /// <param name="_color2"></param>
            public static void InsertS5(long _id, int _itemid, byte _color, byte _color2)
            {
                Doc.Load(_path2);

                XmlComment Comment = Doc.CreateComment($"Set Gender[{Gender}]");

                XmlElement Capsule = Doc.CreateElement("Capsule");
                Capsule.SetAttribute("Id", _id.ToString());

                XmlElement Group3 = Doc.CreateElement("Group");

                XmlElement Rewards3 = Doc.CreateElement("Rewards");
                Rewards3.SetAttribute("Type", "2");
                Rewards3.SetAttribute("ItemId", $"102{_itemid}");
                Rewards3.SetAttribute("PriceType", "3");
                Rewards3.SetAttribute("PeriodType", "1");
                Rewards3.SetAttribute("Amount", "0");
                Rewards3.SetAttribute("Color", _color.ToString());
                Rewards3.SetAttribute("Effect", "12002");
                Rewards3.SetAttribute("ChanceForGet", "100");

                Group3.AppendChild(Rewards3);

                XmlElement Group4 = Doc.CreateElement("Group");

                XmlElement Rewards4 = Doc.CreateElement("Rewards");
                Rewards4.SetAttribute("Type", "2");
                Rewards4.SetAttribute("ItemId", $"103{_itemid}");
                Rewards4.SetAttribute("PriceType", "3");
                Rewards4.SetAttribute("PeriodType", "1");
                Rewards4.SetAttribute("Amount", "0");
                Rewards4.SetAttribute("Color", _color.ToString());
                Rewards4.SetAttribute("Effect", "13002");
                Rewards4.SetAttribute("ChanceForGet", "100");

                Group4.AppendChild(Rewards4);

                XmlElement Group5 = Doc.CreateElement("Group");

                XmlElement Rewards5 = Doc.CreateElement("Rewards");
                Rewards5.SetAttribute("Type", "2");
                Rewards5.SetAttribute("ItemId", $"104{_itemid}");
                Rewards5.SetAttribute("PriceType", "3");
                Rewards5.SetAttribute("PeriodType", "1");
                Rewards5.SetAttribute("Amount", "0");
                Rewards5.SetAttribute("Color", _color.ToString());
                Rewards5.SetAttribute("Effect", "14002");
                Rewards5.SetAttribute("ChanceForGet", "100");

                Group5.AppendChild(Rewards5);

                XmlElement Group6 = Doc.CreateElement("Group");

                XmlElement Rewards6 = Doc.CreateElement("Rewards");
                Rewards6.SetAttribute("Type", "2");
                Rewards6.SetAttribute("ItemId", $"105{_itemid}");
                Rewards6.SetAttribute("PriceType", "3");
                Rewards6.SetAttribute("PeriodType", "1");
                Rewards6.SetAttribute("Amount", "0");
                Rewards6.SetAttribute("Color", _color.ToString());
                Rewards6.SetAttribute("Effect", "15002");
                Rewards6.SetAttribute("ChanceForGet", "100");

                Group6.AppendChild(Rewards6);

                XmlElement Group2 = Doc.CreateElement("Group");

                XmlElement Rewards2 = Doc.CreateElement("Rewards");
                Rewards2.SetAttribute("Type", "2");
                Rewards2.SetAttribute("ItemId", $"101{_itemid}");
                Rewards2.SetAttribute("PriceType", "3");
                Rewards2.SetAttribute("PeriodType", "1");
                Rewards2.SetAttribute("Amount", "0");
                Rewards2.SetAttribute("Color", _color2.ToString() ?? "0");
                Rewards2.SetAttribute("Effect", "16002");
                Rewards2.SetAttribute("ChanceForGet", "100");

                Group2.AppendChild(Rewards2);

                Capsule.AppendChild(Group3);
                Capsule.AppendChild(Group4);
                Capsule.AppendChild(Group5);
                Capsule.AppendChild(Group6);
                Capsule.AppendChild(Group2);

                Doc.DocumentElement.PrependChild(Capsule);
                Doc.DocumentElement.PrependChild(Comment);

                Doc.Save(_path2);
            }

            /// <summary>
            /// Solo para las cápsulas que continen [coat, pants, gloves, shoes and accesory]
            /// </summary>
            /// <param name="_id"></param>
            /// <param name="_itemid"></param>
            /// <param name="_color"></param>
            /// <param name="_color2"></param>
            public static void InsertS6(long _id, int _itemid, byte _color, byte _color2)
            {
                Doc.Load(_path2);

                XmlComment Comment = Doc.CreateComment($"Set Gender[{Gender}]");

                XmlElement Capsule = Doc.CreateElement("Capsule");
                Capsule.SetAttribute("Id", _id.ToString());

                XmlElement Group3 = Doc.CreateElement("Group");

                XmlElement Rewards3 = Doc.CreateElement("Rewards");
                Rewards3.SetAttribute("Type", "2");
                Rewards3.SetAttribute("ItemId", $"102{_itemid}");
                Rewards3.SetAttribute("PriceType", "3");
                Rewards3.SetAttribute("PeriodType", "1");
                Rewards3.SetAttribute("Amount", "0");
                Rewards3.SetAttribute("Color", _color.ToString());
                Rewards3.SetAttribute("Effect", "12002");
                Rewards3.SetAttribute("ChanceForGet", "100");

                Group3.AppendChild(Rewards3);

                XmlElement Group4 = Doc.CreateElement("Group");

                XmlElement Rewards4 = Doc.CreateElement("Rewards");
                Rewards4.SetAttribute("Type", "2");
                Rewards4.SetAttribute("ItemId", $"103{_itemid}");
                Rewards4.SetAttribute("PriceType", "3");
                Rewards4.SetAttribute("PeriodType", "1");
                Rewards4.SetAttribute("Amount", "0");
                Rewards4.SetAttribute("Color", _color.ToString());
                Rewards4.SetAttribute("Effect", "13002");
                Rewards4.SetAttribute("ChanceForGet", "100");

                Group4.AppendChild(Rewards4);

                XmlElement Group5 = Doc.CreateElement("Group");

                XmlElement Rewards5 = Doc.CreateElement("Rewards");
                Rewards5.SetAttribute("Type", "2");
                Rewards5.SetAttribute("ItemId", $"104{_itemid}");
                Rewards5.SetAttribute("PriceType", "3");
                Rewards5.SetAttribute("PeriodType", "1");
                Rewards5.SetAttribute("Amount", "0");
                Rewards5.SetAttribute("Color", _color.ToString());
                Rewards5.SetAttribute("Effect", "14002");
                Rewards5.SetAttribute("ChanceForGet", "100");

                Group5.AppendChild(Rewards5);

                XmlElement Group6 = Doc.CreateElement("Group");

                XmlElement Rewards6 = Doc.CreateElement("Rewards");
                Rewards6.SetAttribute("Type", "2");
                Rewards6.SetAttribute("ItemId", $"105{_itemid}");
                Rewards6.SetAttribute("PriceType", "3");
                Rewards6.SetAttribute("PeriodType", "1");
                Rewards6.SetAttribute("Amount", "0");
                Rewards6.SetAttribute("Color", _color.ToString());
                Rewards6.SetAttribute("Effect", "15002");
                Rewards6.SetAttribute("ChanceForGet", "100");

                Group6.AppendChild(Rewards6);

                XmlElement Group7 = Doc.CreateElement("Group");

                XmlElement Rewards7 = Doc.CreateElement("Rewards");
                Rewards7.SetAttribute("Type", "2");
                Rewards7.SetAttribute("ItemId", $"106{_itemid}");
                Rewards7.SetAttribute("PriceType", "3");
                Rewards7.SetAttribute("PeriodType", "1");
                Rewards7.SetAttribute("Amount", "0");
                Rewards7.SetAttribute("Color", _color2.ToString() ?? "0");
                Rewards7.SetAttribute("Effect", "16002");
                Rewards7.SetAttribute("ChanceForGet", "100");

                Group7.AppendChild(Rewards7);

                Capsule.AppendChild(Group3);
                Capsule.AppendChild(Group4);
                Capsule.AppendChild(Group5);
                Capsule.AppendChild(Group6);
                Capsule.AppendChild(Group7);

                Doc.DocumentElement.PrependChild(Capsule);
                Doc.DocumentElement.PrependChild(Comment);

                Doc.Save(_path2);
            }

            /// <summary>
            /// Solo para las cápsulas que contienen [coat, pants, gloves and shoes]
            /// </summary>
            /// <param name="_id"></param>
            /// <param name="_itemid"></param>
            /// <param name="_color"></param>
            /// <param name="_color2"></param>
            public static void InsertS7(long _id, int _itemid, byte _color, byte _color2)
            {
                Doc.Load(_path2);

                XmlComment Comment = Doc.CreateComment($"Set Gender[{Gender}]");

                XmlElement Capsule = Doc.CreateElement("Capsule");
                Capsule.SetAttribute("Id", _id.ToString());

                XmlElement Group3 = Doc.CreateElement("Group");

                XmlElement Rewards3 = Doc.CreateElement("Rewards");
                Rewards3.SetAttribute("Type", "2");
                Rewards3.SetAttribute("ItemId", $"102{_itemid}");
                Rewards3.SetAttribute("PriceType", "3");
                Rewards3.SetAttribute("PeriodType", "1");
                Rewards3.SetAttribute("Amount", "0");
                Rewards3.SetAttribute("Color", _color.ToString());
                Rewards3.SetAttribute("Effect", "12002");
                Rewards3.SetAttribute("ChanceForGet", "100");

                Group3.AppendChild(Rewards3);

                XmlElement Group4 = Doc.CreateElement("Group");

                XmlElement Rewards4 = Doc.CreateElement("Rewards");
                Rewards4.SetAttribute("Type", "2");
                Rewards4.SetAttribute("ItemId", $"103{_itemid}");
                Rewards4.SetAttribute("PriceType", "3");
                Rewards4.SetAttribute("PeriodType", "1");
                Rewards4.SetAttribute("Amount", "0");
                Rewards4.SetAttribute("Color", _color.ToString());
                Rewards4.SetAttribute("Effect", "13002");
                Rewards4.SetAttribute("ChanceForGet", "100");

                Group4.AppendChild(Rewards4);

                XmlElement Group5 = Doc.CreateElement("Group");

                XmlElement Rewards5 = Doc.CreateElement("Rewards");
                Rewards5.SetAttribute("Type", "2");
                Rewards5.SetAttribute("ItemId", $"104{_itemid}");
                Rewards5.SetAttribute("PriceType", "3");
                Rewards5.SetAttribute("PeriodType", "1");
                Rewards5.SetAttribute("Amount", "0");
                Rewards5.SetAttribute("Color", _color.ToString());
                Rewards5.SetAttribute("Effect", "14002");
                Rewards5.SetAttribute("ChanceForGet", "100");

                Group5.AppendChild(Rewards5);

                XmlElement Group6 = Doc.CreateElement("Group");

                XmlElement Rewards6 = Doc.CreateElement("Rewards");
                Rewards6.SetAttribute("Type", "2");
                Rewards6.SetAttribute("ItemId", $"105{_itemid}");
                Rewards6.SetAttribute("PriceType", "3");
                Rewards6.SetAttribute("PeriodType", "1");
                Rewards6.SetAttribute("Amount", "0");
                Rewards6.SetAttribute("Color", _color.ToString());
                Rewards6.SetAttribute("Effect", "15002");
                Rewards6.SetAttribute("ChanceForGet", "100");

                Group6.AppendChild(Rewards6);

                Capsule.AppendChild(Group3);
                Capsule.AppendChild(Group4);
                Capsule.AppendChild(Group5);
                Capsule.AppendChild(Group6);

                Doc.DocumentElement.PrependChild(Capsule);
                Doc.DocumentElement.PrependChild(Comment);

                Doc.Save(_path2);
            }

            /// <summary>
            /// Solo para las cápsulas que contengan [hair, face, coat, pants, gloves and shoes]
            /// </summary>
            /// <param name="_id"></param>
            /// <param name="_itemid"></param>
            /// <param name="_color"></param>
            /// <param name="_color2"></param>
            public static void InsertS8(long _id, int _itemid, byte _color, byte _color2)
            {
                Doc.Load(_path2);

                XmlComment Comment = Doc.CreateComment($"Set Gender[{Gender}]");

                XmlElement Capsule = Doc.CreateElement("Capsule");
                Capsule.SetAttribute("Id", _id.ToString());

                XmlElement Group3 = Doc.CreateElement("Group");

                XmlElement Rewards3 = Doc.CreateElement("Rewards");
                Rewards3.SetAttribute("Type", "2");
                Rewards3.SetAttribute("ItemId", $"102{_itemid}");
                Rewards3.SetAttribute("PriceType", "3");
                Rewards3.SetAttribute("PeriodType", "1");
                Rewards3.SetAttribute("Amount", "0");
                Rewards3.SetAttribute("Color", _color.ToString());
                Rewards3.SetAttribute("Effect", "12002");
                Rewards3.SetAttribute("ChanceForGet", "100");

                Group3.AppendChild(Rewards3);

                XmlElement Group4 = Doc.CreateElement("Group");

                XmlElement Rewards4 = Doc.CreateElement("Rewards");
                Rewards4.SetAttribute("Type", "2");
                Rewards4.SetAttribute("ItemId", $"103{_itemid}");
                Rewards4.SetAttribute("PriceType", "3");
                Rewards4.SetAttribute("PeriodType", "1");
                Rewards4.SetAttribute("Amount", "0");
                Rewards4.SetAttribute("Color", _color.ToString());
                Rewards4.SetAttribute("Effect", "13002");
                Rewards4.SetAttribute("ChanceForGet", "100");

                Group4.AppendChild(Rewards4);

                XmlElement Group5 = Doc.CreateElement("Group");

                XmlElement Rewards5 = Doc.CreateElement("Rewards");
                Rewards5.SetAttribute("Type", "2");
                Rewards5.SetAttribute("ItemId", $"104{_itemid}");
                Rewards5.SetAttribute("PriceType", "3");
                Rewards5.SetAttribute("PeriodType", "1");
                Rewards5.SetAttribute("Amount", "0");
                Rewards5.SetAttribute("Color", _color.ToString());
                Rewards5.SetAttribute("Effect", "14002");
                Rewards5.SetAttribute("ChanceForGet", "100");

                Group5.AppendChild(Rewards5);

                XmlElement Group6 = Doc.CreateElement("Group");

                XmlElement Rewards6 = Doc.CreateElement("Rewards");
                Rewards6.SetAttribute("Type", "2");
                Rewards6.SetAttribute("ItemId", $"105{_itemid}");
                Rewards6.SetAttribute("PriceType", "3");
                Rewards6.SetAttribute("PeriodType", "1");
                Rewards6.SetAttribute("Amount", "0");
                Rewards6.SetAttribute("Color", _color.ToString());
                Rewards6.SetAttribute("Effect", "15002");
                Rewards6.SetAttribute("ChanceForGet", "100");

                Group6.AppendChild(Rewards6);

                XmlElement Group = Doc.CreateElement("Group");

                XmlElement Rewards = Doc.CreateElement("Rewards");
                Rewards.SetAttribute("Type", "2");
                Rewards.SetAttribute("ItemId", $"100{_itemid}");
                Rewards.SetAttribute("PriceType", "3");
                Rewards.SetAttribute("PeriodType", "1");
                Rewards.SetAttribute("Amount", "0");
                Rewards.SetAttribute("Color", _color.ToString());
                Rewards.SetAttribute("Effect", "10002");
                Rewards.SetAttribute("ChanceForGet", "100");

                Group.AppendChild(Rewards);

                XmlElement Group2 = Doc.CreateElement("Group");

                XmlElement Rewards2 = Doc.CreateElement("Rewards");
                Rewards2.SetAttribute("Type", "2");
                Rewards2.SetAttribute("ItemId", $"101{_itemid}");
                Rewards2.SetAttribute("PriceType", "3");
                Rewards2.SetAttribute("PeriodType", "1");
                Rewards2.SetAttribute("Amount", "0");
                Rewards2.SetAttribute("Color", _color2.ToString() ?? "0");
                Rewards2.SetAttribute("Effect", "16002");
                Rewards2.SetAttribute("ChanceForGet", "100");

                Group2.AppendChild(Rewards2);

                Capsule.AppendChild(Group3);
                Capsule.AppendChild(Group4);
                Capsule.AppendChild(Group5);
                Capsule.AppendChild(Group6);
                Capsule.AppendChild(Group);
                Capsule.AppendChild(Group2);

                Doc.DocumentElement.PrependChild(Capsule);
                Doc.DocumentElement.PrependChild(Comment);

                Doc.Save(_path2);
            }
        }
    }
}
