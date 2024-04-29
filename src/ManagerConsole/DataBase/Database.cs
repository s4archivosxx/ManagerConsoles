using System;
using System.IO;
using LogMJ;
using MySql.Data.MySqlClient;
using static ConsoleMJ.Models;
using static ConsoleMJ.Program;

namespace ConsoleMJ
{
    public class Connection
    {
        private static IniFile _ini = new IniFile("ConsoleMJ.ini");
        public string Server { get; set; }
        public string User { get; set; }
        public string Pw { get; set; }
        public int Port { get; set; }
        public string AuthDb { get; set; }
        public string GameDb { get; set; }

        public Connection()
        {
            Server = "158.69.101.201"; // 158.69.101.201
            User = "s4new14789";
            Pw = "w5vH18JqoqyTgUY8/UEGKg==";
            Port = 3306;
        }

        public Connection(bool value)
        {
            Server = _ini.Read("Server", "DATABASE"); // 158.69.101.201
            User = "root";
            Pw = "1478";
            Port = 3306;
            AuthDb = _ini.Read("AuthDb", "DATABASE");
            GameDb = _ini.Read("GameDb", "DATABASE");
        }

        public static MySqlConnection Database()
        {
            Connection config = new Connection();

            MySqlConnection mysqlCon = new MySqlConnection($"SslMode=none;Server={config.Server};Port={config.Port};Database=s9db;Uid={config.User};pwd={config.Pw};Pooling=false;");
            mysqlCon.Open();

            return mysqlCon;
        }

        public static MySqlConnection Database2()
        {
            Connection config = new Connection(true);

            MySqlConnection mysqlCon = new MySqlConnection($"SslMode=none;Server={config.Server};Port={config.Port};Database=s9db;Uid={config.User};pwd={config.Pw};Pooling=false;");
            mysqlCon.Open();

            return mysqlCon;
        }

        public static MySqlConnection Database3()
        {
            MySqlConnection mysqlCon = new MySqlConnection($"SslMode=none;Server=localhost;Port=3306;Database=s9db;Uid=root;pwd=qPm/WpIrxArsXvwK7mCHJw==;Pooling=false;");
            mysqlCon.Open();

            return mysqlCon;
        }

        public static MySqlConnection Database4()
        {
            MySqlConnection mysqlCon = new MySqlConnection($"SslMode=none;Server=localhost;Port=3306;Database=s9db2;Uid=root;pwd=qPm/WpIrxArsXvwK7mCHJw==;Pooling=false;");
            mysqlCon.Open();

            return mysqlCon;
        }

        public static MySqlConnection Auth()
        {
            Connection config = new Connection(true);

            MySqlConnection mysqlCon = new MySqlConnection($"SslMode=none;Server={config.Server};Port={config.Port};Database={config.AuthDb};Uid={config.User};pwd={config.Pw};Pooling=true;");
            mysqlCon.Open();

            return mysqlCon;
        }

        public static MySqlConnection Game()
        {
            Connection config = new Connection(true);

            MySqlConnection mysqlCon = new MySqlConnection($"SslMode=none;Server={config.Server};Port={config.Port};Database={config.GameDb};Uid={config.User};pwd={config.Pw};Pooling=false;");
            mysqlCon.Open();

            return mysqlCon;
        }
    }

    public class ActionsDb
    {
        private static IniFile _ini = new IniFile("ConsoleMJ.ini");
        public static CLogger Logger { get; set; } = new CLogger("Console.log");
        public static MySqlCommand _cmd { get; set; }
        public static MySqlDataReader _mdr { get; set; }
        public static int OldId { get; set; }
        public static uint Id { get; set; }
        public static string OldLvl { get; set; }
        public static string Exp { get; set; }

        public static string _path = "Sql\\MigrationUsers.sql";


