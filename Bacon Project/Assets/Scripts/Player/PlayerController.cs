using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public bool bCanMove = true;

	// Use this for initialization
	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Eric this is Jeff I changed this part to have an intake for controller does the samething with keyboard that it did before
        //also love you boo!!!!!!!!!!!!!!!1
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        else if (scr_InputManager.GetStickorDpad(STICKS.LEFT, AXIS_XY.X) != 0 || scr_InputManager.GetStickorDpad(STICKS.LEFT, AXIS_XY.Y) != 0)
            moveInput = new Vector3(scr_InputManager.GetStickorDpad(STICKS.LEFT, AXIS_XY.Y), 0f, scr_InputManager.GetStickorDpad(STICKS.LEFT, AXIS_XY.X));
        else if (scr_InputManager.GetStickorDpad(STICKS.DPAD, AXIS_XY.X) != 0 || scr_InputManager.GetStickorDpad(STICKS.DPAD, AXIS_XY.Y) != 0)
            moveInput = new Vector3(scr_InputManager.GetStickorDpad(STICKS.DPAD, AXIS_XY.Y), 0f, scr_InputManager.GetStickorDpad(STICKS.DPAD, AXIS_XY.X));
        else
            moveInput = Vector3.zero;
        moveVelocity = moveInput * moveSpeed;
	}

    void FixedUpdate()
    {
        if (bCanMove)
        {
            Move();
        }
    }

    void Move()
    {
        myRigidbody.velocity = moveVelocity;
    }
}
