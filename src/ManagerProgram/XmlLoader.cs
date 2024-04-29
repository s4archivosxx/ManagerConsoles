using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ManagerProgram.Resource.Xml;
using ManagerProgram.Resource;

namespace ManagerProgram.Loader
{
    public class XmlLoader
    {
        public string ResourcePath { get; }

        public XmlLoader(string Path)
        {
            ResourcePath = Path;
        }

        public IEnumerable<CProgram> GetConfigApp()
        {
            var dto = Deserialize<ConfigAppDto>("ConfigApp.xml");

            foreach (var func in dto.Program)
            {
                var cof = new CProgram
                {
                    Number = func.id,
                    Name = func.name,
                    Url = func.url,
                    ParamsS = func.args
                };

                yield return cof;
            }
        }

        private T Deserialize<T>(string fileName)
        {
            var serializer = new XmlSerializer(typeof(T));

            var path = Path.Combine(ResourcePath, fileName.Replace('/', Path.DirectorySeparatorChar));
            // var path = ResourcePath;
            using (var r = new StreamReader(path))
                return (T)serializer.Deserialize(r);
        }
    }
}
