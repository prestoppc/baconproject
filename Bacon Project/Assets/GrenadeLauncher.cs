using UnityEngine;
using System.Collections;

public class GrenadeLauncher : MonoBehaviour {
    public GrenadeController grenade;
    public Transform firePoint;
    private float thrust = 300; 
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ThrowGrenade()
    {
        GrenadeController newGrenade = Instantiate(grenade, firePoint.position, firePoint.rotation) as GrenadeController;
        Rigidbody rb = newGrenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * thrust);
    }
}
