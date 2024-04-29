using System;
using System.IO;
using LogMJ;

namespace ConsoleMJ
{
    internal class Funtions
    {
        public static Funtions GetFuntions { get; set; }
        private CLogger CLogger { get; set; }

        public Funtions()
        {
            CLogger = new CLogger("Console.log");
        }

        public static void Initializate() => GetFuntions = new Funtions();

        public void ReadFile(string file)
        {
            var info = new FileInfo(file);
            // var dateUpd = info.LastWriteTime.Day + "/" + info.LastWriteTime.Month + " " + info.LastWriteTime.Minute + ":" + info.LastWriteTime.Second;
            var dateUpd = info.LastWriteTime.ToString("yyyy.MM.dd HH:mm");

            // CLogger.InfoMsg("FullName: {0}", info.FullName);
            CLogger.InfoMsg("Name: {0}", info.Name);
            CLogger.InfoMsg("Attributes: {0}", info.Attributes);
            // CLogger.InfoMsg("Directory: {0}", info.Directory);
            // CLogger.InfoMsg("DirectoryName: {0}", info.DirectoryName);
            CLogger.InfoMsg("Extension: {0}", info.Extension);
            CLogger.InfoMsg("IsReadOnly: {0}", info.IsReadOnly.ToString());
            CLogger.InfoMsg("Date Upd: {0}", dateUpd);
            CLogger.InfoMsg("LasWriteTime: {0}", info.LastWriteTime);
            CLogger.InfoMsg("LasWriteTimeUtc: {0}", info.LastWriteTimeUtc);
            CLogger.InfoMsg("LastAccessTime: {0}", info.LastAccessTime);
            CLogger.InfoMsg("LastAccessTimeUtc: {0}", info.LastAccessTimeUtc);
            CLogger.InfoMsg("Length: {0} KB", info.Length);
        }
    }
}
