using UnityEngine;
using System.Collections;

public class CustomerAI : MonoBehaviour {

    public GameObject testPos;// delete this

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (testPos != null)
            GetComponent<NavMeshAgent>().SetDestination(testPos.transform.position);

    }
}