        public static void SearchItems(string id, string name, string colors)
        {
            _cmd = new MySqlCommand($"SELECT * FROM shop_items WHERE (Id='{id}')", Connection.Database());
            _mdr = _cmd.ExecuteReader();

            switch (_mdr.Read())
            {
                case true:
                    Logger.InfoMsg("IsCorrect: {0} | Name: {1} | Colors: {2}", id, name, colors);
                    break;

                case false:
                    Logger.InfoMsg("NoIsCorrect: {0}", id);
                    break;
            }
        }

        /// <summary>
        /// Inserta los registros de los usuarios
        /// </summary>
        /// <param name="_user">nombre de usuario</param>
        /// <param name="_nick">apado</param>
        /// <param name="_pw">contraseña encriptada</param>
        /// <param name="_pw2">contraseña desencriptada</param>
        /// <param name="_email">correo electronico</param>
        /// <returns></returns>
        public static int SigUp(Account account)
        {
            int value = 0;

            //MySqlCommand _cmd = new MySqlCommand(string.Format("INSERT INTO accounts VALUES ('','{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '0', '', '', '', '')", _user, _nick, _pw, _pw2, _pw3, _email), Connection.Database());

            MySqlCommand _cmd = new MySqlCommand(string.Format("INSERT INTO accounts(Username,Nickname,Password,Salt,Password2,Email)" +
                "VALUES ('{0}','{1}', '{2}', '{3}', '{4}', '{5}')", account.Username, account.Nickname, account.Password, account.Salt,
                account.Password2, account.Email), Connection.Database());

            value = _cmd.ExecuteNonQuery();
            Connection.Database().Close();

            return value;
        }

