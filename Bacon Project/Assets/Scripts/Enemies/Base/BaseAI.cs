﻿using UnityEngine;
using System.Collections;

public class BaseAI : MonoBehaviour {

    public GameObject testPos; // delete this when finished

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (testPos != null)
            GetComponent<NavMeshAgent>().SetDestination(testPos.transform.position);
    }
}
