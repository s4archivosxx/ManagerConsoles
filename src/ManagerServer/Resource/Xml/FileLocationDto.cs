using System.Xml.Serialization;

namespace ManagerServer.Resource.Xml
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "FILELIST")]
    public class FileLocationDto
    {
        [XmlElement("LOCATION")]
        public LocationDto[] LocationDto { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class LocationDto
    {
        [XmlAttribute]
        public string FileName { get; set; }

        [XmlAttribute]
        public string Directory { get; set; }
    }
}
