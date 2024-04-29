using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerServer.Complements
{
    public class S4EntryInfo
    {
        public string FileName { get; }
        public string FullName { get; }
        public string Extension { get; }
        public string Directory
        {
            get => Path.GetDirectoryName(FullName ?? AppDomain.CurrentDomain.BaseDirectory);
        }
        public byte[] FileBytes { get; }

        public S4EntryInfo(string fileName, string fullName, string extension, byte[] fileBytes)
        {
            FileName = fileName;
            FullName = fullName.Replace(Path.GetExtension(fullName), extension);
            Extension = extension;
            FileBytes = fileBytes;
        }
    }
}
