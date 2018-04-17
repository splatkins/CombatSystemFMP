using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerController : MonoBehaviour
{
	public float currentSpeed;
	public float walkSpeed;
	public float runSpeed;
	//public float turningSpeed;

	public bool isRunning = false;
	public bool isJumping = false;
	public bool isDodging = false;

	private Rigidbody myRigidBody;

	public Camera myCamera;
	// Use this for initialization
	void Start ()
	{
		myRigidBody = GetComponent<Rigidbody> ();

		currentSpeed = walkSpeed;
		//turningSpeed = currentSpeed * 100;
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

//		float horizontal = Input.GetAxis ("Horizontal") * turningSpeed * Time.deltaTime;
//		transform.Rotate(0, horizontal, 0);
//
//		float vertical = Input.GetAxis ("Vertical") * currentSpeed * Time.deltaTime;
//		transform.Translate (0, 0, vertical);

		if (Input.GetKey(KeyCode.LeftShift))
		{
			currentSpeed = runSpeed;
			isRunning = true;
			print("running");
		}
			else
		{
			currentSpeed = walkSpeed;
			isRunning = false;
		}
			
		// forwards
		if (Input.GetAxis ("Vertical") > 0)
		{
			//transform.rotation = Quaternion.Euler (0, 0, 0);
			//transform.localRotation = Quaternion.Euler (0, 0, 0);

			transform.rotation = Quaternion.LookRotation(myCamera.transform.forward);

			myRigidBody.AddForce (myCamera.transform.forward * currentSpeed * Time.deltaTime);

			print ("forwards");
		}
			
		// backwards
		if (Input.GetAxis ("Vertical") < 0)
		{
			//transform.rotation = Quaternion.Euler (0, 180, 0);

			//transform.rotation = Quaternion.Inverse(myCamera.transform.rotation);
			//transform.rotation = Quaternion.Euler(-myCamera.transform.rotation.eulerAngles);

			transform.rotation = Quaternion.LookRotation(-myCamera.transform.forward);

			myRigidBody.AddForce (-myCamera.transform.forward * currentSpeed * Time.deltaTime);

			print ("backwards");
		}

		// right
		if (Input.GetAxis ("Horizontal") > 0)
		{
			//transform.rotation = Quaternion.Euler (0, 90, 0);

			transform.rotation = Quaternion.LookRotation(myCamera.transform.right);

			myRigidBody.AddForce (myCamera.transform.right * currentSpeed * Time.deltaTime);

			print ("right");
		}

		// left
		if (Input.GetAxis ("Horizontal") < 0)
		{
			//transform.rotation = Quaternion.Euler (0, 270, 0);

			transform.rotation = Quaternion.LookRotation(-myCamera.transform.right);

			myRigidBody.AddForce (-myCamera.transform.right * currentSpeed * Time.deltaTime);

			print ("left");
		}

//		if (Input.GetAxis ("Vertical") < 0.5 && Input.GetAxis ("Vertical") > -0.5f)
//		{
//			myRigidBody.AddForce (transform.forward * 0);
//			print ("stopping");
//		}
	}
}
