﻿using UnityEngine;
using System.Collections;

public class DouglasController : MonoBehaviour {

    private Camera mainCamera;

    public GunController currentGun;
    public GunController[] guns;

    private int currentGunIndex = 0;

    private int numGrenades = 3;
    public GrenadeLauncher grenadeLauncher; 

    private float rollSpeed = 5;
    public bool bIsRolling = false;
    private float rollDirX;
    private float rollDirY;
    private Vector3 rollDirection;

    PlayerController pc;

    //This is a temporary variable this is going to stay here til we figure out how controller and keyboard work together - Jeffrey
    public bool controller;

    //This variable is for the rotation of the controller which is the speed - Jeffrey
    private float speed = 2f;

    // Use this for initialization
    void Start ()
    {
        pc = GetComponent<PlayerController>();
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

            /// Gun Fire
            if (Input.GetMouseButton(0))
            {
                currentGun.bIsFiring = true;
            }
            else
            {
                currentGun.bIsFiring = false;
            }
        }
        //This is to rotate the player but feels kinda weird with X being shoot since you basiclly have to take thumb off the stick and hit X - Jeffrey
        else
        {
            if (scr_InputManager.GetStickorDpad(STICKS.RIGHT, AXIS_XY.X) != 0 || scr_InputManager.GetStickorDpad(STICKS.RIGHT, AXIS_XY.Y) != 0)
            {
                transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(scr_InputManager.GetStickorDpad(STICKS.RIGHT, AXIS_XY.X), scr_InputManager.GetStickorDpad(STICKS.RIGHT, AXIS_XY.Y)) * Mathf.Rad2Deg, Vector3.up);
                currentGun.bIsFiring = true;
            }
            else
                currentGun.bIsFiring = false;
        }

        /// Grenade Throw
        if(Input.GetMouseButtonDown(1) && numGrenades >0)
        {
            grenadeLauncher.ThrowGrenade();
            numGrenades--;
        }

        /// Roll Input
        if ((Input.GetKeyDown(KeyCode.Space) || scr_InputManager.GetButt(BUTTON.A, UPDOWN.DOWN)) && !bIsRolling) // If currently not rolling
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
        pc.bCanMove = false;
        bIsRolling = true;
        yield return new WaitForSeconds(.25f);
        pc.bCanMove = true;
        bIsRolling = false;
    }

    void ChangeGun(int num)
    {
        currentGun.bIsFiring = false; // Stop firing current gun
        currentGunIndex = num; // Select chosen gun
        currentGun = guns[currentGunIndex]; // Set selected gun as active gun
    }
}
