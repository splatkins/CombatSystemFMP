using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CurrentWeapon : MonoBehaviour
{
	//public Transform myLeftHand;
	//public Transform myRightHand;

	//public List<GameObject> oneHandedWeapons = new List<GameObject> ();
	//public List<GameObject> shields = new List<GameObject> ();

	//public GameObject leftHandEquipped;
	//public GameObject rightHandEquipped;

	//int currentWeaponIndex;

	public GameObject quillionDagger;
	public GameObject ballockDagger;
	public GameObject ridingSword;
	public GameObject oakeshottTypeXIV;
	public GameObject tomahawk;
	public GameObject decoratedIronMace;
	public GameObject shield;

	// Use this for initialization
	void Start ()
	{
		// initial weapon
		quillionDagger.SetActive (true);
		shield.SetActive (true);

		ballockDagger.SetActive (false);
		ridingSword.SetActive (false);
		oakeshottTypeXIV.SetActive (false);
		tomahawk.SetActive (false);
		decoratedIronMace.SetActive (false);

//		leftHandEquipped = shields [0];
//		//leftHandEquipped.transform.position = myLeftHand.position;
//		Instantiate (leftHandEquipped, myLeftHand.position, Quaternion.identity, this.transform);
//
//		rightHandEquipped = oneHandedWeapons [0];
//		//rightHandEquipped.transform.position = myRightHand.position;
//
//		Instantiate (rightHandEquipped, myRightHand.position, Quaternion.Euler (30, 0, 0), this.transform);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.X))
		{
			if (quillionDagger.activeInHierarchy == true)
			{
				quillionDagger.SetActive (false);
				ballockDagger.SetActive (true);
				print ("Ballock Dagger Equipped");
			}
			else if (ballockDagger.activeInHierarchy == true)
			{
				ballockDagger.SetActive (false);
				ridingSword.SetActive (true);
				print ("Riding Sword Equipped");
			}
			else if (ridingSword.activeInHierarchy == true)
			{
				ridingSword.SetActive (false);
				oakeshottTypeXIV.SetActive (true);
				print ("Oakshott Type XIV Equipped");
			}
			else if (oakeshottTypeXIV.activeInHierarchy == true)
			{
				oakeshottTypeXIV.SetActive (false);
				tomahawk.SetActive (true);
				print ("Tomahawk Equipped");
			}
			else if (tomahawk.activeInHierarchy == true)
			{
				tomahawk.SetActive (false);
				decoratedIronMace.SetActive (true);
				print ("Decorated Iron Mace Equipped");
			}
			else if (decoratedIronMace.activeInHierarchy == true)
			{
				decoratedIronMace.SetActive (false);
				quillionDagger.SetActive (true);
				print ("Quillion Dagger Equipped");
			}
		}
//		if (Input.GetKeyDown (KeyCode.X))
//		{
//			currentWeaponIndex = currentWeaponIndex + 1;
//
//			if (currentWeaponIndex > oneHandedWeapons.Count - 1)
//			{
//				currentWeaponIndex = 0;
//			}
//
//			rightHandEquipped = oneHandedWeapons [currentWeaponIndex];
//			Instantiate (rightHandEquipped, myRightHand.position, Quaternion.Euler (30, 0, 0), this.transform);
//			print ("change weapon");
//		}
	}
}
