using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AISpawner : MonoBehaviour {

    public List<GameObject> thingsToSpawn;
    public List<GameObject> possibleSpawnPositions;

    public float spawnAmount;
    public float spawnDelay;
    float spawnTimer = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0.0f)
        {
            Spawn();
            spawnTimer = spawnDelay;
        }
	
	}

    void Spawn()
    {
        if (thingsToSpawn.Count > 0 && possibleSpawnPositions.Count > 0)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                GameObject thingGO = Instantiate(thingsToSpawn[Random.Range(0, thingsToSpawn.Count)], possibleSpawnPositions[Random.Range(0, possibleSpawnPositions.Count)].transform.position, Quaternion.identity) as GameObject;
                if (thingGO.tag == "Customer")
                    thingGO.GetComponent<CustomerAI>().testPos = gameObject;
                else
                    thingGO.GetComponent<BaseAI>().testPos = gameObject;
            } 
        }
    }
}
