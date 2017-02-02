using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("EnglishDialog")]
public class XML_EnglishContainer
{
    [XmlArray("English"), XmlArrayItem("Dialog")]
    public List<XML_English> Dialogs = new List<XML_English>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(XML_EnglishContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static XML_EnglishContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(XML_EnglishContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            return serializer.Deserialize(stream) as XML_EnglishContainer;
        }
    }
}

