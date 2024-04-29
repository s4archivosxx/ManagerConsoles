using System.Xml.Serialization;

namespace ManagerServer.Resource.Xml
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "Item_tooltip_base")]
    public class ItemToolTipBaseDto
    {
        [XmlElement("item")]
        public ItemToolTipBaseItemDto[] ItemDtos { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class ItemToolTipBaseItemDto
    {
        [XmlAttribute]
        public uint id { get; set; }

        public ItemToolTipBaseItemBaseDto @base { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class ItemToolTipBaseItemBaseDto
    {
        [XmlAttribute]
        public string diffi_key { get; set; }

        [XmlAttribute]
        public string effect_attrib_pen_key { get; set; }

        [XmlAttribute]
        public string effect_attrib_cash_key { get; set; }
    }
}
