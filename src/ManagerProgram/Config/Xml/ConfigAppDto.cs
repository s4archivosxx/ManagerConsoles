using System.Xml.Serialization;

namespace ManagerProgram.Resource.Xml
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "ConfigApp")]
    public class ConfigAppDto
    {
        [XmlElement("Program")]
        public Program[] Program { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class Program
    {
        [XmlAttribute]
        public int id { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public string url { get; set; }

        [XmlAttribute]
        public string args { get; set; }
    }
}
