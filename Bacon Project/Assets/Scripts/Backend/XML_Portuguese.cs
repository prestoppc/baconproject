using System.Xml;
using System.Xml.Serialization;

public class XML_Portuguese
{
    [XmlAttribute("Doug or Adam or Enemy")]
    public string DougOrAdamOrEnemy;

    [XmlAttribute("TypeOfAction")]
    public string TypeOfAction;

    [XmlElement("Dialog")]
    public string Dialog;
}
