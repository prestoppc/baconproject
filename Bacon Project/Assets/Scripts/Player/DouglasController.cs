using UnityEngine;
using System.Collections;

public class DouglasController : MonoBehaviour {

    private Camera mainCamera;

    public GunController currentGun;
    public GunController[] guns;
    private int currentGunIndex = 0;

    private float rollSpeed = 5;
    public bool bIsRolling = false;
    private float rollCounter;
    private float rollDirX;
    private float rollDirY;
    private Vector3 rollDirection; 


    //This is a temporary variable this is going to stay here til we figure out how controller and keyboard work together - Jeffrey
    public bool controller;

    //This variable is for the rotation of the controller which is the speed - Jeffrey
    private float speed = 2f;

    // Use this for initialization
    void Start ()
    {
        mainCamera = FindObjectOfType<Camera>();
        currentGun = guns[currentGunIndex];
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!controller)
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
        }
        //This is to rotate the player but feels kinda weird with X being shoot since you basiclly have to take thumb off the stick and hit X - Jeffrey
        else
        {
            if (scr_InputManager.GetStickorDpad(STICKS.RIGHT, AXIS_XY.X) != 0 || scr_InputManager.GetStickorDpad(STICKS.RIGHT, AXIS_XY.Y) != 0)
            {
                transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(scr_InputManager.GetStickorDpad(STICKS.RIGHT, AXIS_XY.X), scr_InputManager.GetStickorDpad(STICKS.RIGHT, AXIS_XY.Y)) * Mathf.Rad2Deg, Vector3.up);
            }
        }

        //Hey this is Jeff change these if statements so it works with the controller
        //P.S. I love you eric will you marry me O-0 <---- thats the ring
        if(Input.GetMouseButton(0) || scr_InputManager.GetButt(BUTTON.X, UPDOWN.DOWN))
        {
            currentGun.bIsFiring = true; 
        }
        else
        {
            currentGun.bIsFiring = false;
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

        /// Changing Guns
        if(Input.GetKeyDown(KeyCode.Alpha1))
            ChangeGun(0);
        if(Input.GetKeyDown(KeyCode.Alpha2))
            ChangeGun(1);
        if(Input.GetKeyDown(KeyCode.Alpha3))
            ChangeGun(2);
    }

    IEnumerator Roll()
    {
        bIsRolling = true;
        yield return new WaitForSeconds(.25f);
        bIsRolling = false;
    }

    void ChangeGun(int num)
    {
        currentGun.bIsFiring = false; // Stop firing current gun
        currentGunIndex = num; // Select chosen gun
        currentGun = guns[currentGunIndex]; // Set selected gun as active gun
    }
}
