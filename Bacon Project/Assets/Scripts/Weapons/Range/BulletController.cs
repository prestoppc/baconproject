using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start ()
    {
        Destroy(this.gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
