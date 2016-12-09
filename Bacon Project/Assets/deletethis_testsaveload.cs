using UnityEngine;
using System.Collections;

public class deletethis_testsaveload : MonoBehaviour {

    public GameObject calenderSystem;

    void Start ()
    {
        SaveLoadManagement.m_current = new SaveLoadManagement();
    }

	public void Save()
    {
        SaveLoadManagement.m_current.m_data0.m_scene = "Jeff's Test Scene";
        SaveLoadManagement.m_current.m_data0.m_currentDay = calenderSystem.GetComponent<CalanderSystem>().CurrentDay;
        SaveLoad.Save();
    }

    public void Load()
    {
        SaveLoad.Load();

        calenderSystem.GetComponent<CalanderSystem>().CurrentDay = SaveLoad.m_savedGames.m_data0.m_currentDay;
    }
}
