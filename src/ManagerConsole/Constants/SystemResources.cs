using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleMJ.Constants
{
    public class SystemResources
    {
        private XmlDocument Document { get; set; }
        private XmlElement Element { get; set; }
        private XmlAttribute Attribute { get; set; }

        public int _value = 0;

        private readonly string s_path = @".\SystemResources.xml";

        internal SystemResources()
        {
            Document = new XmlDocument();
        }

        public int Id
        {
            get => _value;
            set
            {
                if (_value == value)
                    return;
                _value = value;
            }
        }

        public void InsertResourceFileAsync(string name, string date)
        {
            Document.Load(s_path);
            Element = Document.CreateElement("ResourceFile");
            Element.SetAttribute("id", Id++.ToString());
            Element.SetAttribute("name", name);
            Element.SetAttribute("date", date);
            Document.DocumentElement.AppendChild(Element);
            Document.Save(s_path);
        }
    }
}