        public static void SearchOldAccount(string nick)
        {
            try
            {
                MySqlCommand _cmd = new MySqlCommand(string.Format("SELECT * FROM accounts WHERE Nickname='{0}'", nick), Connection.Auth());

                _mdr = _cmd.ExecuteReader();

                if (_mdr.Read())
                {
                    Console.WriteLine("");
                    Logger.InfoMsg("Antiguo Id({0})", _mdr.GetInt32(0));
                    Logger.InfoMsg("Antiguo Username({0})", _mdr.GetString(1));
                    // Console.WriteLine("");
                    OldId = _mdr.GetInt32(0);

                    //SearchOldLvlAccount(OldId);

                    SearchItems(OldId);
                }
                else
                {
                    Logger.WarnMsg("No se ha podido encontrar al usuario.");
                    CmdTable();
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg(ex.Message);
                CmdTable();
            }
        }

        public static void SearchOldAccount2(string nick)
        {
            try
            {
                MySqlCommand _cmd = new MySqlCommand(string.Format("SELECT * FROM accounts WHERE Nickname='{0}'", nick), Connection.Auth());

                _mdr = _cmd.ExecuteReader();

                if (_mdr.Read())
                {
                    Console.WriteLine("");
                    Logger.InfoMsg("Antiguo Id({0})", _mdr.GetInt32(0));
                    Logger.InfoMsg("Antiguo Username({0})", _mdr.GetString(1));
                    // Console.WriteLine("");
                    OldId = _mdr.GetInt32(0);

                    SearchOldLvlAccount(OldId.ToString());
                }
                else
                {
                    Logger.WarnMsg("No se ha podido encontrar al usuario.");
                    CmdTable();
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg(ex.Message);
                //CloseConnections();
                CmdTable();
            }
        }

        public static void SearchItems(int id)
        {
            try
            {
                _cmd = new MySqlCommand(string.Format("SELECT * FROM player_items WHERE PlayerId = '{0}'", id), Connection.Game());

                _mdr = _cmd.ExecuteReader();

                while (_mdr.Read())
                {
                    Logger.InfoMsg("ShopItemInfoId({0}): {1}", id, _mdr.GetInt32(2));
                    _items.Add(_mdr.GetInt32(2));
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg("{0}", ex.Message);
                CmdTable();
            }
        }

        public static void SearchShopItems(long itemid)
        {
            try
            {
                _cmd = new MySqlCommand(string.Format("SELECT * FROM shop_iteminfos WHERE Id = '{0}'", itemid), Connection.Game());

                _mdr = _cmd.ExecuteReader();

                while (_mdr.Read())
                {
                    Logger.InfoMsg("ShopItemId({0}): {1}", itemid, _mdr.GetInt32(1));
                    _itemsid.Add(_mdr.GetInt32(1));
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg("{0}", ex.Message);
                CmdTable();
            }
        }

        public static void SearchShopItemsId(long iditem)
        {
            try
            {
                int DurationInSeconds = 0;
                var duration = TimeSpan.FromSeconds(DurationInSeconds);

                _cmd = new MySqlCommand(string.Format("SELECT * FROM shop_iteminfos WHERE ShopItemId = '{0}'", iditem), Connection.Database2());

                _mdr = _cmd.ExecuteReader();

                while (_mdr.Read())
                {
                    Logger.InfoMsg("ItemId({0}): {1}", iditem, _mdr.GetInt32(0));

                    switch (_mdr.GetInt32(3))
                    {
                        case 14:
                            Logger.InfoMsg("None({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '6', '0', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 15:
                            Logger.InfoMsg("Shooting Weapon Defe({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '26', '1100313002, 1100315002, 1100317002', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 16:
                            Logger.InfoMsg("SP+6({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '27', '1101301006', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 17:
                            Logger.InfoMsg("Attack+1%({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '6', '1102303001', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 18:
                            Logger.InfoMsg("Attack+5%({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '28', '1102303003', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 20:
                            Logger.InfoMsg("Defense+5%({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '29', '1103302004', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 21:
                            Logger.InfoMsg("HP+4 S({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '30', '1105300004', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 22:
                            Logger.InfoMsg("HP+30({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '6', '1999300011', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 23:
                            Logger.InfoMsg("HP+15({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '6', '1999300009', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 24:
                            Logger.InfoMsg("SP+40({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '6', '1300301012', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 25:
                            Logger.InfoMsg("HP+20 & SP+20({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1999300010, 1999301011', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 26:
                            Logger.InfoMsg("HP+25 & SP+25({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1999300012, 1999301013', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 27:
                            Logger.InfoMsg("Defense Head +15%({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1100313007, 1100315007, 1100317007, 1100800001', '1', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 28:
                            Logger.InfoMsg("SP+8, EXP+5% F({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1101301008, 1101800001', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 29:
                            Logger.InfoMsg("Attack+12%, EXP+5%({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1102303008, 1102800001', '1', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 30:
                            Logger.InfoMsg("Defense+14%, EXP+5%({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1103302009, 1103800001', '1', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 31:
                            Logger.InfoMsg("HP+8, EXP+5% G({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1104300008, 1104800001', '1', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 32:
                            Logger.InfoMsg("HP+8, EXP+5% S({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1105300008, 1105800001', '1', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 33:
                            Logger.InfoMsg("SP+8, EXP+5% A({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1106301008, 1106800001', '1', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 34:
                            Logger.InfoMsg("Move Speed+1, SP+6({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1107301006, 1107302002, 1107307001, 1107800000', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 35:
                            Logger.InfoMsg("Melee Weapon FP({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1299600007, 1299602002, 1208300005, 1208301005', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 36:
                            Logger.InfoMsg("Rifle Weapon FP({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1299600007, 1299602002, 1208300005, 1208301005', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 37:
                            Logger.InfoMsg("Guns Weapon FP({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1299600007, 1299602002, 1208300005, 1208301005', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 38:
                            Logger.InfoMsg("Heavy Gun FP({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1299600007, 1299602002, 1208300005, 1208301005', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 39:
                            Logger.InfoMsg("Snipe Force FP({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1299600007, 1299602002, 1208300005, 1208301005', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 40:
                            Logger.InfoMsg("Mental Weapon FP({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1299600007, 1299602002, 1208300005, 1208301005', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 41:
                            Logger.InfoMsg("Stationary Weapon FP({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1299600007, 1299602002, 1206308001, 1206601001', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 42:
                            Logger.InfoMsg("Throwing Weapon FP({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1299600007, 1299602002, 1208300005, 1208301005', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 43:
                            Logger.InfoMsg("Throwing Weapon FP 2({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1299600007, 1299602002, 1208300005, 1208301005', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;

                        case 44:
                            Logger.InfoMsg("Special Forcepack({0})", _mdr.GetInt32(1));
                            Logger.InfoMsg("Añadiendo al archivo {0}...", _path);
                            File.AppendAllText(_path, string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, Color, PurchaseDate, Durability)" +
                                " VALUES ('{0}', '{1}', '34', '1299600007, 1299602002, 1208300005, 1208301005', '0', '{2}', '1000000'); {3}", OldId, _mdr.GetInt32(0), DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), Environment.NewLine));
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg(ex.Message);
                CmdTable();
            }
        }

        public static void SearchMatchsModeTD(int id)
        {
            try
            {
                _cmd = new MySqlCommand(string.Format("SELECT * FROM player_info_touchdown WHERE (PlayerId='{0}')", id), Connection.Database4());
                _mdr = _cmd.ExecuteReader();

                while (_mdr.Read())
                {
                    Logger.InfoMsg("PlayerId({0}) | TouchDown Local Matches({1})", id, _mdr.GetInt32(1));
                    PlayerInfosTD.MatchsL = _mdr.GetInt32(1);
                    PlayerInfosTD.Id = _mdr.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg(ex.Message);
                CmdTable();
            }
        }

        public static void SearchMatchsModeTD2(int id)
        {
            try
            {
                _cmd = new MySqlCommand(string.Format("SELECT * FROM player_info_touchdown WHERE (PlayerId='{0}')", id), Connection.Database3());
                _mdr = _cmd.ExecuteReader();

                while (_mdr.Read())
                {
                    // Logger.InfoMsg("TD Matchs({0}): {1}", Id, _mdr.GetUInt32(1));
                    Logger.InfoMsg("PlayerId({0}) | TouchDown Server Matches({1})", id, _mdr.GetInt32(1));
                    PlayerInfosTD.Matchs = _mdr.GetInt32(1);
                    PlayerInfosTD.Id = _mdr.GetInt32(0);

                    CountMatchs(PlayerInfosTD.MatchsL, PlayerInfosTD.Matchs, PlayerInfosTD.Id);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg(ex.Message);
                CmdTable();
            }
        }

        public static void SearchMatchsModeDM(int id)
        {
            try
            {
                _cmd = new MySqlCommand(string.Format("SELECT * FROM player_info_deathmatch WHERE (PlayerId='{0}')", id), Connection.Database4());
                _mdr = _cmd.ExecuteReader();

                while (_mdr.Read())
                {
                    Logger.InfoMsg("PlayerId({0}) | DeathMatch Local Matches({1})", id, _mdr.GetInt32(1));
                    PlayerInfosDM.MatchsL = _mdr.GetInt32(1);
                    PlayerInfosDM.Id = _mdr.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg(ex.Message);
                CmdTable();
            }
        }

        public static void SearchMatchsModeDM2(int id)
        {
            try
            {
                _cmd = new MySqlCommand(string.Format("SELECT * FROM player_info_deathmatch WHERE (PlayerId='{0}')", id), Connection.Database3());
                _mdr = _cmd.ExecuteReader();

                while (_mdr.Read())
                {
                    Logger.InfoMsg("PlayerId({0}) | DeathMatch Server Matches({1})", id, _mdr.GetInt32(1));
                    PlayerInfosDM.Matchs = _mdr.GetInt32(1);
                    PlayerInfosDM.Id = _mdr.GetInt32(0);

                    CountMatchs(PlayerInfosDM.MatchsL, PlayerInfosDM.Matchs, PlayerInfosDM.Id);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg(ex.Message);
                CmdTable();
            }
        }

        public static void SearchMatchsModeBR(int id)
        {
            try
            {
                _cmd = new MySqlCommand(string.Format("SELECT * FROM player_info_battleroyal WHERE (PlayerId='{0}')", id), Connection.Database4());
                _mdr = _cmd.ExecuteReader();

                while (_mdr.Read())
                {
                    Logger.InfoMsg("PlayerId({0}) | Battle Royal Local Matches({1})", id, _mdr.GetInt32(1));
                    PlayerInfosBR.MatchsL = _mdr.GetInt32(1);
                    PlayerInfosBR.Id = _mdr.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg(ex.Message);
                CmdTable();
            }
        }

        public static void SearchMatchsModeBR2(int id)
        {
            try
            {
                _cmd = new MySqlCommand(string.Format("SELECT * FROM player_info_battleroyal WHERE (PlayerId='{0}')", id), Connection.Database3());
                _mdr = _cmd.ExecuteReader();

                while (_mdr.Read())
                {
                    Logger.InfoMsg("PlayerId({0}) | Battle Royal Server Matches({1})", id, _mdr.GetInt32(1));
                    PlayerInfosBR.Matchs = _mdr.GetInt32(1);
                    PlayerInfosBR.Id = _mdr.GetInt32(0);

                    CountMatchs(PlayerInfosBR.MatchsL, PlayerInfosBR.Matchs, PlayerInfosBR.Id);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg(ex.Message);
                CmdTable();
            }
        }

        public static void SearchMatchsModeSL(int id)
        {
            try
            {
                _cmd = new MySqlCommand(string.Format("SELECT * FROM player_info_chaser WHERE (PlayerId='{0}')", id), Connection.Database4());
                _mdr = _cmd.ExecuteReader();

                while (_mdr.Read())
                {
                    Logger.InfoMsg("PlayerId({0}) | Chaser Local Matches({1})", id, _mdr.GetInt32(1));
                    PlayerInfosChaser.MatchsL = _mdr.GetInt32(1);
                    PlayerInfosChaser.Id = _mdr.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg(ex.Message);
                CmdTable();
            }
        }

        public static void SearchMatchsModeSL2(int id)
        {
            try
            {
                _cmd = new MySqlCommand(string.Format("SELECT * FROM player_info_chaser WHERE (PlayerId='{0}')", id), Connection.Database3());
                _mdr = _cmd.ExecuteReader();

                while (_mdr.Read())
                {
                    Logger.InfoMsg("PlayerId({0}) | Chaser Server Matches({1})", id, _mdr.GetInt32(1));
                    PlayerInfosChaser.Matchs = _mdr.GetInt32(1);
                    PlayerInfosChaser.Id = _mdr.GetInt32(0);

                    CountMatchs(PlayerInfosChaser.MatchsL, PlayerInfosChaser.Matchs, PlayerInfosChaser.Id);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg(ex.Message);
                CmdTable();
            }
        }

        public static void SearchPlayers(int Id)
        {
            try
            {
                _cmd = new MySqlCommand(string.Format("SELECT * FROM players WHERE Id = '{0}'", Id), Connection.Database2());

                _mdr = _cmd.ExecuteReader();

                if (_mdr.Read())
                {
                    Logger.InfoMsg("Player({0})", _mdr.GetString(0));
                    Logger.InfoMsg("PEN({0})", _mdr.GetString(5));
                    Players.Id = (ulong)_mdr.GetInt32(0);
                    Players.PEN = _mdr.GetUInt32(5);

                    SearchAmountToPlayers((int)Players.PEN, (int)Players.Id);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg(ex.Message);
                CmdTable();
            }
        }

        public static void UpdatingPEN(int PEN, int Id)
        {
            try
            {
                _cmd = new MySqlCommand(string.Format("UPDATE players SET PEN='{0}' WHERE Id='{1}'", PEN, Id), Connection.Database2());
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg(ex.Message);
                CmdTable();
            }
        }

        public static void SearchAccount(string nick)
        {
            try
            {
                MySqlCommand _cmd = new MySqlCommand(string.Format("SELECT * FROM accounts WHERE Nickname='{0}'", nick), Connection.Database());

                _mdr = _cmd.ExecuteReader();

                if (_mdr.Read())
                {
                    Console.WriteLine("");
                    Logger.InfoMsg("Actual Id: {0}", _mdr.GetInt32(0));
                    Logger.InfoMsg("Actual Username: {0}", _mdr.GetString("Username"));
                    Id = (uint)_mdr.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg(ex.Message);
                CmdTable();
            }
        }

        public static void SearchOldLvlAccount(string id)
        {
            try
            {
                MySqlCommand _cmd = new MySqlCommand(string.Format("SELECT * FROM players WHERE Id='{0}'", id), Connection.Game());

                _mdr = _cmd.ExecuteReader();

                if (_mdr.Read())
                {
                    //Console.WriteLine("");
                    Logger.InfoMsg("Antiguo Level: {0}", _mdr.GetString("Level"));
                    Logger.InfoMsg("Antiguo TotalExperience: {0}", _mdr.GetString("TotalExperience"));
                    Console.WriteLine("");
                    OldLvl = _mdr.GetString("Level");
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg(ex.Message);
                CmdTable();
            }
        }

        public static int SendCapsuleReward(int _plr)
        {
            try
            {
                int DurationInSeconds = 0;
                var duration = TimeSpan.FromSeconds(DurationInSeconds);

                int value = 0;

                _cmd = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}','{1}','11', '0', '{2}', '1', '{3}')", _plr, _ini.Read("Id", "CAPSULE_REWARD"),
                    DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), _ini.Read("Count", "CAPSULE_REWARD")), Connection.Database());

                value = _cmd.ExecuteNonQuery();

                return value;
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg("{0}", ex.Message);
                CmdTable();
                return 0;
            }
        }

        public static void EventRotationTD(int Id)
        {
            try
            {
                var duration = TimeSpan.FromSeconds(0);

                _cmd = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}','4814', '12', '0', '{1}', '1', '30')", Id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd.ExecuteNonQuery();

                MySqlCommand _cmd2 = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}','4815', '12', '0', '{1}', '1', '30')", Id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd2.ExecuteNonQuery();

                MySqlCommand _cmd3 = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}','4816', '12', '0', '{1}', '1', '25')", Id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd3.ExecuteNonQuery();

                MySqlCommand _cmd4 = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}','4515', '12', '0', '{1}', '1', '25')", Id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd4.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg("{0}", ex.Message);
                CmdTable();
            }
        }

        public static void EventRotationDM(int Id)
        {
            try
            {
                var duration = TimeSpan.FromSeconds(0);

                _cmd = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}','4798', '12', '0', '{1}', '1', '30')", Id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd.ExecuteNonQuery();

                MySqlCommand _cmd2 = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}','4908', '12', '0', '{1}', '1', '30')", Id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd2.ExecuteNonQuery();

                MySqlCommand _cmd3 = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}','4817', '12', '0', '{1}', '1', '25')", Id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd3.ExecuteNonQuery();

                MySqlCommand _cmd4 = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}','4506', '12', '0', '{1}', '1', '25')", Id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd4.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg("{0}", ex.Message);
                CmdTable();
            }
        }

        public static void EventRotationBR(int Id)
        {
            try
            {
                var duration = TimeSpan.FromSeconds(0);

                _cmd = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}','4800', '12', '0', '{1}', '1', '30')", Id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd.ExecuteNonQuery();

                MySqlCommand _cmd2 = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}','4793', '12', '0', '{1}', '1', '25')", Id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd2.ExecuteNonQuery();

                MySqlCommand _cmd3 = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}','4900', '12', '0', '{1}', '1', '25')", Id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd3.ExecuteNonQuery();

                MySqlCommand _cmd4 = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}','4901', '11', '0', '{1}', '1', '25')", Id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd4.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg("{0}", ex.Message);
                CmdTable();
            }
        }

        public static void EventRotationSL(int Id)
        {
            try
            {
                var duration = TimeSpan.FromSeconds(0);

                _cmd = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}', '4792', '12', '0', '{1}', '1', '30')", Id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd.ExecuteNonQuery();

                MySqlCommand _cmd2 = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}', '4902', '12', '0', '{1}', '1', '30')", Id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd2.ExecuteNonQuery();

                MySqlCommand _cmd3 = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}', '4588', '12', '0', '{1}', '1', '25')", Id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd3.ExecuteNonQuery();

                MySqlCommand _cmd4 = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}', '4870', '12', '0', '{1}', '1', '25')", Id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd4.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg("{0}", ex.Message);
                CmdTable();
            }
        }

        public static void ExtraRotation(int id)
        {
            try
            {
                var duration = TimeSpan.FromSeconds(0);

                _cmd = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}', '5304', '34', '1104300008,1104800001', '{1}', '1000000', '0')", id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd.ExecuteNonQuery();

                MySqlCommand _cmd2 = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}', '5302', '34', '1104300008,1104800001', '{1}', '1000000', '0')", id, DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds()), Connection.Database3());

                _cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg("{0}", ex.Message);
                CmdTable();
            }
        }

        public static int SendCapsuleReward2(int _plr)
        {
            try
            {
                int DurationInSeconds = 0;
                var duration = TimeSpan.FromSeconds(DurationInSeconds);

                int value = 0;

                _cmd = new MySqlCommand(string.Format("INSERT INTO player_items (PlayerId, ShopItemInfoId, ShopPriceId, Effects, PurchaseDate, Durability, Count)" +
                    "VALUES ('{0}','{1}','11', '0', '{2}', '1', '{3}')", _plr, _ini.Read("Id2", "CAPSULE_REWARD"),
                    DateTimeOffset.Now.Add(duration).ToUnixTimeSeconds(), _ini.Read("Count", "CAPSULE_REWARD")), Connection.Database());

                value = _cmd.ExecuteNonQuery();

                return value;
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg(ex.Message);
                CmdTable();
                return 0;
            }
        }

        public static int UpdateLvl()
        {
            try
            {
                int value = 0;

                MySqlCommand _cmd = new MySqlCommand(string.Format("UPDATE players SET Level='{0}', TotalExperience='{1}', PEN='{2}', AP='{3}' WHERE Id='{4}'", 
                    OldLvl, Exp, _ini.Read("PEN", "MIGRATION_LVL"), _ini.Read("AP", "MIGRATION_LVL"), Id), Connection.Database());

                value = _cmd.ExecuteNonQuery();

                return value;
            }
            catch (Exception ex)
            {
                Logger.ErrorMsg("{0}", ex.Message);
                //CloseConnections();
                CmdTable();
                return 0;
            }
        }
    }

    public class Models
    {
        public class Account
        {
            public static long Id { get; set; }
            public string Username { get; set; }
            public string Nickname { get; set; }
            public string Password { get; set; }
            public string Salt { get; set; }
            public string Password2 { get; set; }
            public string Email { get; set; }
        }

        public class AccountS
        {
            public static int Id { get; set; }
            public static string Username { get; set; }
            public static string Nickname { get; set; }
        }

        public class Players
        {
            public static ulong Id { get; set; }
            public static uint PEN { get; set; }
        }

        public class PlayerInfosDM
        {
            public static int Id { get; set; }
            public static int MatchsL { get; set; }
            public static int Matchs { get; set; }
        }

        public class PlayerInfosTD
        {
            public static int Id { get; set; }
            public static int MatchsL { get; set; }
            public static int Matchs { get; set; }
        }

        public class PlayerInfosBR
        {
            public static int Id { get; set; }
            public static int MatchsL { get; set; }
            public static int Matchs { get; set; }
        }

        public class PlayerInfosChaser
        {
            public static int Id { get; set; }
            public static int MatchsL { get; set; }
            public static int Matchs { get; set; }
        }
    }
}
