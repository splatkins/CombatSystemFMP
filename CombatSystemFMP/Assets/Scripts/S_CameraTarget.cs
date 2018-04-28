using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CameraTarget : MonoBehaviour
{

//	public float camOffsetX = 0f;
//	public float camOffsetY = 2.3f;
//	public float camOffsetZ = -0.85f;
//	public float camRotationX = 30f;
//	public float camRotationY = 0f;
//	public float camRotationZ = 0f;

	Vector3 offset;

	public float height;
	public float distance;

	//private Vector3 offsetX;
	//private Vector3 offsetY;

	public float rotateSpeed = 9f;

	public Transform target;
	private GameObject player;

	// Use this for initialization
	void Start ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		player = GameObject.FindWithTag ("Player");
		target = player.transform;

		//transform.Rotate(player.transform.rotation.x + camRotationX, player.transform.rotation.y + camRotationY, player.transform.rotation.z + camRotationZ);
	
		//offsetX = new Vector3 (0, height, distance);
		//offsetY = new Vector3 (0, 0, distance);

		offset = new Vector3 (target.position.x, target.position.y + height, target.position.z - distance);
	}

	// Update is called once per frame
	void Update ()
	{
		

		//transform.position = new Vector3 (player.transform.position.x + camOffsetX, player.transform.position.y + camOffsetY, player.transform.position.z + camOffsetZ);


		//transform.rotation.eulerAngles = new Vector3 (player.transform.rotation.x + camRotationX, player.transform.rotation.y + camRotationY, player.transform.rotation.z + camRotationZ);

		//transform.eulerAngles = new Vector3 (0 + camRotationX, target.transform.eulerAngles.y, 0);
		//float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;

//		float desiredAngle = target.transform.eulerAngles.y;
//		Quaternion rotation = Quaternion.Euler (0, desiredAngle, 0);
//
//		transform.position = target.transform.position - (rotation * offset);
//
//		transform.LookAt (target.transform);

//	public GameObject target;
//	public float rotateSpeed = 9;
//	Vector3 offset;
//
//	void Start() {
//		offset = target.transform.position - transform.position;
//
//		Cursor.lockState = CursorLockMode.Locked;
//		Cursor.visible = false;
//	}
//
//	void LateUpdate() {
//		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
//		//float vertical = Input.GetAxis ("Mouse Y") * rotateSpeed;
//
//		target.transform.Rotate(0, horizontal, 0);
//
//		float desiredAngleY = target.transform.eulerAngles.y;
//		//float desiredAngleX = vertical;
//		Quaternion rotation = Quaternion.Euler(0, desiredAngleY, 0);
//		transform.position = target.transform.position - (rotation * offset);
//
//		//transform.LookAt(target.transform);
//	
	}

	void LateUpdate()
	{
		//offsetX = Quaternion.AngleAxis (Input.GetAxis ("Mouse X") * rotateSpeed, Vector3.up) * offsetX;
		//offsetY = Quaternion.AngleAxis (Input.GetAxis ("Mouse Y") * rotateSpeed, Vector3.right) * offsetY;

		offset = Quaternion.AngleAxis (Input.GetAxis ("Mouse X") * rotateSpeed, Vector3.up) * offset;

		transform.position = target.position + offset;
		transform.LookAt (new Vector3(target.position.x, target.position.y + 2f, target.position.z));
	}
		
}
