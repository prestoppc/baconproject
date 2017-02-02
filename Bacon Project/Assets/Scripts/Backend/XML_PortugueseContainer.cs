using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("PortugueseDialog")]

public class XML_PortugueseContainer
{

    [XmlArray("Portuguese"), XmlArrayItem("Dialog")]
    public List<XML_Portuguese> Dialogs = new List<XML_Portuguese>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(XML_PortugueseContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static XML_PortugueseContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(XML_PortugueseContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            return serializer.Deserialize(stream) as XML_PortugueseContainer;
        }
    }
}
