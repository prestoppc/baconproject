using UnityEngine;
using System.Collections;
using System.IO;

public class PortugueseXMLCreation : MonoBehaviour
{
    // Use this for initialization
    /* This is where you will add the dialog for the game for the Portuguese dialog 
       Makes sure you format it just like this and add what you see below
       If you have questions or are confused about something contact me - Jeffrey Malesky for help*/
    void Start()
    {
        XML_PortugueseContainer dialogCollection = new XML_PortugueseContainer();
        XML_Portuguese testPush = new XML_Portuguese();
        testPush.DougOrAdamOrEnemy = "Doug";
        testPush.TypeOfAction = "Fucking Jorge";
        testPush.Dialog = "Jorge your butthole is so tight";
        dialogCollection.Dialogs.Add(testPush);
        dialogCollection.Save(Path.Combine("C:\\Users\\jmalesky\\Desktop\\BaconProject\\baconproject\\Bacon Project", "testXML.xml"));
    }
}
