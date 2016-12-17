using UnityEngine;
using System.Collections;

public class GrenadeController : MonoBehaviour {

    private  float thrust = 300;
    Rigidbody rb;
    // Use this for initialization
    void Start ()
    {
        Destroy(this.gameObject, 3f);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * thrust);
    }

    // Update is called once per frame
    void Update ()
    {

    }

    void FixedUpdate()
    {
    }

}
