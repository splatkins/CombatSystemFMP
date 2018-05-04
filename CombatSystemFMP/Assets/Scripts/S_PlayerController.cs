using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerController : MonoBehaviour
{
	public float currentSpeed;
	public float walkSpeed;
	public float runSpeed;
	public float backSwingSpeed, swingSpeed, returnSpeed, raiseSpeed, lowerSpeed;

	public float myWeaponWeight;
	public float myShieldWeight;

	//public float turningSpeed;

	public bool isRunning = false;
	public bool isJumping = false;
	public bool isDodging = false;

	private Rigidbody myRigidBody;

	public Camera myCamera;
	public GameObject myCurrentWeapon;
	public GameObject myCurrentShield;

	public Transform myRightShoulder;
	public Transform myRightElbow;
	public Transform myRightHand;

	public Transform myLeftShoulder;
	public Transform myLeftElbow;
	public Transform myLeftHand;

	//private Quaternion backSwingRotation;
	public float playerRotationY;
	public float playerRotationZ;

	public bool attacking, backswinging, swinging, blocking, raising, lowering = false;
	public bool canChangeWeapon = true;
	public bool canAttack = true;
	public bool canRun = true;

	// Use this for initialization
	void Start ()
	{
		myRigidBody = GetComponent<Rigidbody> ();

		currentSpeed = walkSpeed;
		//turningSpeed = currentSpeed * 100;



		//backSwingRotation *= Quaternion.AngleAxis (-100, Vector3.right);
		//from.rotation = myRightArm.rotation;
		//to.rotation = Quaternion.Euler (-100, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey ("escape"))
		{
			Application.Quit ();
		}

		// set current weapon
		myCurrentWeapon = this.GetComponent<S_CurrentWeapon>().currentWeapon;
		myWeaponWeight = this.GetComponent<S_CurrentWeapon> ().currentWeaponWeight;

		// set current shield
		myCurrentShield = this.GetComponent<S_CurrentWeapon>().currentShield;
		myShieldWeight = this.GetComponent<S_CurrentWeapon> ().currentShieldWeight;

		// set attack speeds depending on weapon weight
		if (myWeaponWeight <= 0.20f) // lightest weapon, quickest speeds
		{
			backSwingSpeed = 12.0f;
			swingSpeed = 14.0f;
			returnSpeed = 20.0f;
			//print ("Weapon Speed 1");
		}
		else if (myWeaponWeight > 0.20f && myWeaponWeight <= 0.60f)
		{
			backSwingSpeed = 10.0f;
			swingSpeed = 12.0f;
			returnSpeed = 18.0f;
			//print ("Weapon Speed 2");
		}
		else if (myWeaponWeight > 0.60f && myWeaponWeight <= 0.80f)
		{
			backSwingSpeed = 8.0f;
			swingSpeed = 10.0f;
			returnSpeed = 16.0f;
			//print ("Weapon Speed 3");
		}
		else if (myWeaponWeight > 0.80f && myWeaponWeight <= 1.00f)
		{
			backSwingSpeed = 8.0f;
			swingSpeed = 10.0f;
			returnSpeed = 16.0f;
			//print ("Weapon Speed 4");
		}
		else if (myWeaponWeight > 1.00f) // heaviest weapon, slowest speeds
		{
			backSwingSpeed = 6.0f;
			swingSpeed = 8.0f;
			returnSpeed = 14.0f;
			//print ("Weapon Speed 5");
		}

		// set block speeds depending on shield weight
		if (myShieldWeight > 1.5f)
		{
			raiseSpeed = 9.0f;
			lowerSpeed = 15.0f;
			//print ("Shield Speed 1");
		}

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

		playerRotationY = transform.rotation.y;
		playerRotationZ = transform.rotation.z;

		// make weapon and shield follow hands
		myCurrentWeapon.transform.position = myRightHand.transform.position;
		myCurrentWeapon.transform.rotation = myRightHand.transform.rotation;
		myCurrentShield.transform.position = myLeftHand.transform.position;
		myCurrentShield.transform.rotation = myLeftHand.rotation;

		if (Input.GetKey(KeyCode.LeftShift) && canRun == true)
		{
			currentSpeed = runSpeed;
			isRunning = true;
			//print("running");
		}
		else
		{
			currentSpeed = walkSpeed;
			isRunning = false;

			if (blocking == true)
			{
				currentSpeed = walkSpeed / 2;
			}
		}
			
		// forwards
		if (Input.GetAxis ("Vertical") > 0)
		{
			//transform.rotation = Quaternion.Euler (0, 0, 0);
			//transform.localRotation = Quaternion.Euler (0, 0, 0);

			transform.rotation = Quaternion.LookRotation(myCamera.transform.forward);

			myRigidBody.AddForce (myCamera.transform.forward * currentSpeed * Time.deltaTime);

			//print ("forwards");
		}
			
		// backwards
		if (Input.GetAxis ("Vertical") < 0)
		{
			//transform.rotation = Quaternion.Euler (0, 180, 0);

			//transform.rotation = Quaternion.Inverse(myCamera.transform.rotation);
			//transform.rotation = Quaternion.Euler(-myCamera.transform.rotation.eulerAngles);

			transform.rotation = Quaternion.LookRotation(-myCamera.transform.forward);

			myRigidBody.AddForce (-myCamera.transform.forward * currentSpeed * Time.deltaTime);

			//print ("backwards");
		}

		// right
		if (Input.GetAxis ("Horizontal") > 0)
		{
			//transform.rotation = Quaternion.Euler (0, 90, 0);

			transform.rotation = Quaternion.LookRotation(myCamera.transform.right);

			myRigidBody.AddForce (myCamera.transform.right * currentSpeed * Time.deltaTime);

			//print ("right");
		}

		// left
		if (Input.GetAxis ("Horizontal") < 0)
		{
			//transform.rotation = Quaternion.Euler (0, 270, 0);

			transform.rotation = Quaternion.LookRotation(-myCamera.transform.right);

			myRigidBody.AddForce (-myCamera.transform.right * currentSpeed * Time.deltaTime);

			//print ("left");
		}

//		if (Input.GetAxis ("Vertical") < 0.5 && Input.GetAxis ("Vertical") > -0.5f)
//		{
//			myRigidBody.AddForce (transform.forward * 0);
//			print ("stopping");
//		}

		// attacking
		if (Input.GetKeyDown (KeyCode.Mouse0) && attacking == false && canAttack == true)
		{
			//print ("Attack");

			// swing right arm
			//myRightArm.transform.rotation = Quaternion.Lerp(myRightArm.transform.rotation, backSwingRotation, swingSpeed * Time.deltaTime);
			//myRightArm.transform.Rotate(-Vector3.right * (swingSpeed));
			attacking = true;
			backswinging = true;
			canChangeWeapon = false;
//			if (attacking == true)
//			{
//				StartCoroutine (Attack ());
//			}	

		}
			
		if (attacking == true && backswinging == true)
		{
			//if (myRightArm.transform.localRotation != Quaternion.Euler(-100.0f, playerRotationY, playerRotationZ))
			//{
			//print ("backswing");

			myRightShoulder.transform.localRotation = Quaternion.Lerp (myRightShoulder.transform.localRotation, Quaternion.Euler (-100.0f, playerRotationY, playerRotationZ), Time.deltaTime * backSwingSpeed);
			myRightElbow.transform.localRotation = Quaternion.Lerp (myRightElbow.transform.localRotation, Quaternion.Euler (-30.0f, playerRotationY, playerRotationZ), Time.deltaTime * backSwingSpeed * 2);
			myRightHand.transform.localRotation = Quaternion.Lerp (myRightHand.transform.localRotation, Quaternion.Euler (-120.0f, playerRotationY, playerRotationZ), Time.deltaTime * backSwingSpeed);
			//}
			if (myRightShoulder.transform.localRotation == Quaternion.Euler (-100.0f, playerRotationY, playerRotationZ) && myRightElbow.transform.localRotation == Quaternion.Euler (-30.0f, playerRotationY, playerRotationZ) && myRightHand.transform.localRotation == Quaternion.Euler (-120.0f, playerRotationY, playerRotationZ))
			{
				backswinging = false;
				swinging = true;
			}
		}

		if (attacking == true && swinging == true)
		{
			//print ("swinging");

			myRightShoulder.transform.localRotation = Quaternion.Lerp (myRightShoulder.transform.localRotation, Quaternion.Euler (30.0f, playerRotationY, playerRotationZ), Time.deltaTime * swingSpeed);
			myRightElbow.transform.localRotation = Quaternion.Lerp (myRightElbow.transform.localRotation, Quaternion.Euler (30.0f, playerRotationY, playerRotationZ), Time.deltaTime * backSwingSpeed * 2);
			myRightHand.transform.localRotation = Quaternion.Lerp (myRightHand.transform.localRotation, Quaternion.Euler (-55.0f, playerRotationY, playerRotationZ), Time.deltaTime * backSwingSpeed * 2);

			if (myRightShoulder.transform.localRotation == Quaternion.Euler (30.0f, playerRotationY, playerRotationZ) && myRightElbow.transform.localRotation == Quaternion.Euler (30.0f, playerRotationY, playerRotationZ) && myRightHand.transform.localRotation == Quaternion.Euler (-55.0f, playerRotationY, playerRotationZ))
			{
				swinging = false;
				attacking = false;
			}
		}

		if (attacking == false && backswinging == false && swinging == false)
		{
			//print ("return");

			myRightShoulder.transform.localRotation = Quaternion.Lerp (myRightShoulder.transform.localRotation, Quaternion.Euler (0.0f, playerRotationY, playerRotationZ), Time.deltaTime * returnSpeed);
			myRightElbow.transform.localRotation = Quaternion.Lerp (myRightElbow.transform.localRotation, Quaternion.Euler (0.0f, playerRotationY, playerRotationZ), Time.deltaTime * backSwingSpeed * 2);
			myRightHand.transform.localRotation = Quaternion.Lerp (myRightHand.transform.localRotation, Quaternion.Euler (-100.0f, playerRotationY, playerRotationZ), Time.deltaTime * backSwingSpeed);

			if (myRightShoulder.transform.localRotation == Quaternion.Euler (0.0f, playerRotationY, playerRotationZ) && myRightElbow.transform.localRotation == Quaternion.Euler (0.0f, playerRotationY, playerRotationZ) && myRightHand.transform.localRotation == Quaternion.Euler (-100.0f, playerRotationY, playerRotationZ))
			{
				canChangeWeapon = true;
			}

		}

		// blocking
		if (Input.GetKey (KeyCode.Mouse1) && blocking == false)
		{
			//print ("Block");

			blocking = true;
			raising = true;
			canChangeWeapon = false;
			canAttack = false;
		}

		if (blocking == true && raising == true)
		{
			//print ("raising");

			canChangeWeapon = false;

			myLeftShoulder.transform.localRotation = Quaternion.Lerp (myLeftShoulder.transform.localRotation, Quaternion.Euler (-45.0f, playerRotationY, playerRotationZ), Time.deltaTime * raiseSpeed);
			myLeftElbow.transform.localRotation = Quaternion.Lerp (myLeftElbow.transform.localRotation, Quaternion.Euler (-30.0f, playerRotationY, playerRotationZ), Time.deltaTime * raiseSpeed * 2);
			myLeftHand.transform.localRotation = Quaternion.Lerp (myLeftHand.transform.localRotation, Quaternion.Euler (-40.0f, playerRotationY, playerRotationZ), Time.deltaTime * raiseSpeed);

			if (myLeftShoulder.transform.localRotation == Quaternion.Euler (-45.0f, playerRotationY, playerRotationZ) && myLeftElbow.transform.localRotation == Quaternion.Euler (-30.0f, playerRotationY, playerRotationZ) && myLeftHand.transform.localRotation == Quaternion.Euler (-40.0f, playerRotationY, playerRotationZ))
			{
				//raising = false;
				canRun = false;
			}
		}

		if (Input.GetKeyUp (KeyCode.Mouse1) && blocking == true)
		{
			raising = false;
			lowering = true;
		}

		if (blocking == true && lowering == true)
		{
			//print ("lowering");

			myLeftShoulder.transform.localRotation = Quaternion.Lerp (myLeftShoulder.transform.localRotation, Quaternion.Euler (0.0f, playerRotationY, playerRotationZ), Time.deltaTime * lowerSpeed);
			myLeftElbow.transform.localRotation = Quaternion.Lerp (myLeftElbow.transform.localRotation, Quaternion.Euler (0.0f, playerRotationY, playerRotationZ), Time.deltaTime * lowerSpeed * 2);
			myLeftHand.transform.localRotation = Quaternion.Lerp (myLeftHand.transform.localRotation, Quaternion.Euler (-100.0f, playerRotationY, playerRotationZ), Time.deltaTime * lowerSpeed);

			if (myLeftShoulder.transform.localRotation == Quaternion.Euler (0.0f, playerRotationY, playerRotationZ) && myLeftElbow.transform.localRotation == Quaternion.Euler (0.0f, playerRotationY, playerRotationZ) && myLeftHand.transform.localRotation == Quaternion.Euler (-100.0f, playerRotationY, playerRotationZ))
			{
				blocking = false;
				lowering = false;
				canChangeWeapon = true;
				canAttack = true;
				canRun = true;
			}
		}

//		if (myRightArm.transform.localRotation == Quaternion.Euler(-100.0f, playerRotationY, playerRotationZ))
//		{
//			print ("swing");
//
//			myRightArm.transform.localRotation = Quaternion.Lerp (myRightArm.transform.localRotation, Quaternion.Euler (0.0f, playerRotationY, playerRotationZ), Time.time * swingSpeed);
//			//attacking = false;
//		}
	}

//	IEnumerator Attack()
//	{
//		float swingSpeed = 0.1f;
//
//		while (myRightArm.transform.rotation.x < -100)
//		{
//			myRightArm.transform.rotation = Quaternion.Slerp (myRightArm.transform.rotation, Quaternion.Euler (-100, 0, 0), swingSpeed * Time.deltaTime);
//			yield return null;
//		}
//		myRightArm.transform.rotation = Quaternion.Euler (-100, 0, 0);
//		attacking = false;
//		yield return null;
//	}
}
