using UnityEngine;
using System.Collections;

public class deletethis_calandertest : MonoBehaviour {
    public GameObject calanderSystem;
    public float gametime;
    public float changeday;
	// Use this for initialization
	void Start () {
        gametime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        gametime += Time.deltaTime;

        if (gametime >= changeday && !calanderSystem.GetComponent<CalanderSystem>().gamePause)
        {
            gametime = 0;

            calanderSystem.GetComponent<CalanderSystem>().ChangeDay();
        }

        if (calanderSystem.GetComponent<CalanderSystem>().gamePause)
        {
            gametime = 0;
        }
	}
}
