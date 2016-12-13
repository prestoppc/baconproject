using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/*
    Author: Keisuke Miyazaki
    Date: December 2, 2016
    E-mail: mintymiyazaki@yahoo.co.jp
    Purpose: To provide a save system for CelleC C# Unity Projects
    Notes: Available in C++, C#, and Java, English, Japanese, and Mandarin upon request

    Description: This is the actual save process.
*/

public static class SaveLoad
{
    // This grabs and sets the current data.
    public static SaveLoadManagement m_savedGames = new SaveLoadManagement();

    // This is where saving data happens.
    // To Access this function in your project code, call --> SaveLoad.Save();
    public static void Save()
    {
        m_savedGames = SaveLoadManagement.m_current;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Francisco.InABox");
        bf.Serialize(file, SaveLoad.m_savedGames);
        file.Close();
    }

    // This is where loading data happens.
    // To Access this function in your project code, call --> SaveLoad.Load();
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Francisco.InABox"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Francisco.InABox", FileMode.Open);
            SaveLoad.m_savedGames = (SaveLoadManagement)bf.Deserialize(file);
            file.Close();
        }
    }
}