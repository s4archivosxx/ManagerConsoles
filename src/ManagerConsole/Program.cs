using System;
using System.IO;
using System.Security.Cryptography;
using System.Xml;
using System.Collections.Generic;
using ConsoleMJ.Constants;
using LogMJ;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleMJ
{
    internal class Program
    {
        private static string name;
        private static string validar;
        public static CLogger CLogger { get; set; }
        public static XmlDocument Doc { get; set; }
        private static IniFile Ini { get; set; }
        private static XDocument xDoc = XDocument.Load(@"dumpeditems.xml");
        private static SystemResources SystemResources { get; set; }

        public static List<long> _items = new List<long>();
        public static List<long> _itemsid = new List<long>();
        public static string _path = "Sql\\DatabasUpdates.sql";

        static void Main(string[] args)
        {
            Console.Title = "ConsoleMJ";
            InitializeObjects();
            StartProgram();
        }

        static void InitializeObjects()
        {
            Doc = new XmlDocument();
            CLogger = new CLogger("Console.log");
            Ini = new IniFile("ConsoleMJ.ini");
            SystemResources = new SystemResources();
            Funtions.Initializate();
        }

        private static void Test2()
        {
            CmdTable();
            Console.ReadKey(true);
        }

        public static void SearchItem()
        {
            foreach (var element in xDoc.Descendants("Item"))
            {
                var item = element.Attribute("ID").Value;
                var name = element.Attribute("Name").Value;
                var colors = element.Attribute("Color_Count").Value;
                ActionsDb.SearchItems(item, name, colors);
            }
        }

        private static void XmlLvlReward()
        {
            string lvl, maxlvl, nlvl;

            CLogger.Consultation("Inserte el primer lvl:");
            CLogger.Answer();
            lvl = Console.ReadLine();
            CLogger.NewLine();

            CLogger.Consultation("Inserte el máx lvl:");
            CLogger.Answer();
            maxlvl = Console.ReadLine();
            CLogger.NewLine();

            CLogger.Consultation("Inserte el nombre del lvl:");
            CLogger.Answer();
            nlvl = Console.ReadLine();
            CLogger.NewLine();

            for (var x = int.Parse(lvl); x < int.Parse(maxlvl); x++)
            {
                CLogger.InfoMsg("Escribiendo nivel: {0}...", x);
                XmlConfig.LvlReward(nlvl, x);
            }

            CLogger.NewLine();
            XmlLvlReward();
            Console.ReadLine();
        }

        private static void XmlConfigLang()
        {
            CLogger.NewLine();
            CLogger.Consultation("Escriba los idiomas predeminados:");
            CLogger.Answer();
            string lang = Console.ReadLine();

            switch (lang)
            {
                case "Español":
                    CmdTable();
                    break;

                case "Português":
                    CLogger.NewLine();
                    ConfigLanguage.Load.LanguagePor();
                    CmdTable();
                    break;

                case "English":
                    CLogger.NewLine();
                    ConfigLanguage.Load.LanguagePor();
                    CmdTable();
                    break;

                default:
                    CLogger.NewLine();
                    CLogger.ErrorMsg("{0} no es un idioma correcto.", lang);
                    CmdTable();
                    break;
            }
        }

        private static void StartProgram()
        {
            CLogger.Message("Por favor Ingrese el nombre de usuario:");
            CLogger.Answer();
            name = Console.ReadLine();

            if (name == "s4archivos" | name == "s4archivos")
            {
                Ini.Write("User", "", "CONFIG");
                CLogger.Message("Hola {0} gusto en verte <3", name);
                ReturnHelp();
                return;
            }

            CLogger.ErrorMsg("{0} es incorrecto.", name);
            StartProgram();
        }

        private static void ReturnHelp()
        {
            CLogger.InfoMsg("Escriba Help para acceder a los comandos");
            CLogger.Answer();
            validar = Console.ReadLine();

            if (validar == "Help" | validar == "help")
            {
                CmdTable();
                return;
            }

            CLogger.ErrorMsg("{0} es incorrecto, Por favor:", validar);
            ReturnHelp();
        }

        public static void CmdTable()
        {
            string Number;

            CLogger.NewLine();
            CLogger.CmdMsg("0.Migración de items.");
            CLogger.CmdMsg("1.-Generador de Key.");
            CLogger.CmdMsg("2.-Multiplicación [int, long, double, float, etc].");
            CLogger.CmdMsg("3.-Test2.");
            CLogger.CmdMsg("4.-SendCapsuleForMaintenance.");
            CLogger.CmdMsg("5.-Insertar nuevos items en shop_items.");
            CLogger.CmdMsg("7.-Buscar Players");
            CLogger.CmdMsg("8.-Generar contraseña encriptada.");
            CLogger.CmdMsg("9.-Migrar nivel de las cuentas.");
            CLogger.CmdMsg("10.-Enviar Items de la Rotación.");
            CLogger.CmdMsg("11.-Enviar Premio Extra de la Rotación.");
            CLogger.CmdMsg("12.-XmlConfig.");
            CLogger.CmdMsg("13.Información completa de un archivo.");
            CLogger.CmdMsg("14.-Salir.");
            CLogger.NewLine();
            CLogger.InfoMsg("Escriba cualquiera de los números para continuar: ", false);
            Number = Console.ReadLine();
            switch (Number)
            {
                case "0":
                    MigrationsItemsOfThePlayers();
                    break;

                case "1":
                    GeneratorKey();
                    break;

                case "2":
                    MultiplicationOfNumbersInt();
                    break;

                case "3":
                    Test2();
                    break;

                case "4":
                    SendCapsuleForMaintenance();
                    break;

                case "5":
                    InsertarInTheShopAtk();
                    break;

                case "7":
                    SearchPlayersAtk();
                    break;

                case "8":
                    GenerarContraseña();
                    break;

                case "9":
                    MigrationLevelAccounts();
                    break;

                case "10":
                    SearchMatchsAccounts();
                    break;

                case "11":
                    SendExtraReward();
                    break;

                case "12":
                    XmlConfigLang();
                    break;

                case "13":
                    CLogger.NewLine();
                    CLogger.Message("== =========================", true);
                    CLogger.Message("== Leyendo archivo...", true);
                    CLogger.Message("== =========================", true);
                    CLogger.Consultation("Ingrese el nombre del archivo: ", false);
                    var name = CLogger.ReadLine();
                    Funtions.GetFuntions.ReadFile(name);
                    CmdTable();
                    CLogger.Wait();
                    break;

                case "14":
                    Environment.Exit(0);
                    break;

                default:
                    CLogger.NewLine();
                    CLogger.ErrorMsg("'{0}' es incorrecto.", Number);
                    CmdTable();
                    break;
            }
        }

        private static void MultiplicationOfNumbersInt()
        {
            Math2 _Multiplication = new Math2();

            string[] value = new string[3];

            CLogger.NewLine();
            CLogger.Message("=====================================================");
            CLogger.Message("== MULTIPLICACION DE NUMEROS");
            CLogger.Message("=====================================================");

            CLogger.Consultation("Inserte los numeros[1, 2,Tipo]:");
            CLogger.Answer();
            value[0] = Console.ReadLine();
            CLogger.Answer();
            value[1] = Console.ReadLine();
            CLogger.Answer();
            value[2] = Console.ReadLine();
            CLogger.Answer();
            CLogger.NewLine();

            switch (value[2])
            {
                case "long":
                    CLogger.DebugMsg("Long Result: {0}", _Multiplication.Multiplication(long.Parse(value[0]), long.Parse(value[1])));
                    break;

                case "double":
                    CLogger.DebugMsg("Double Result: {0}", _Multiplication.Multiplication(double.Parse(value[0]), double.Parse(value[1])));
                    break;

                case "int":
                    CLogger.DebugMsg("Int Result: {0}", _Multiplication.Multiplication(int.Parse(value[0]), int.Parse(value[1])));
                    break;

                case "uint":
                    CLogger.DebugMsg("Uint Result: {0}", _Multiplication.Multiplication(uint.Parse(value[0]), uint.Parse(value[1])));
                    break;

                case "uitn x int":
                    CLogger.DebugMsg("Uint X Int Result: {0}", _Multiplication.Multiplication(uint.Parse(value[0]), int.Parse(value[1])));
                    break;

                case "int x uint":
                    CLogger.DebugMsg("Int X Uint Result: {0}", _Multiplication.Multiplication(int.Parse(value[0]), uint.Parse(value[1])));
                    break;

                case "long x uint":
                    CLogger.DebugMsg("Long X Uint Result: {0}", _Multiplication.Multiplication(long.Parse(value[0]), uint.Parse(value[1])));
                    break;

                case "long x double":
                    CLogger.DebugMsg("Long X Uint Result: {0}", _Multiplication.Multiplication(long.Parse(value[0]), double.Parse(value[1])));
                    break;

                default:
                    CLogger.ErrorMsg("{0} no está disponible", value[2]);
                    break;
            }

            CmdTable();
            Console.ReadLine();
        }

        private static void CmdTrial()
        {
            int Number = 0;

            CLogger.NewLine();

            CLogger.CmdMsg("1.-Generador de Key.");
            CLogger.CmdMsg("3.-Salir.");

            CLogger.NewLine();

            CLogger.InfoMsg("Escriba cualquiera de los números para continuar...");
            CLogger.Answer();
            Number = int.Parse(Console.ReadLine());
            switch (Number)
            {
                case 1:
                    GeneratorKey();
                    break;
                case 3:
                    CLogger.Exit();
                    break;
                default:
                    break;
            }

            if (Number > 4)
            {
                CLogger.ErrorMsg($"El número {Number} no es un comando valido.");
                CLogger.Exit();
            }
        }

        public static void MigrationsItemsOfThePlayers()
        {
            CLogger.NewLine();
            CLogger.Message("========================================");
            CLogger.Message("== MIGRACION DE ITEMS");
            CLogger.Message("========================================");

            CLogger.Consultation("Inserte NicknameS1:");
            CLogger.Answer();
            validar = Console.ReadLine();

            ActionsDb.SearchOldAccount(validar);

            File.AppendAllText(ActionsDb._path, string.Format("-- --------------------------------------------------------------------------------------------------- {0}" +
                "-- - USER ARTICLES({1}) -- {2} {3}" +
                "-- --------------------------------------------------------------------------------------------------- {4} {5}", Environment.NewLine, ActionsDb.OldId,
                DateTime.Now.ToString("HH:mm:ss dd.MM.yyyy"), Environment.NewLine, Environment.NewLine, Environment.NewLine));

            foreach (long id in _items)
                ActionsDb.SearchShopItems(id);

            ItemsSeason1();

            foreach (long itemid in _itemsid)
                ActionsDb.SearchShopItemsId(itemid);

            CLogger.InfoMsg("Items of user({0}): {1}", ActionsDb.OldId, _items.Count);

            CmdTable();
            Console.ReadLine();
        }

        public static void ItemsSeason1()
        {
            #region Removing ItemsSeason1

            if (_itemsid.Contains(1002063))
            {
                _itemsid.Remove(1002063);
                _itemsid.Add(1001163);
            }

            if (_itemsid.Contains(1012063))
            {
                _itemsid.Remove(1012063);
                _itemsid.Add(1011163);
            }

            if (_itemsid.Contains(1022063))
            {
                _itemsid.Remove(1022063);
                _itemsid.Add(1021163);
            }

            if (_itemsid.Contains(1032063))
            {
                _itemsid.Remove(1032063);
                _itemsid.Add(1031163);
            }

            if (_itemsid.Contains(1042063))
            {
                _itemsid.Remove(1042063);
                _itemsid.Add(1041163);
            }

            if (_itemsid.Contains(1052063))
            {
                _itemsid.Remove(1052063);
                _itemsid.Add(1051163);
            }

            if (_itemsid.Contains(1002062))
            {
                _itemsid.Remove(1002062);
                _itemsid.Add(1001162);
            }

            if (_itemsid.Contains(1062062))
            {
                _itemsid.Remove(1062062);
                _itemsid.Add(1061162);
            }

            if (_itemsid.Contains(1022062))
            {
                _itemsid.Remove(1022062);
                _itemsid.Add(1021162);
            }

            if (_itemsid.Contains(1032062))
            {
                _itemsid.Remove(1032062);
                _itemsid.Add(1031162);
            }

            if (_itemsid.Contains(1042062))
            {
                _itemsid.Remove(1042062);
                _itemsid.Add(1041162);
            }

            if (_itemsid.Contains(1052062))
            {
                _itemsid.Remove(1052062);
                _itemsid.Add(1051162);
            }

            if (_itemsid.Contains(1002041))
            {
                _itemsid.Remove(1002041);
                _itemsid.Add(1001141);
            }

            if (_itemsid.Contains(1012041))
            {
                _itemsid.Remove(1012041);
                _itemsid.Add(1011141);
            }

            if (_itemsid.Contains(1022041))
            {
                _itemsid.Remove(1022041);
                _itemsid.Add(1021141);
            }

            if (_itemsid.Contains(1032041))
            {
                _itemsid.Remove(1032041);
                _itemsid.Add(1031141);
            }

            if (_itemsid.Contains(1042041))
            {
                _itemsid.Remove(1042041);
                _itemsid.Add(1041141);
            }

            if (_itemsid.Contains(1052041))
            {
                _itemsid.Remove(1052041);
                _itemsid.Add(1051141);
            }

            if (_itemsid.Contains(1002040))
            {
                _itemsid.Remove(1002040);
                _itemsid.Add(1001140);
            }

            if (_itemsid.Contains(1012040))
            {
                _itemsid.Remove(1012040);
                _itemsid.Add(1011140);
            }

            if (_itemsid.Contains(1022040))
            {
                _itemsid.Remove(1022040);
                _itemsid.Add(1021140);
            }

            if (_itemsid.Contains(1032040))
            {
                _itemsid.Remove(1032040);
                _itemsid.Add(1031140);
            }

            if (_itemsid.Contains(1042040))
            {
                _itemsid.Remove(1042040);
                _itemsid.Add(1041140);
            }

            if (_itemsid.Contains(1052040))
            {
                _itemsid.Remove(1052040);
                _itemsid.Add(1051140);
            }

            if (_itemsid.Contains(1002023))
            {
                _itemsid.Remove(1002023);
                _itemsid.Add(1001123);
            }

            if (_itemsid.Contains(1022023))
            {
                _itemsid.Remove(1022023);
                _itemsid.Add(1021123);
            }

            if (_itemsid.Contains(1032023))
            {
                _itemsid.Remove(1032023);
                _itemsid.Add(1031123);
            }

            if (_itemsid.Contains(1042023))
            {
                _itemsid.Remove(1042023);
                _itemsid.Add(1041123);
            }

            if (_itemsid.Contains(1052023))
            {
                _itemsid.Remove(1052023);
                _itemsid.Add(1051123);
            }

            if (_itemsid.Contains(1002022))
            {
                _itemsid.Remove(1002022);
                _itemsid.Add(1001122);
            }

            if (_itemsid.Contains(1022022))
            {
                _itemsid.Remove(1022022);
                _itemsid.Add(1021122);
            }

            if (_itemsid.Contains(1032022))
            {
                _itemsid.Remove(1032022);
                _itemsid.Add(1031122);
            }

            if (_itemsid.Contains(1042022))
            {
                _itemsid.Remove(1042022);
                _itemsid.Add(1041122);
            }

            if (_itemsid.Contains(1052022))
            {
                _itemsid.Remove(1052022);
                _itemsid.Add(1051122);
            }

            if (_itemsid.Contains(1002075))
            {
                _itemsid.Remove(1002075);
                _itemsid.Add(1001175);
            }

            if (_itemsid.Contains(1022075))
            {
                _itemsid.Remove(1022075);
                _itemsid.Add(1021175);
            }

            if (_itemsid.Contains(1032075))
            {
                _itemsid.Remove(1032075);
                _itemsid.Add(1031175);
            }

            if (_itemsid.Contains(1042075))
            {
                _itemsid.Remove(1042075);
                _itemsid.Add(1041175);
            }

            if (_itemsid.Contains(1052075))
            {
                _itemsid.Remove(1052075);
                _itemsid.Add(1051175);
            }

            if (_itemsid.Contains(1002074))
            {
                _itemsid.Remove(1002074);
                _itemsid.Add(1001174);
            }

            if (_itemsid.Contains(1022074))
            {
                _itemsid.Remove(1022074);
                _itemsid.Add(1021174);
            }

            if (_itemsid.Contains(1032074))
            {
                _itemsid.Remove(1032074);
                _itemsid.Add(1031174);
            }

            if (_itemsid.Contains(1042074))
            {
                _itemsid.Remove(1042074);
                _itemsid.Add(1041174);
            }

            if (_itemsid.Contains(1052074))
            {
                _itemsid.Remove(1052074);
                _itemsid.Add(1051174);
            }

            if (_itemsid.Contains(1062090))
            {
                _itemsid.Remove(1062090);
                _itemsid.Add(1061190);
            }

            if (_itemsid.Contains(1002090))
            {
                _itemsid.Remove(1002090);
                _itemsid.Add(1001190);
            }

            if (_itemsid.Contains(1022090))
            {
                _itemsid.Remove(1022090);
                _itemsid.Add(1021190);
            }

            if (_itemsid.Contains(1032090))
            {
                _itemsid.Remove(1032090);
                _itemsid.Add(1031190);
            }

            if (_itemsid.Contains(1042090))
            {
                _itemsid.Remove(1042090);
                _itemsid.Add(1041190);
            }

            if (_itemsid.Contains(1052090))
            {
                _itemsid.Remove(1052090);
                _itemsid.Add(1051190);
            }

            if (_itemsid.Contains(1062098))
            {
                _itemsid.Remove(1062098);
                _itemsid.Add(1061198);
            }

            if (_itemsid.Contains(1022098))
            {
                _itemsid.Remove(1022098);
                _itemsid.Add(1021198);
            }

            if (_itemsid.Contains(1032098))
            {
                _itemsid.Remove(1032098);
                _itemsid.Add(1031198);
            }

            if (_itemsid.Contains(1042098))
            {
                _itemsid.Remove(1042098);
                _itemsid.Add(1041198);
            }

            if (_itemsid.Contains(1052098))
            {
                _itemsid.Remove(1052098);
                _itemsid.Add(1051198);
            }

            if (_itemsid.Contains(1062096))
            {
                _itemsid.Remove(1062096);
                _itemsid.Add(1061196);
            }

            if (_itemsid.Contains(1002096))
            {
                _itemsid.Remove(1002096);
                _itemsid.Add(1001196);
            }

            if (_itemsid.Contains(1022096))
            {
                _itemsid.Remove(1022096);
                _itemsid.Add(1021196);
            }

            if (_itemsid.Contains(1032096))
            {
                _itemsid.Remove(1032096);
                _itemsid.Add(1031196);
            }

            if (_itemsid.Contains(1042096))
            {
                _itemsid.Remove(1042096);
                _itemsid.Add(1041196);
            }

            if (_itemsid.Contains(1052096))
            {
                _itemsid.Remove(1052096);
                _itemsid.Add(1051196);
            }

            if (_itemsid.Contains(1032097))
            {
                _itemsid.Remove(1032097);
                _itemsid.Add(1031197);
            }

            if (_itemsid.Contains(1032099))
            {
                _itemsid.Remove(1032099);
                _itemsid.Add(1031199);
            }

            if (_itemsid.Contains(1062078))
            {
                _itemsid.Remove(1062078);
                _itemsid.Add(1061178);
            }

            if (_itemsid.Contains(1002078))
            {
                _itemsid.Remove(1002078);
                _itemsid.Add(1001178);
            }

            if (_itemsid.Contains(1012078))
            {
                _itemsid.Remove(1012078);
                _itemsid.Add(1011178);
            }

            if (_itemsid.Contains(1022078))
            {
                _itemsid.Remove(1022078);
                _itemsid.Add(1021178);
            }

            if (_itemsid.Contains(1032078))
            {
                _itemsid.Remove(1032078);
                _itemsid.Add(1031178);
            }

            if (_itemsid.Contains(1042078))
            {
                _itemsid.Remove(1042078);
                _itemsid.Add(1041178);
            }

            if (_itemsid.Contains(1052078))
            {
                _itemsid.Remove(1052078);
                _itemsid.Add(1051178);
            }

            if (_itemsid.Contains(1062079))
            {
                _itemsid.Remove(1062079);
                _itemsid.Add(1061179);
            }

            if (_itemsid.Contains(1002079))
            {
                _itemsid.Remove(1002079);
                _itemsid.Add(1001179);
            }

            if (_itemsid.Contains(1012079))
            {
                _itemsid.Remove(1012079);
                _itemsid.Add(1011179);
            }

            if (_itemsid.Contains(1022079))
            {
                _itemsid.Remove(1022079);
                _itemsid.Add(1021179);
            }

            if (_itemsid.Contains(1032079))
            {
                _itemsid.Remove(1032079);
                _itemsid.Add(1031179);
            }

            if (_itemsid.Contains(1042079))
            {
                _itemsid.Remove(1042079);
                _itemsid.Add(1041179);
            }

            if (_itemsid.Contains(1052079))
            {
                _itemsid.Remove(1052079);
                _itemsid.Add(1051179);
            }

            if (_itemsid.Contains(1062070))
            {
                _itemsid.Remove(1062070);
                _itemsid.Add(1061170);
            }

            if (_itemsid.Contains(1002070))
            {
                _itemsid.Remove(1002070);
                _itemsid.Add(1001170);
            }

            if (_itemsid.Contains(1012070))
            {
                _itemsid.Remove(1012070);
                _itemsid.Add(1011170);
            }

            if (_itemsid.Contains(1022070))
            {
                _itemsid.Remove(1022070);
                _itemsid.Add(1021170);
            }

            if (_itemsid.Contains(1032070))
            {
                _itemsid.Remove(1032070);
                _itemsid.Add(1031170);
            }

            if (_itemsid.Contains(1042070))
            {
                _itemsid.Remove(1042070);
                _itemsid.Add(1041170);
            }

            if (_itemsid.Contains(1052070))
            {
                _itemsid.Remove(1052070);
                _itemsid.Add(1051170);
            }

            if (_itemsid.Contains(1062071))
            {
                _itemsid.Remove(1062071);
                _itemsid.Add(1061171);
            }

            if (_itemsid.Contains(1002071))
            {
                _itemsid.Remove(1002071);
                _itemsid.Add(1001171);
            }

            if (_itemsid.Contains(1012071))
            {
                _itemsid.Remove(1012071);
                _itemsid.Add(1011171);
            }

            if (_itemsid.Contains(1022071))
            {
                _itemsid.Remove(1022071);
                _itemsid.Add(1021171);
            }

            if (_itemsid.Contains(1032071))
            {
                _itemsid.Remove(1032071);
                _itemsid.Add(1031171);
            }

            if (_itemsid.Contains(1042071))
            {
                _itemsid.Remove(1042071);
                _itemsid.Add(1041171);
            }

            if (_itemsid.Contains(1052071))
            {
                _itemsid.Remove(1052071);
                _itemsid.Add(1051171);
            }

            if (_itemsid.Contains(1062018))
            {
                _itemsid.Remove(1062018);
                _itemsid.Add(1061118);
            }

            if (_itemsid.Contains(1002018))
            {
                _itemsid.Remove(1002018);
                _itemsid.Add(1001118);
            }

            if (_itemsid.Contains(1012018))
            {
                _itemsid.Remove(1012018);
                _itemsid.Add(1011118);
            }

            if (_itemsid.Contains(1022018))
            {
                _itemsid.Remove(1022018);
                _itemsid.Add(1021118);
            }

            if (_itemsid.Contains(1032018))
            {
                _itemsid.Remove(1032018);
                _itemsid.Add(1031118);
            }

            if (_itemsid.Contains(1042018))
            {
                _itemsid.Remove(1042018);
                _itemsid.Add(1041118);
            }

            if (_itemsid.Contains(1052018))
            {
                _itemsid.Remove(1052018);
                _itemsid.Add(1051118);
            }

            if (_itemsid.Contains(1062019))
            {
                _itemsid.Remove(1062019);
                _itemsid.Add(1061119);
            }

            if (_itemsid.Contains(1002019))
            {
                _itemsid.Remove(1002019);
                _itemsid.Add(1001119);
            }

            if (_itemsid.Contains(1012019))
            {
                _itemsid.Remove(1012019);
                _itemsid.Add(1011119);
            }

            if (_itemsid.Contains(1022019))
            {
                _itemsid.Remove(1022019);
                _itemsid.Add(1021119);
            }

            if (_itemsid.Contains(1032019))
            {
                _itemsid.Remove(1032019);
                _itemsid.Add(1031119);
            }

            if (_itemsid.Contains(1042019))
            {
                _itemsid.Remove(1042019);
                _itemsid.Add(1041119);
            }

            if (_itemsid.Contains(1052019))
            {
                _itemsid.Remove(1052019);
                _itemsid.Add(1051119);
            }

            if (_itemsid.Contains(1062016))
            {
                _itemsid.Remove(1062016);
                _itemsid.Add(1061116);
            }

            if (_itemsid.Contains(1022016))
            {
                _itemsid.Remove(1022016);
                _itemsid.Add(1021116);
            }

            if (_itemsid.Contains(1032016))
            {
                _itemsid.Remove(1032016);
                _itemsid.Add(1031116);
            }

            if (_itemsid.Contains(1042016))
            {
                _itemsid.Remove(1042016);
                _itemsid.Add(1041116);
            }

            if (_itemsid.Contains(1052016))
            {
                _itemsid.Remove(1052016);
                _itemsid.Add(1051116);
            }

            if (_itemsid.Contains(1002017))
            {
                _itemsid.Remove(1002017);
                _itemsid.Add(1001117);
            }

            if (_itemsid.Contains(1022017))
            {
                _itemsid.Remove(1022017);
                _itemsid.Add(1021117);
            }

            if (_itemsid.Contains(1032017))
            {
                _itemsid.Remove(1032017);
                _itemsid.Add(1031117);
            }

            if (_itemsid.Contains(1042017))
            {
                _itemsid.Remove(1042017);
                _itemsid.Add(1041117);
            }

            if (_itemsid.Contains(1052017))
            {
                _itemsid.Remove(1052017);
                _itemsid.Add(1051117);
            }

            if (_itemsid.Contains(1002012))
            {
                _itemsid.Remove(1002012);
                _itemsid.Add(1001112);
            }

            if (_itemsid.Contains(1022012))
            {
                _itemsid.Remove(1022012);
                _itemsid.Add(1021112);
            }

            if (_itemsid.Contains(1032012))
            {
                _itemsid.Remove(1032012);
                _itemsid.Add(1031112);
            }

            if (_itemsid.Contains(1042012))
            {
                _itemsid.Remove(1042012);
                _itemsid.Add(1041112);
            }

            if (_itemsid.Contains(1052012))
            {
                _itemsid.Remove(1052012);
                _itemsid.Add(1051112);
            }

            if (_itemsid.Contains(1002013))
            {
                _itemsid.Remove(1002013);
                _itemsid.Add(1001113);
            }

            if (_itemsid.Contains(1022013))
            {
                _itemsid.Remove(1022013);
                _itemsid.Add(1021113);
            }

            if (_itemsid.Contains(1032013))
            {
                _itemsid.Remove(1032013);
                _itemsid.Add(1031113);
            }

            if (_itemsid.Contains(1042013))
            {
                _itemsid.Remove(1042013);
                _itemsid.Add(1041113);
            }

            if (_itemsid.Contains(1052013))
            {
                _itemsid.Remove(1052013);
                _itemsid.Add(1051113);
            }

            if (_itemsid.Contains(1002010))
            {
                _itemsid.Remove(1002010);
                _itemsid.Add(1001110);
            }

            if (_itemsid.Contains(1022010))
            {
                _itemsid.Remove(1022010);
                _itemsid.Add(1021110);
            }

            if (_itemsid.Contains(1032010))
            {
                _itemsid.Remove(1032010);
                _itemsid.Add(1031110);
            }

            if (_itemsid.Contains(1042010))
            {
                _itemsid.Remove(1042010);
                _itemsid.Add(1041110);
            }

            if (_itemsid.Contains(1052010))
            {
                _itemsid.Remove(1052010);
                _itemsid.Add(1051110);
            }

            if (_itemsid.Contains(1002011))
            {
                _itemsid.Remove(1002011);
                _itemsid.Add(1001111);
            }

            if (_itemsid.Contains(1022011))
            {
                _itemsid.Remove(1022011);
                _itemsid.Add(1021111);
            }

            if (_itemsid.Contains(1032011))
            {
                _itemsid.Remove(1032011);
                _itemsid.Add(1031111);
            }

            if (_itemsid.Contains(1042011))
            {
                _itemsid.Remove(1042011);
                _itemsid.Add(1041111);
            }

            if (_itemsid.Contains(1052011))
            {
                _itemsid.Remove(1052011);
                _itemsid.Add(1051111);
            }

            if (_itemsid.Contains(1002108))
            {
                _itemsid.Remove(1002108);
                _itemsid.Add(1001108);
            }

            if (_itemsid.Contains(1022108))
            {
                _itemsid.Remove(1022108);
                _itemsid.Add(1021108);
            }

            if (_itemsid.Contains(1032108))
            {
                _itemsid.Remove(1032108);
                _itemsid.Add(1031108);
            }

            if (_itemsid.Contains(1042108))
            {
                _itemsid.Remove(1042108);
                _itemsid.Add(1041108);
            }

            if (_itemsid.Contains(1052108))
            {
                _itemsid.Remove(1052108);
                _itemsid.Add(1051108);
            }

            if (_itemsid.Contains(1062108))
            {
                _itemsid.Remove(1062108);
                _itemsid.Add(1061108);
            }

            if (_itemsid.Contains(1002109))
            {
                _itemsid.Remove(1002109);
                _itemsid.Add(1001109);
            }

            if (_itemsid.Contains(1022109))
            {
                _itemsid.Remove(1022109);
                _itemsid.Add(1021109);
            }

            if (_itemsid.Contains(1032109))
            {
                _itemsid.Remove(1032109);
                _itemsid.Add(1031109);
            }

            if (_itemsid.Contains(1042109))
            {
                _itemsid.Remove(1042109);
                _itemsid.Add(1041109);
            }

            if (_itemsid.Contains(1052109))
            {
                _itemsid.Remove(1052109);
                _itemsid.Add(1051109);
            }

            if (_itemsid.Contains(1062109))
            {
                _itemsid.Remove(1062109);
                _itemsid.Add(1061109);
            }

            if (_itemsid.Contains(1022025))
            {
                _itemsid.Remove(1022025);
                _itemsid.Add(1021125);
            }

            if (_itemsid.Contains(1032025))
            {
                _itemsid.Remove(1032025);
                _itemsid.Add(1031125);
            }

            if (_itemsid.Contains(1042025))
            {
                _itemsid.Remove(1042025);
                _itemsid.Add(1041125);
            }

            if (_itemsid.Contains(1052025))
            {
                _itemsid.Remove(1052025);
                _itemsid.Add(1051125);
            }

            if (_itemsid.Contains(1062025))
            {
                _itemsid.Remove(1062025);
                _itemsid.Add(1061125);
            }

            if (_itemsid.Contains(1022024))
            {
                _itemsid.Remove(1022024);
                _itemsid.Add(1021124);
            }

            if (_itemsid.Contains(1032024))
            {
                _itemsid.Remove(1032024);
                _itemsid.Add(1031124);
            }

            if (_itemsid.Contains(1042024))
            {
                _itemsid.Remove(1042024);
                _itemsid.Add(1041124);
            }

            if (_itemsid.Contains(1052024))
            {
                _itemsid.Remove(1052024);
                _itemsid.Add(1051124);
            }

            if (_itemsid.Contains(1062024))
            {
                _itemsid.Remove(1062024);
                _itemsid.Add(1061124);
            }

            if (_itemsid.Contains(1060083))
            {
                _itemsid.Remove(1060083);
                _itemsid.Add(1070017);
            }

            if (_itemsid.Contains(1060057))
            {
                _itemsid.Remove(1060057);
                _itemsid.Add(1070012);
            }

            if (_itemsid.Contains(1060056))
            {
                _itemsid.Remove(1060056);
                _itemsid.Add(1070011);
            }

            if (_itemsid.Contains(1060055))
            {
                _itemsid.Remove(1060055);
                _itemsid.Add(1070010);
            }

            if (_itemsid.Contains(1060054))
            {
                _itemsid.Remove(1060054);
                _itemsid.Add(1070009);
            }

            if (_itemsid.Contains(1060052))
            {
                _itemsid.Remove(1060052);
                _itemsid.Add(1070008);
            }

            if (_itemsid.Contains(1060050))
            {
                _itemsid.Remove(1060050);
                _itemsid.Add(1070007);
            }

            if (_itemsid.Contains(1060045))
            {
                _itemsid.Remove(1060045);
                _itemsid.Add(1070006);
            }

            if (_itemsid.Contains(1060044))
            {
                _itemsid.Remove(1060044);
                _itemsid.Add(1070005);
            }

            if (_itemsid.Contains(1060043))
            {
                _itemsid.Remove(1060043);
                _itemsid.Add(1070004);
            }

            if (_itemsid.Contains(1060001))
            {
                _itemsid.Remove(1060001);
                _itemsid.Add(1070001);
            }

            if (_itemsid.Contains(1060002))
            {
                _itemsid.Remove(1060002);
                _itemsid.Add(1070002);
            }

            if (_itemsid.Contains(1060003))
            {
                _itemsid.Remove(1060003);
                _itemsid.Add(1070003);
            }

            if (_itemsid.Contains(1060063))
            {
                _itemsid.Remove(1060063);
                _itemsid.Add(1070013);
            }

            if (_itemsid.Contains(1060062))
            {
                _itemsid.Remove(1060062);
                _itemsid.Add(1070014);
            }

            if (_itemsid.Contains(1060065))
            {
                _itemsid.Remove(1060065);
                _itemsid.Add(1070015);
            }

            if (_itemsid.Contains(1060099))
            {
                _itemsid.Remove(1060099);
                _itemsid.Add(1070019);
            }

            if (_itemsid.Contains(1067020))
            {
                _itemsid.Remove(1067020);
                _itemsid.Add(1070020);
            }

            if (_itemsid.Contains(1067022))
            {
                _itemsid.Remove(1067022);
                _itemsid.Add(1070022);
            }

            if (_itemsid.Contains(1067036))
            {
                _itemsid.Remove(1067036);
                _itemsid.Add(1070036);
            }

            if (_itemsid.Contains(1067025))
            {
                _itemsid.Remove(1067025);
                _itemsid.Add(1070025);
            }

            _itemsid.Remove(1067021);
            _itemsid.Remove(2000032);
            _itemsid.Remove(1060066);
            _itemsid.Remove(1060089);
            _itemsid.Remove(2030011);
            _itemsid.Remove(2030103);
            _itemsid.Remove(2000115);
            _itemsid.Remove(2010019);
            _itemsid.Remove(2000016);
            _itemsid.Remove(2000056);
            _itemsid.Remove(2010122);
            _itemsid.Remove(2010036); // aqui vas prro
            _itemsid.Remove(2000065);
            _itemsid.Remove(2000063);
            _itemsid.Remove(2000066);
            _itemsid.Remove(2000088);
            _itemsid.Remove(2000125);
            _itemsid.Remove(2000124);
            _itemsid.Remove(2000108);
            _itemsid.Remove(2010133);
            _itemsid.Remove(2010131);
            _itemsid.Remove(2000184);
            _itemsid.Remove(2000070);
            _itemsid.Remove(2000069);
            _itemsid.Remove(2000073);
            _itemsid.Remove(2000085);
            _itemsid.Remove(2000086);
            _itemsid.Remove(2000087);
            _itemsid.Remove(2000031);
            _itemsid.Remove(2000109);
            _itemsid.Remove(2000112);
            _itemsid.Remove(2000127);
            _itemsid.Remove(3020003);
            _itemsid.Remove(2000102);
            _itemsid.Remove(2010107);
            _itemsid.Remove(2000106);
            _itemsid.Remove(2000033);
            _itemsid.Remove(2000034);
            _itemsid.Remove(2000035);
            _itemsid.Remove(2000101);
            _itemsid.Remove(2010114);
            _itemsid.Remove(2010112);
            _itemsid.Remove(2010111);
            _itemsid.Remove(2010127);
            #endregion
        }

        private static void SearchPlayersAtk()
        {
            CLogger.NewLine();
            CLogger.Message("==================================================");
            CLogger.Message("ACTUALIZAR PEN");
            CLogger.Message("==================================================");

            for (var x = int.Parse(Ini.Read("Min", "PLAYERS"));
                  x < int.Parse(Ini.Read("Max", "PLAYERS")); x++)
            {
                ActionsDb.SearchPlayers(x);
            }

            CmdTable();

            Console.ReadLine();
        }

        public static void SearchAmountToPlayers(int PEN, int Id)
        {
            int _pen = 150000;

            if (PEN >= 300000)
            {
                CLogger.InfoMsg("Actualizando({0}) a PEN({1})", Id, _pen);
                ActionsDb.UpdatingPEN(_pen, Id);
            }
        }

        private static void SearchMatchsAccounts()
        {
            string mode = Ini.Read("Count", "MATCHS");

            CLogger.Message("==================================================");
            CLogger.Message("BUSCADOR DE PARTIDAS");
            CLogger.Message("==================================================");
            CLogger.NewLine();

            switch (mode)
            {
                case "ALL":
                    for (var x = int.Parse(Ini.Read("Player", "MATCHS"));
                          x < int.Parse(Ini.Read("PlayerM", "MATCHS")); x++)
                    {
                        ActionsDb.SearchMatchsModeTD(x);

                        ActionsDb.SearchMatchsModeTD2(x);
                    }

                    Ini.Write("Mode", "DM", "MATCHS");

                    for (var x = int.Parse(Ini.Read("Player", "MATCHS"));
                          x < int.Parse(Ini.Read("PlayerM", "MATCHS")); x++)
                    {
                        ActionsDb.SearchMatchsModeDM(x);

                        ActionsDb.SearchMatchsModeDM2(x);
                    }

                    Ini.Write("Mode", "BR", "MATCHS");

                    for (var x = int.Parse(Ini.Read("Player", "MATCHS"));
                          x < int.Parse(Ini.Read("PlayerM", "MATCHS")); x++)
                    {
                        ActionsDb.SearchMatchsModeBR(x);

                        ActionsDb.SearchMatchsModeBR2(x);
                    }

                    Ini.Write("Mode", "SL", "MATCHS");

                    for (var x = int.Parse(Ini.Read("Player", "MATCHS"));
                          x < int.Parse(Ini.Read("PlayerM", "MATCHS")); x++)
                    {
                        ActionsDb.SearchMatchsModeSL(x);

                        ActionsDb.SearchMatchsModeSL2(x);
                    }

                    Ini.Write("Mode", "TD", "MATCHS");

                    CmdTable();
                    break;

                case "TD":
                    for (var x = int.Parse(Ini.Read("Player", "MATCHS"));
                          x < int.Parse(Ini.Read("PlayerM", "MATCHS")); x++)
                    {
                        ActionsDb.SearchMatchsModeTD(x);

                        ActionsDb.SearchMatchsModeTD2(x);
                    }

                    CmdTable();
                    break;

                case "DM":
                    for (var x = int.Parse(Ini.Read("Player", "MATCHS"));
                          x < int.Parse(Ini.Read("PlayerM", "MATCHS")); x++)
                    {
                        ActionsDb.SearchMatchsModeDM(x);

                        ActionsDb.SearchMatchsModeDM2(x);
                    }

                    CmdTable();
                    break;

                case "BR":
                    for (var x = int.Parse(Ini.Read("Player", "MATCHS"));
                          x < int.Parse(Ini.Read("PlayerM", "MATCHS")); x++)
                    {
                        ActionsDb.SearchMatchsModeBR(x);

                        ActionsDb.SearchMatchsModeBR2(x);
                    }

                    CmdTable();
                    break;

                case "SL":
                    for (var x = int.Parse(Ini.Read("Player", "MATCHS"));
                          x < int.Parse(Ini.Read("PlayerM", "MATCHS")); x++)
                    {
                        ActionsDb.SearchMatchsModeSL(x);

                        ActionsDb.SearchMatchsModeSL2(x);
                    }

                    CmdTable();
                    break;
            }

            Console.ReadKey(true);
        }

        /// <summary>
        /// Resta las antiguas partidas con las actuales para así enviar el premio solo si es >= de 25
        /// </summary>
        /// <param name="x">Variable de partidas antiguas</param>
        /// <param name="y">Variable de partidas actuales</param>
        /// <param name="Id">Jugador</param>
        public static void CountMatchs(int x, int y, int id)
        {
            string mode = Ini.Read("Mode", "MATCHS");

            int result = y - x;

            // Logger.InfoMsg("Resultado({0}) de Jugador({1}): {2}", mode, id, result);
            CLogger.DebugMsg("PlayerId({0}) | Modo({1}) | Resultado({2})", id, mode, result);

            if (result >= 25)
            {
                switch (mode)
                {
                    case "TD":
                        ActionsDb.EventRotationTD(id);
                        CLogger.InfoMsg("PlayerId({0}) | Premio TouchDown Enviado.", id);
                        break;

                    case "DM":
                        ActionsDb.EventRotationDM(id);
                        CLogger.InfoMsg("PlayerId({0}) | Premio DeathMatch Enviado.", id);
                        break;

                    case "BR":
                        ActionsDb.EventRotationBR(id);
                        CLogger.InfoMsg("PlayerId({0}) | Premio Battle Royal Enviado.", id);
                        break;

                    case "SL":
                        ActionsDb.EventRotationSL(id);
                        CLogger.InfoMsg("PlayerId({0}) | Premio Chaser Enviado.", id);
                        break;

                    default:
                        CLogger.ErrorMsg("Es imposible reconocer el modo: " + mode);
                        break;
                }
            }
        }

        public static void SendExtraReward()
        {
            CLogger.NewLine();
            CLogger.Message("==================================");
            CLogger.Message("ENVIAR PREMIO EXTRA DE LA ROTACIÓN");
            CLogger.Message("==================================");
            CLogger.NewLine();

            CLogger.Consultation("Inserte el Id:");
            CLogger.Answer();
            int id = int.Parse(Console.ReadLine());

            ActionsDb.ExtraRotation(id);
            CLogger.InfoMsg("PlayerId({0}) | Premio Extra Enviado.", id);

            CLogger.NewLine();
            CLogger.Consultation("¿Desea seguir enviado?");
            CLogger.Answer();
            string ans = Console.ReadLine().ToUpper();

            if (ans.Equals("SI"))
                SendExtraReward();
            else
                CmdTable();
        }

        private static void GeneratorKey()
        {
            int Number;
            Random _rd = new Random();
            IniFile ini = new IniFile("ConsoleMJ.ini");
            string readuser = ini.Read("User", "CONFIG");

            CLogger.NewLine();
            CLogger.Consultation("Escriba del 1-6 para generar un código.");
            CLogger.Answer();
            Number = int.Parse(Console.ReadLine());

            #region Programation GeneratorKey
            
            int NR = _rd.Next(1, 24537168);
            int NR2 = _rd.Next(24, 86348925);
            int NR3 = _rd.Next(5, 924537168);
            int NR4 = _rd.Next(1, 7168);

            switch (Number)
            {
                case 1:
                    //Info($"Su Código es: {nc}{nc3}{nc5}{nc2}{nc6}{nc9}{nc8}{nc7}{nc4}{nc2}{nc5}{nc7}{nc4}{nc8}{nc3}{nc6}{nc}{nc9}{nc4}{nc6}{nc8}{nc9}{nc5}{nc2}{nc}{nc3}{nc7}");
                    CLogger.InfoMsg($"Su código es: {NR3}{NR2}{NR}{NR4}");
                    CLogger.InfoMsg("Se a creado un archivo .ini con su código.");
                    //ini.Write("KEY", $"{nc}{nc3}{nc5}{nc2}{nc6}{nc9}{nc8}{nc7}{nc4}{nc2}{nc5}{nc7}{nc4}{nc8}{nc3}{nc6}{nc}{nc9}{nc4}{nc6}{nc8}{nc9}{nc5}{nc2}{nc}{nc3}{nc7}", "KEYCODE");
                    ini.Write("KEY", $"{NR3}{NR2}{NR}{NR4}", "KEYCODE");
                    CLogger.Message("Hasta la próxima!");
                    CLogger.NewLine();
                    CmdTrial();
                    break;
                case 2:
                    CLogger.InfoMsg($"Su Código es: {NR3}{NR2}{NR}{NR4}");
                    CLogger.InfoMsg("Se a creado un archivo .ini con su código.");
                    ini.Write("KEY2", $"{NR3}{NR2}{NR}{NR4}", "KEYCODE");
                    CLogger.Message("Hasta la próxima!");
                    CLogger.NewLine();
                    CmdTrial();
                    break;
                case 3:
                    CLogger.InfoMsg($"Su Código es: {NR2}{NR3}{NR4}{NR}");
                    CLogger.InfoMsg("Se a creado un archivo .ini con su código.");
                    ini.Write("KEY3", $"{NR2}{NR3}{NR4}{NR}", "KEYCODE");
                    CLogger.Message("Hasta la próxima!");
                    CLogger.NewLine();
                    CmdTrial();
                    break;
                case 4:
                    CLogger.InfoMsg($"Su Código es: {NR2}{NR3}{NR4}{NR}");
                    CLogger.InfoMsg("Se a creado un archivo .ini con su código.");
                    ini.Write("KEY4", $"{NR2}{NR3}{NR4}{NR}", "KEYCODE");
                    CLogger.Message("Hasta la próxima!");
                    CLogger.NewLine();
                    CmdTrial();
                    break;
                case 5:
                    CLogger.InfoMsg($"Su Código es: {NR4}{NR3}{NR2}{NR}");
                    CLogger.InfoMsg("Se a creado un archivo .ini con su código.");
                    ini.Write("KEY5", $"{NR4}{NR3}{NR2}{NR}", "KEYCODE");
                    CLogger.Message("Hasta la próxima!");
                    CLogger.NewLine();
                    CmdTrial();
                    break;
                case 6:
                    CLogger.InfoMsg($"Su Código es: {NR3}{NR}{NR4}{NR2}");
                    CLogger.InfoMsg("Se a creado un archivo .ini con su código.");
                    ini.Write("KEY6", $"{NR3}{NR}{NR4}{NR2}", "KEYCODE");
                    CLogger.Message("Hasta la próxima!.");
                    CLogger.NewLine();
                    CmdTrial();
                    break;
                default:
                    CLogger.ErrorMsg("'{0}' no es un comando valido.", Number);
                    CmdTable();
                    break;
            }

            #endregion
        }

        private static void Test()
        {
            CmdTable();
        }

        public static void MigrationLevelAccounts()
        {
            #region Migración de Nivel

            CLogger.NewLine();

            string old_user;
            string user;

            CLogger.Message("==================================================");
            CLogger.Message("Migración de Nivel");
            CLogger.Message("==================================================");
            CLogger.NewLine();
            CLogger.Consultation("Introduce el nick antiguo:");
            old_user = Console.ReadLine();

            ActionsDb.SearchOldAccount2(old_user);

            ActionsDb.Exp = Ini.Read($"LEVEL_{ActionsDb.OldLvl}", "EXPERIENCE");

            CLogger.Consultation("Introduce el nick actual:");
            user = Console.ReadLine();

            ActionsDb.SearchAccount(user);

            int value = ActionsDb.UpdateLvl();

            if (value >= 1)
            {
                CLogger.NewLine();
                CLogger.InfoMsg("Nivel de la cuenta ha sido migrada...");
                CmdTable();
            }

            Console.ReadKey(true);
            #endregion
        }

        public static void GenerarContraseña()
        {
            #region Generar Contraseña Encriptada
            string pass;
            string salt;

            CLogger.Consultation("Escriba la contraseña que desea encriptar:");
            pass = Console.ReadLine();

            CLogger.InfoMsg("Generando contraseña...");
            CLogger.NewLine();

            var newSalt = new byte[24];
            using (var csprng = new RNGCryptoServiceProvider())
                csprng.GetBytes(newSalt);

            var hash = new Rfc2898DeriveBytes(pass, newSalt, 24000).GetBytes(24);

            pass = Convert.ToBase64String(hash);
            salt = Convert.ToBase64String(newSalt);

            Console.WriteLine($"Contraseña: {pass}");
            Console.WriteLine($"Salt: {salt}");
            File.AppendAllText("pass.txt", $"Pw: {pass} {Environment.NewLine}");
            File.AppendAllText("pass.txt", $"Sal: {salt} {Environment.NewLine} {Environment.NewLine}");
            CmdTable();

            #endregion
        }

        public static void InsertarInTheShopAtk()
        {
            CLogger.NewLine();
            var table = Ini.Read("TABLE", "SHOPITEMS");
            string file = "Sql\\DatabasUpdates.sql";

            switch(table)
            {
                case "1":
                    File.AppendAllText(file, $"-- ------------------------------------------------------------------------------------------------- {Environment.NewLine}");
                    File.AppendAllText(file, $"-- - INSERT NEW ITEMS OF THE SHOP {DateTime.Now} {Environment.NewLine}");
                    File.AppendAllText(file, $"-- ------------------------------------------------------------------------------------------------- {Environment.NewLine} {Environment.NewLine}");
                    CLogger.NewLine();
                    CLogger.InfoMsg("==================================================");
                    CLogger.InfoMsg("AGREGANDO ITEMS A TABLA SHOPITEMS");
                    CLogger.InfoMsg("==================================================");

                    for (var x = int.Parse(Ini.Read("ITEM_1", "SHOPITEMS"));
                         x < int.Parse(Ini.Read("ITEM_2", "SHOPITEMS")); x += 4)
                    {
                        CLogger.InfoMsg("ITEM > {0}", x);
                        File.AppendAllText(file, string.Format("INSERT INTO shop_items (Id, RequiredGender, IsDestroyable, MainTab, SubTab) " +
                       "VALUES ('{0}', '0', '1', '1', '7');{1}", x, Environment.NewLine));
                    }

                    Ini.Write("TABLE", "2", "SHOPITEMS");
                    File.AppendAllText(file, $"{Environment.NewLine} {Environment.NewLine}");
                    CmdTable();
                    break;

                case "2":
                    File.AppendAllText(file, $"-- ------------------------------------------------------------------------------------------------- {Environment.NewLine}");
                    File.AppendAllText(file, $"-- - INSERT & ENABLED NEW ITEMS OF THE SHOP {DateTime.Now} {Environment.NewLine}");
                    File.AppendAllText(file, $"-- ------------------------------------------------------------------------------------------------- {Environment.NewLine} {Environment.NewLine}");
                    CLogger.NewLine();
                    CLogger.InfoMsg("==================================================");
                    CLogger.InfoMsg("AGREGANDO A TABLA SHOPITEMINFOS");
                    CLogger.InfoMsg("==================================================");

                    for (var x = int.Parse(Ini.Read("ITEM_1", "SHOPITEMS"));
                         x < int.Parse(Ini.Read("ITEM_2", "SHOPITEMS")); x += 4)
                    {
                        CLogger.InfoMsg("ITEM > {0}", x);
                        File.AppendAllText(file, string.Format("INSERT INTO shop_iteminfos (ShopItemId, PriceGroupId, EffectGroupId, IsEnabled) " +
                        "VALUES ('{0}', '22', '14', '1');{1}", x, Environment.NewLine));
                        //CmdTable();
                    }

                    Ini.Write("TABLE", "1", "SHOPITEMS");
                    File.AppendAllText(file, $"{Environment.NewLine} {Environment.NewLine}");
                    CmdTable();
                    break;

                case "3":
                    CLogger.NewLine();
                    CLogger.InfoMsg("==================================================");
                    CLogger.InfoMsg("AGREGANDO ITEMS A TABLA SHOPITEMS");
                    CLogger.InfoMsg("==================================================");

                    for (var x = int.Parse(Ini.Read("ITEM_1", "SHOPITEMS"));
                         x < int.Parse(Ini.Read("ITEM_2", "SHOPITEMS")); x++)
                    {
                        CLogger.InfoMsg("ITEM > {0}", x);

                        File.AppendAllText(file, string.Format("INSERT INTO shop_items (Id, RequiredGender, IsDestroyable, MainTab, SubTab) " +
                       "VALUES ('{0}', '0', '1', '1', '7');{1}", x, Environment.NewLine));
                    }

                    CmdTable();
                    break;

                case "4":
                    CLogger.NewLine();
                    CLogger.InfoMsg("==================================================");
                    CLogger.InfoMsg("AGREGANDO A TABLA SHOPITEMINFOS");
                    CLogger.InfoMsg("==================================================");

                    for (var x = int.Parse(Ini.Read("ITEM_1", "SHOPITEMS"));
                         x < int.Parse(Ini.Read("ITEM_2", "SHOPITEMS")); x++)
                    {
                        CLogger.InfoMsg("ITEM > {0}", x);
                        File.AppendAllText(file, string.Format("INSERT INTO shop_iteminfos (ShopItemId, PriceGroupId, EffectGroupId, IsEnabled) " +
                        "VALUES ('{0}', '22', '14', '1');{1}", x, Environment.NewLine));
                    }

                    CmdTable();
                    break;

                default:
                    CLogger.ErrorMsg("El número {0} no es correcto", table);
                    CmdTable();
                    break;
            }

            Console.ReadKey(true);
        }

        public static void SendCapsuleForMaintenance()
        {
            CLogger.NewLine();
            CLogger.InfoMsg("==================================================");
            CLogger.InfoMsg("INSERTANDO CAPSULAS");
            CLogger.InfoMsg("==================================================");

            for (var x = int.Parse(Ini.Read("Player", "CAPSULE_REWARD")); x < int.Parse(Ini.Read("PlayerM", "CAPSULE_REWARD")); x++)
            {
                CLogger.DebugMsg("PLAYER > {0}", x);
                ActionsDb.SendCapsuleReward(x);
                ActionsDb.SendCapsuleReward2(x);
            }

            CmdTable();

            Console.ReadKey(true);
        }
    }
}
