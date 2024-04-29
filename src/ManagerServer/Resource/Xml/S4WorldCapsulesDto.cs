using System.Xml.Serialization;

namespace ManagerServer.Resource.Xml
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "s4_world")]
    public class S4WorldDto
    {
        [XmlElement("capsules")]
        public WorldCapsulesDto WorldCapsules { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class WorldCapsulesDto
    {
        [XmlElement("category")]
        public WorldCategoryDto[] CapsuleCategories { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class WorldCategoryDto
    {
        [XmlAttribute]
        public string type { get; set; }

        [XmlAttribute]
        public int total { get; set; }

        [XmlElement("item_capsule")]
        public WorldItemCapsuleDto[] WorldItems { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class WorldItemCapsuleDto
    {
        [XmlAttribute]
        public uint item_key { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlElement("item_content")]
        public WorldItemContentDto[] worldItemContentDto { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class WorldItemContentDto
    {
        [XmlAttribute]
        public uint key { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlElement]
        public uint priceType { get; set; }

        [XmlElement]
        public byte color { get; set; }

        [XmlElement]
        public uint previewEffect { get; set; }
    }
}
