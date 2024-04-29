using System.Xml.Serialization;

namespace ManagerServer.Resource.Xml
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "Item_tooltip_addcapsule")]
    public class ItemCapsuleDto
    {
        [XmlElement("item")] public CapsuleInfoDto[] item { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class CapsuleInfoDto
    {
        [XmlAttribute] public uint id { get; set; }

        [XmlElement("capsule_icon")] public CapsuleIconInfoDto items { get; set; }

        [XmlElement("capsule_slot")] public CapsuleSlotInfoDto groups { get; set; }

        [XmlElement("capsule_info")] public CapsuleResultInfoDto results { get; set; }

        [XmlElement("color_index")] public CapsuleColorInfoDto colors { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class CapsuleIconInfoDto
    {
        [XmlAttribute] public uint ID_1 { get; set; }

        [XmlAttribute] public uint ID_2 { get; set; }

        [XmlAttribute] public uint ID_3 { get; set; }

        [XmlAttribute] public uint ID_4 { get; set; }

        [XmlAttribute] public uint ID_5 { get; set; }

        [XmlAttribute] public uint ID_6 { get; set; }

        [XmlAttribute] public uint ID_7 { get; set; }

        [XmlAttribute] public uint ID_8 { get; set; }

        [XmlAttribute] public uint ID_9 { get; set; }

        [XmlAttribute] public uint ID_10 { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class CapsuleSlotInfoDto
    {
        [XmlAttribute] public uint slot_1 { get; set; }

        [XmlAttribute] public uint slot_2 { get; set; }

        [XmlAttribute] public uint slot_3 { get; set; }

        [XmlAttribute] public uint slot_4 { get; set; }

        [XmlAttribute] public uint slot_5 { get; set; }

        [XmlAttribute] public uint slot_6 { get; set; }

        [XmlAttribute] public uint slot_7 { get; set; }

        [XmlAttribute] public uint slot_8 { get; set; }

        [XmlAttribute] public uint slot_9 { get; set; }

        [XmlAttribute] public uint slot_10 { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class CapsuleResultInfoDto
    {
        [XmlAttribute] public string effect_key_1 { get; set; }

        [XmlAttribute] public string effect_key_2 { get; set; }

        [XmlAttribute] public string effect_key_3 { get; set; }

        [XmlAttribute] public string effect_key_4 { get; set; }

        [XmlAttribute] public string effect_key_5 { get; set; }

        [XmlAttribute] public string effect_key_6 { get; set; }

        [XmlAttribute] public string effect_key_7 { get; set; }

        [XmlAttribute] public string effect_key_8 { get; set; }

        [XmlAttribute] public string effect_key_9 { get; set; }

        [XmlAttribute] public string effect_key_10 { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class CapsuleColorInfoDto
    {
        [XmlAttribute] public uint color_1 { get; set; }

        [XmlAttribute] public uint color_2 { get; set; }

        [XmlAttribute] public uint color_3 { get; set; }

        [XmlAttribute] public uint color_4 { get; set; }

        [XmlAttribute] public uint color_5 { get; set; }

        [XmlAttribute] public uint color_6 { get; set; }

        [XmlAttribute] public uint color_7 { get; set; }

        [XmlAttribute] public uint color_8 { get; set; }

        [XmlAttribute] public uint color_9 { get; set; }

        [XmlAttribute] public uint color_10 { get; set; }
    }
}
