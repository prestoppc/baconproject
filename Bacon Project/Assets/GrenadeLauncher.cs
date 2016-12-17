using UnityEngine;
using System.Collections;

public class GrenadeLauncher : MonoBehaviour {
    public GrenadeController grenade;
    public Transform firePoint;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ThrowGrenade()
    {
        GrenadeController newGrenade = Instantiate(grenade, firePoint.position, firePoint.rotation) as GrenadeController;
    }
}
