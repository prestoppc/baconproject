using UnityEngine;
using System.Collections;

public class CustomerAI : MonoBehaviour {

    public GameObject CurrentWaypoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (CurrentWaypoint != null)
            GetComponent<NavMeshAgent>().SetDestination(CurrentWaypoint.transform.position);

    }
}
