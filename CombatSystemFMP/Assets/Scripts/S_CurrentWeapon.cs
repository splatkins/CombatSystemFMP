using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CurrentWeapon : MonoBehaviour
{
	public Transform myLeftHand;
	public Transform myRightHand;

	public List<GameObject> oneHandedWeapons = new List<GameObject> ();
	public List<GameObject> shields = new List<GameObject> ();

	public GameObject leftHandEquipped;
	public GameObject rightHandEquipped;



	// Use this for initialization
	void Start ()
	{
		leftHandEquipped = shields [0];
		leftHandEquipped.transform.position = myLeftHand.position;
		Instantiate (leftHandEquipped);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
