using System.Xml.Serialization;

namespace ManagerServer.Resource.Xml
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "S4_Effects")]
    public class DumpedEffectDto
    {
        [XmlElement("Effect")]
        public EffectsDto[] Effects { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class EffectsDto
    {
        [XmlAttribute]
        public uint ID { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public int Power_Level { get; set; }
    }
}
