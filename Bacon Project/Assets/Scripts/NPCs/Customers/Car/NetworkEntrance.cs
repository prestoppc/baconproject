using UnityEngine;
using System.Collections;

public class NetworkEntrance : MonoBehaviour {

    public GameObject startingWaypoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.tag == "Car")
        {
            CarAI car = trigger.gameObject.GetComponent<CarAI>();
            if (car.targetWaypoint.tag == "Origin")
            {
                car.targetWaypoint = startingWaypoint;
                car.ResetWaypoint();
            }
        }
    }
}
