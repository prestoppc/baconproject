using UnityEngine;
using System.Collections;

/*
    Author: Keisuke Miyazaki
    Date: December 2, 2016
    E-mail: mintymiyazaki@yahoo.co.jp
    Purpose: To provide a save system for CelleC C# Unity Projects
    Notes: Available in C++, C#, and Java, English, Japanese, and Mandarin upon request

    Description: This is just a template for the save data pertaining to user settings. Think of this as a save slot.
    All these are absolutely optional, this is just an example.
*/

[System.Serializable]
public class SaveLoadData
{
    //What to save
    //Day
    //Upgrades
    //Money
    //Gangs defeated
    //Number of people killed/mugged
    //Criminals killed
    //how much each food was sold
    //how much each machine was used
    //weapons owned
    //supplies owned

    public string    m_scene;
    public int       m_currentDay;
    public float     m_money;
    public int[]     m_upgrades; //TODO: Might have to change the data type to what we do for upgrades.
    public int[]     m_gangsDefeated; //TODO: Might have to change the data type to what we do for gangs defeated.
    public int       m_customersKilled;
    public int       m_customersMugged;
    public int       m_criminalsKilled;
    public int[]     m_foodSold; //TODO: Might have to change the data type to what we do for food sold.
    public int[]     m_machinesUsed; //TODO: Might have to change the data type to what we do for machines used.
    public int[]     m_weaponsOwned; //TODO: Might have to change the data type to what we do for weapons owned.
    public int[]     m_suppliesOwned; //TODO: Might have to change the data type to what we do for weapons owned.

    // Default values for the save slot
    public SaveLoadData()
    {
        this.m_scene = "";

        this.m_currentDay = 0;

    }
}