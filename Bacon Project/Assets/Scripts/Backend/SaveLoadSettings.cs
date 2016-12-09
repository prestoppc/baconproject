using UnityEngine;
using System.Collections;

/*
    Author: Keisuke Miyazaki
    Date: December 2, 2016
    E-mail: mintymiyazaki@yahoo.co.jp
    Purpose: To provide a save system for CelleC C# Unity Projects
    Notes: Available in C++, C#, and Java, English, Japanese, and Mandarin upon request

    Description: This is just a template for additional options pertaining to user settings.
*/

[System.Serializable]
public class SaveLoadSettings
{
    //keybinds
    //brightness
    //languages

    // Providing two floats for audio
    public float m_musicVolume;
    public float m_soundVolume;
	
    // This is the default setting when first initialized.
    public SaveLoadSettings()
    {
        this.m_musicVolume = 100.0f;
        this.m_soundVolume = 100.0f;
    }
}
