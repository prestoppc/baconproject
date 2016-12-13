using UnityEngine;
using System.Collections;

public class DouglasController : MonoBehaviour {

    private Camera mainCamera;

    public GunController theGun;

    private float rollSpeed = 10;
    public bool bIsRolling = false;
    private float rollCounter;
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

        if (groundPlane.Raycast(cameraRay, out rayLength) && !bIsRolling)
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
        if(Input.GetKeyDown(KeyCode.Space) && !bIsRolling)
        {
            StartCoroutine("Roll");
        }

        if(bIsRolling)
        {
            transform.Translate(Vector3.forward * rollSpeed * Time.deltaTime);
        }
       
    }

    IEnumerator Roll()
    {
        bIsRolling = true;
        yield return new WaitForSeconds(.25f);
        bIsRolling = false;
    }
}
