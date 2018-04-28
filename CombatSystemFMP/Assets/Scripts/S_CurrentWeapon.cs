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

	// weapons
	public GameObject quillionDagger;
	public GameObject ballockDagger;
	public GameObject ridingSword;
	public GameObject oakeshottTypeXIV;
	public GameObject tomahawk;
	public GameObject decoratedIronMace;

	// shields
	public GameObject shield;

	public GameObject currentWeapon;
	public GameObject currentShield;

	public float currentWeaponWeight;
	public float currentShieldWeight;

	bool canChangeWeapon;

	// Use this for initialization
	void Start ()
	{
		// initial weapon
		quillionDagger.SetActive (false);
		ballockDagger.SetActive (false);
		ridingSword.SetActive (true);
		oakeshottTypeXIV.SetActive (false);
		tomahawk.SetActive (false);
		decoratedIronMace.SetActive (false);

		shield.SetActive (true);

		currentWeapon = ridingSword;
		currentShield = shield;

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
		canChangeWeapon = GetComponent<S_PlayerController> ().canChangeWeapon;

		if (Input.GetKeyDown (KeyCode.X) && canChangeWeapon == true)
		{
			if (quillionDagger.activeInHierarchy == true)
			{
				quillionDagger.SetActive (false);
				ballockDagger.SetActive (true);
			}
			else if (ballockDagger.activeInHierarchy == true)
			{
				ballockDagger.SetActive (false);
				ridingSword.SetActive (true);
			}
			else if (ridingSword.activeInHierarchy == true)
			{
				ridingSword.SetActive (false);
				oakeshottTypeXIV.SetActive (true);
			}
			else if (oakeshottTypeXIV.activeInHierarchy == true)
			{
				oakeshottTypeXIV.SetActive (false);
				tomahawk.SetActive (true);
			}
			else if (tomahawk.activeInHierarchy == true)
			{
				tomahawk.SetActive (false);
				decoratedIronMace.SetActive (true);
			}
			else if (decoratedIronMace.activeInHierarchy == true)
			{
				decoratedIronMace.SetActive (false);
				quillionDagger.SetActive (true);
			}
		}

		// weapon weights
		if (ballockDagger.activeInHierarchy == true)
		{
			currentWeapon = ballockDagger;
			currentWeaponWeight = 0.94f;
			print ("Ballock Dagger Equipped");
		}
		else if (ridingSword.activeInHierarchy == true)
		{
			currentWeapon = ridingSword;
			currentWeaponWeight = 0.71f;
			print ("Riding Sword Equipped");
		}
		else if (oakeshottTypeXIV.activeInHierarchy == true)
		{
			currentWeapon = oakeshottTypeXIV;
			currentWeaponWeight = 1.10f;
			print ("Oakshott Type XIV Equipped");
		}
		else if (tomahawk.activeInHierarchy == true)
		{
			currentWeapon = tomahawk;
			currentWeaponWeight = 0.57f;
			print ("Tomahawk Equipped");
		}
		else if (decoratedIronMace.activeInHierarchy == true)
		{
			currentWeapon = decoratedIronMace;
			currentWeaponWeight = 1.17f;
			print ("Decorated Iron Mace Equipped");
		}
		else if (quillionDagger.activeInHierarchy == true)
		{
			currentWeapon = quillionDagger;
			currentWeaponWeight = 0.14f;
			print ("Quillion Dagger Equipped");
		}

		// shield weights
		if (shield.activeInHierarchy == true)
		{
			currentShield = shield;
			currentShieldWeight = 1.67f;
			print ("Shield Equipped");
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
