using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

	// Use this for initialization
	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
	}

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        myRigidbody.velocity = moveVelocity;
    }
}
