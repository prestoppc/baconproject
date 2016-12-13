using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarAI : MonoBehaviour {

    public Transform spawnPos;
    public List<GameObject> customers;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnCustomer()
    {
        GameObject customer = Instantiate(customers[Random.Range(0, customers.Count)], spawnPos.position, Quaternion.identity) as GameObject;
      //  customer.GetComponent<CustomerAI>().CurrentWaypoint = ;
    }
}
