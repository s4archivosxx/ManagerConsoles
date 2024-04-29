using System.Xml.Serialization;

namespace ManagerServer.Resource.Xml
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "DailyCapsules")]
    public class DailyCapsulesDto
    {
        [XmlElement("Capsule")]
        public CapsuleDto[] CapsuleDto { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class CapsuleDto
    {
        [XmlAttribute("item_number")]
        public uint ItemNumber { get; set; }

        [XmlAttribute("item_name")]
        public string ItemName { get; set; }

        [XmlAttribute("price_type")]
        public byte PriceType { get; set; }

        [XmlAttribute("period_type")]
        public byte PeriodType { get; set; }

        [XmlAttribute("period")]
        public byte Period { get; set; }

        [XmlAttribute("count")]
        public byte Count { get; set; }

        [XmlAttribute("chance_for_get")]
        public int ChanceForGet { get; set; }
    }
}
