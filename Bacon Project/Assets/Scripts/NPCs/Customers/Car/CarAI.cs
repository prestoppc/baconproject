using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarAI : MonoBehaviour {

    public Transform spawnPos;
    public List<GameObject> customers;

    public GameObject targetWaypoint;
    

	// Use this for initialization
	void Start () {
        GetComponent<NavMeshAgent>().SetDestination(targetWaypoint.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        WaypointCheck();
	}

    public void SpawnCustomer()
    {
        GameObject customer = Instantiate(customers[Random.Range(0, customers.Count)], spawnPos.position, Quaternion.identity) as GameObject;
      //  customer.GetComponent<CustomerAI>().CurrentWaypoint = ;
    }

    public void WaypointCheck()
    {
        Vector3 pos = transform.position;
        pos.y = targetWaypoint.transform.position.y;

        if (pos == targetWaypoint.transform.position)
        {
            NetworkWaypoint target = targetWaypoint.GetComponent<NetworkWaypoint>();
            if (target.openSpots > 0)
            {
                targetWaypoint = target.altWaypoint;
            }
            else
            {
                targetWaypoint = target.nextWaypoint;
            }

            ResetWaypoint();
        }
    }

    public void ResetWaypoint()
    {
        GetComponent<NavMeshAgent>().SetDestination(targetWaypoint.transform.position);
    }
}
