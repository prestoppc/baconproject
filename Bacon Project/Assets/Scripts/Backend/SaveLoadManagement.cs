using UnityEngine;
using System.Collections;

/*
    Author: Keisuke Miyazaki
    Date: December 2, 2016
    E-mail: mintymiyazaki@yahoo.co.jp
    Purpose: To provide a save system for CelleC C# Unity Projects
    Notes: Available in C++, C#, and Java, English, Japanese, and Mandarin upon request

    Description: This is where the information that will be sent to the SaveLoad.cs script
*/

[System.Serializable]
public class SaveLoadManagement
{
    // This is the current status of the game
    public static SaveLoadManagement m_current;

    // Consider these data slots. 
    // You can have as many as you want, just don't turn this into an array or it will break things.
    public SaveLoadData m_data0, m_data1, m_data2, m_data3;

    // Consider this the data slot for user settings
    // You can have as many of these as you like if you want to save different settings for different users.
    // All the data here can easily be put into SaveLoadData, but for the sake of an example, this is just an example for using multiple
    // save files.
    public SaveLoadSettings m_settingsData;

    // I just have this here as a paranoid check.
    public static int m_loadSlot = -1;

    // Assigning each data slot with information if it exists.
    public SaveLoadManagement()
    {
        // Slots 1-3
        m_data0 = new SaveLoadData();
        m_data1 = new SaveLoadData();
        m_data2 = new SaveLoadData();

        // Game Settings slot.
        m_settingsData = new SaveLoadSettings();
    }

    /* Sample Code

    // This is how you access the current game information

    // Storing a saved value

    string sampleString;
    sampleString = SaveLoadManagement.m_current.m_data1.sceneName;

    // Writing to a saved value

    sampleString = "Cake";
    SaveLoadManagement.m_current.mdata1.sceneName = sampleString;

    // To Save Data write
    SaveLoad.Save();

    // To Load Data write
    SaveLoad.Load();

    */
}