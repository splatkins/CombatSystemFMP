using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyController : MonoBehaviour
{
	public GameObject player;
	public enum enemySate {resting, wandering, chasing, combat};
	public enemySate myState;

	private Rigidbody myRigidBody;

	public float currentSpeed;

	//public Transform myEyesPos;
	//Vector3 origin;
	//public float viewDistance;
	public float rotateSpeed;

	public float restTime;

	//bool playerSeen = false;

	public Vector3 randomRotation;
	Quaternion myNewRotation;
	public float moveDistance;
	//public Transform target;
	public Vector3 targetPosition, newPosition;
	public bool rotationSet, restTimeSet, distanceSet, canMove, newPosSet, moved;

	public GameObject myHead;

	//float currentTime = 0.0f;
	public float timeToMove;// = 3.0f;

	// Use this for initialization
	void Start ()
	{
		myRigidBody = GetComponent<Rigidbody> ();
		myHead.GetComponent<Renderer> ().material.color = Color.yellow;

//		origin.x = myEyesPos.position.x;
//		origin.y = myEyesPos.position.y;
//		origin.z = myEyesPos.position.z;

		myState = enemySate.resting;
	}
	
	// Update is called once per frame
	void Update ()
	{
//		// can I see the player?
//		RaycastHit hit;
//		Ray viewRay = new Ray(origin, Vector3.forward);
//
//		Color viewRayColor;
//
//		if (playerSeen == true)
//		{
//			viewRayColor = Color.red;
//			myState = enemySate.chasing; // chase the player when I see it
//		}
//		else
//		{
//			viewRayColor = Color.green;
//		}
//
//		Debug.DrawRay (origin, Vector3.forward * viewDistance, viewRayColor); // draw the ray
//
//		if (Physics.Raycast (viewRay, out hit, viewDistance))
//		{
//			if (hit.collider.tag == "Player")
//			{
//				print ("I see the player!");
//				playerSeen = true;
//			}
//		}
//		else
//		{
//			playerSeen = false;
//		}
			
		// act on current state
		switch (myState)
		{
		case enemySate.resting:
			print ("enemy is resting");

			if (restTimeSet == false)
			{
				restTimeSet = true;
				restTime = Random.Range (0.0f, 5.0f);
				StartCoroutine (Rest ());
			}
				
//			for (int i = 0; i < restTime; i++)
//			{
//				print (restTime);
//				myState = enemySate.wandering;
//				restTimeSet = false;
//			}

		break;
			
		case enemySate.wandering:
			//print ("enemy is wandering");

			Rotate();



		break;
			
		case enemySate.chasing:
			print ("enemy is chasing the player");


			rotationSet = false;
			myNewRotation.eulerAngles = new Vector3(0, 0, 0);
			distanceSet = false;

			transform.LookAt (player.transform);

		break;

		case enemySate.combat:
			print ("enemy is in combat with the player");

		break;

		default:
			print ("Should Not Display");
		break;
		}

	}

	IEnumerator Rest()
	{
		yield return new WaitForSeconds (restTime);
		restTime = 0.0f;
		restTimeSet = false;
		myState = enemySate.wandering;
	}

	void Rotate ()
	{
		print ("enemy is rotating");
		// set random rotation
		if (rotationSet == false)
		{
			rotationSet = true;
			randomRotation = transform.eulerAngles;
			randomRotation.y = Random.Range(0f, 360f);
			randomRotation.x = 0;
			randomRotation.z = 0;
			myNewRotation.eulerAngles = randomRotation;
		}
		//transform.rotation = Quaternion.Euler (myRotation);
		//transform.localRotation = Quaternion.Lerp (transform.localRotation, Quaternion.Euler(myRotation), Time.deltaTime * rotateSpeed);
		transform.localRotation = Quaternion.RotateTowards(transform.localRotation, myNewRotation, rotateSpeed * Time.deltaTime);

		if(transform.localRotation == myNewRotation)
		{
			MoveForward ();
		}
	}

	void MoveForward()
	{
		print ("enemy is moving");

		// set random distance to move
		if (distanceSet == false)
		{
			distanceSet = true;
			//moveDistance.x = 0;
			//moveDistance.y = 0;
			//moveDistance = Random.Range (0f, 3f);
			timeToMove = Random.Range (0f, 3f);
			//targetPosition.x = transform.localPosition.x;
			//targetPosition.y = transform.localPosition.y;
			//targetPosition.z = transform.localPosition.z + moveDistance;
			//targetPosition.position = transform.localPosition;
//			Vector3 temp = transform.position;// = transform.localPosition.z + moveDistance;
//			temp.z = targetPosition.position.z + moveDistance;
//			targetPosition.position = temp;

//			targetPosition.localPosition = transform.localPosition;
//			Vector3 temp = targetPosition.localPosition;
//			temp.z += moveDistance;
//			targetPosition.localPosition = temp;

			//targetPosition.x = transform.localPosition.x;
			//targetPosition.y = transform.localPosition.y;
			//targetPosition.z = transform.localPosition.z; // + moveDistance;

			//targetPosition = Vector3.forward * moveDistance;

			//targetPosition = transform.localPosition;
			//targetPosition.z = transform.localPosition.z + moveDistance;
			//targetPosition = Vector3.forward + targetPosition;;
//			if (newPosSet == false)
//			{
//				newPosition.position = targetPosition.position;
//				newPosSet = true;
//			}
			//print ("target " + targetPosition.position);
			//print ("new " + newPosition.position);
			canMove = true;
		}

		// move
		if (canMove == true)
		{
		//float step = currentSpeed * Time.deltaTime;
		//transform.localPosition = Vector3.MoveTowards (transform.position, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + moveDistance.z), step);
			//transform.localPosition = Vector3.MoveTowards (transform.position, newPosition.position, currentSpeed * Time.deltaTime);
			//transform.position = Vector3.MoveTowards (transform.position, moveDistance * Vector3.forward, currentSpeed * Time.deltaTime);
			StartCoroutine(Move());
//			transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
//			if (transform.localPosition == newPosition.position)
//			{
//				canMove = false;
//				newPosSet = false;
//				targetPosition.position = transform.localPosition;
//				newPosition.position = transform.localPosition;
//				print ("Enemy finished moving");
//				rotationSet = false;
//				distanceSet = false;
//				// rest
//				myState = enemySate.resting;
//			}

//			if (transform.localPosition == targetPosition)
//			{
//				canMove = false;
//				//targetPosition = new Vector3 (0, 0, 0);
//				//newPosSet = false;
//				//targetPosition.position = transform.localPosition;
//				//newPosition.position = transform.localPosition;
//				print ("Enemy finished moving");
//				rotationSet = false;
//				distanceSet = false;
//				// rest
//				myState = enemySate.resting;
//			}
		}

//		if (moved == true)
//		{
//			print ("Enemy finished moving");
//			rotationSet = false;
//			distanceSet = false;
//			// rest
//			myState = enemySate.resting;
//		}

		//transform.Translate(Vector3.forward * Time.deltaTime);
		//transform.position += transform.forward * Time.deltaTime;

		//transform.localPosition = Vector3.Lerp (transform.localPosition, transform.forward * moveDistance, Time.deltaTime * currentSpeed);
//		Move();
//
//		if (canMove == true)
//		{
//			transform.Translate (Vector3.forward * currentSpeed * Time.deltaTime);
//		}

		//myRigidBody.AddForce (transform.forward * moveDistance * currentSpeed * Time.deltaTime);

		//targetPlusZ.z = transform.position.z + moveDistance;

		//float step = currentSpeed * Time.deltaTime;
		//transform.localPosition = Vector3.MoveTowards (transform.localPosition, targetPlusZ, step);

		//if (transform.localPosition == transform.localPosition + moveDistance)
		//{
		//if (transform.localPosition == targetPosition)
		//{
//			print ("Enemy finished moving");
//			rotationSet = false;
//			distanceSet = false;
//			// rest
//			myState = enemySate.resting;
		//}
		//}
	}

	IEnumerator Move()
	{
		//canMove = true;
		transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
		yield return new WaitForSeconds (timeToMove);
		canMove = false;
		//moved = true;
		rotationSet = false;
		distanceSet = false;
		// rest
		myState = enemySate.resting;
		//moveTime = 0;
	}

	void OnTriggerEnter(Collider other)
	{
		// can I see the player?
		if (other.tag == "Player")
		{
			print ("I see the player");
			myHead.GetComponent<Renderer> ().material.color = Color.blue;
			myState = enemySate.chasing;
		}
	}

	void OnTriggerExit(Collider other)
	{
		// can I see the player?
		if (other.tag == "Player")
		{
			print ("I can't see the player");
			myHead.GetComponent<Renderer> ().material.color = Color.yellow;
			myState = enemySate.resting;
		}
	}
}
