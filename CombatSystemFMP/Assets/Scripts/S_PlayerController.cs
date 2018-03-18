using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerController : MonoBehaviour
{
	public float currentSpeed;
	public float walkSpeed;
	public float runSpeed;
	public float turningSpeed;

	public bool isRunning = false;
	public bool isJumping = false;
	public bool isDodging = false;

	private Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();

		currentSpeed = walkSpeed;
		turningSpeed = currentSpeed * 100;
	}
	
	// Update is called once per frame
	void Update ()
	{
//		float hAxis = Input.GetAxis ("Horizontal");
//		float vAxis = Input.GetAxis ("Vertical");
//
//		//Vector3 movement = new Vector3 (hAxis, 0, vAxis) * currentSpeed * Time.deltaTime;
//
//		transform.Translate(hAxis * currentSpeed * Time.deltaTime, 0, vAxis * currentSpeed * Time.deltaTime);

		float horizontal = Input.GetAxis ("Horizontal") * turningSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);

		float vertical = Input.GetAxis ("Vertical") * currentSpeed * Time.deltaTime;
		transform.Translate (0, 0, vertical);
	}
}
