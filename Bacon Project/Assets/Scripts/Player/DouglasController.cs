using UnityEngine;
using System.Collections;

public class DouglasController : MonoBehaviour {

    private Camera mainCamera;

    public GunController theGun;

    private float rollSpeed = 5;
    public bool bIsRolling = false;
    private float rollCounter;
    private float rollDirX;
    private float rollDirY;
    private Vector3 rollDirection; 
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

        /// Roll Input
        if(Input.GetKeyDown(KeyCode.Space) && !bIsRolling) // If currently not rolling
        {
            rollDirX = Input.GetAxisRaw("Horizontal"); 
            rollDirY = Input.GetAxisRaw("Vertical");
            rollDirection = new Vector3(rollDirX, 0, rollDirY);

            StartCoroutine("Roll");
        }

        if(bIsRolling)
        {
            transform.Translate(rollDirection * rollSpeed * Time.deltaTime, Space.World);
        }
    }

    IEnumerator Roll()
    {
        bIsRolling = true;
        yield return new WaitForSeconds(.25f);
        bIsRolling = false;
    }
}
