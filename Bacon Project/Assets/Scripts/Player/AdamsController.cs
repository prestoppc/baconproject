using UnityEngine;
using System.Collections;

public class AdamsController : MonoBehaviour {

    private Camera mainCamera;

    public GunController theGun; 
    // Use this for initialization
    void Start ()
    {
        mainCamera = FindObjectOfType<Camera>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if(Input.GetMouseButtonDown(0))
        {
            theGun.bIsFiring = true; 
        }
        if(Input.GetMouseButtonUp(0))
        {
            theGun.bIsFiring = false; 
        }
    }
}
