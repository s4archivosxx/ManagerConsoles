using System.Xml.Serialization;

namespace ManagerServer.Resource.Xml
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "KeyCount")]
    public class KeyCountDto
    {
        [XmlAttribute]
        public int TotalCount { get; set; }

        [XmlElement("String")]
        public StringDto[] StringDto { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class StringDto
    {
        [XmlAttribute]
        public string SceneFile { get; set; }

        [XmlAttribute]
        public int SceneCount { get; set; }
    }
}
