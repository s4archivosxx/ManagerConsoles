//using Newtonsoft.Json;
//using Hjson;
//using System.IO;
//using System;

//namespace ConsoleMJ
//{
//    public class HjsonConfig
//    {
//        private static readonly string path = "MJConfig.hjson";
//        public string AccessFb { get; set; }
//        public string AccessS4LA { get; set; }
//        public static HjsonConfig Instance { get; }

//        //[JsonProperty("GeneratorKey")]
//        //public GeneratorKey GeneratorKey { get; set; }

//        [JsonProperty("DataBases")]
//        public DataBases DataBases { get; set; }

//        //[JsonProperty("Matchs")]
//        //public Matchs Matchs { get; set; }

//        static HjsonConfig()
//        {
//            if (!File.Exists(path))
//            {
//                Instance = new HjsonConfig();
//                Instance.Save();
//                return;
//            }

//            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
//                Instance = JsonConvert.DeserializeObject<HjsonConfig>(HjsonValue.Load(fs).ToString(Stringify.Plain));
//        }

//        public HjsonConfig()
//        {
//            AccessFb = "False";
//            AccessS4LA = "False";
//            // GeneratorKey = new GeneratorKey();
//            DataBases = new DataBases();
//            // Matchs = new Matchs();
//        }


//        public void Save()
//        {
//            var json = JsonConvert.SerializeObject(this, Formatting.None);
//            File.WriteAllText(path, JsonValue.Parse(json).ToString(Stringify.Hjson));
//        }

//        public void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
//        {
//            serializer.Serialize(writer, value.ToString());
//        }

//        public void ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
//        {
//            var str = serializer.Deserialize<string>(reader);
//            var arr = str.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
//            //return new IPEndPoint(IPAddress.Parse(arr[0]), int.Parse(arr[1]));
//        }
//    }

//    //public class GeneratorKey
//    //{
//    //    [JsonProperty("Key")]
//    //    public string Key { get; set; }

//    //    [JsonProperty("Key2")]
//    //    public string Key2 { get; set; }

//    //    [JsonProperty("Key3")]
//    //    public string Key3 { get; set; }

//    //    [JsonProperty("Key4")]
//    //    public string Key4 { get; set; }

//    //    [JsonProperty("Key5")]
//    //    public string Key5 { get; set; }

//    //    [JsonProperty("Key6")]
//    //    public string Key6 { get; set; }

//    //    public GeneratorKey()
//    //    {
//    //        Key = "";
//    //        Key2 = "";
//    //        Key3 = "";
//    //        Key4 = "";
//    //        Key5 = "";
//    //        Key6 = "";
//    //    }
//    //}

//    public class DataBases
//    {
//        [JsonProperty("Server")]
//        public string Server { get; set; }

//        [JsonProperty("Auth")]
//        public string Auth { get; set; }

//        [JsonProperty("Game")]
//        public string Game { get; set; }

//        public DataBases()
//        {
//            Server = "localhost";
//            Auth = "s4auth";
//            Game = "s4game";
//        }
//    }

//    //public class Matchs
//    //{
//    //    [JsonProperty("Player")]
//    //    public int Player { get; set; }

//    //    [JsonProperty("MaxPlayer")]
//    //    public int MaxPlayer { get; set; }

//    //    [JsonProperty("Count")]
//    //    public string Count { get; set; }

//    //    [JsonProperty("Mode")]
//    //    public string Mode { get; set; }

//    //    public Matchs()
//    //    {
//    //        Player = 0;
//    //        MaxPlayer = 0;
//    //        Count = "ALL";
//    //        Mode = "TD";
//    //    }
//    //}
//}
