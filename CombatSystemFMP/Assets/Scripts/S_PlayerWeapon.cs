using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerWeapon : MonoBehaviour
{
	enum weapons {quillonDagger, ballockDagger, ridingSword, oakeshottTypeXIV, tomahawk, decoratedIronMace};

	float weight;
	float totalLength;
	public float bladeLength, bladeWidth, bladeDepth;
	float guardLength, guardWidth, guardDepth;
	float hiltLength, hiltWidth, hiltDepth;

	bool hasGuard;

	public GameObject weaponBlade;
	public GameObject weaponGuard;
	public GameObject weaponHilt;

	weapons myCurrentWeapon;

	public Vector3 weaponBladeSize;
	public Vector3 weaponGuardSize;
	public Vector3 weaponHiltSize;

	// Use this for initialization
	void Start ()
	{
		
		myCurrentWeapon = weapons.quillonDagger;
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (myCurrentWeapon)
		{
		case weapons.quillonDagger:
			print ("Quillon Dagger Equipped");

			weight = 0.14f;
			totalLength = 0.2794f;

			bladeLength = 0.18f;
			bladeWidth = 0.02f;
			bladeDepth = 0.01f;

			hasGuard = true;

			if (hasGuard == true)
			{
				guardLength = 0.02f;
				guardWidth = 0.1f;
				guardDepth = 0.02f;
			}

			hiltLength = totalLength - bladeLength;
			hiltWidth = 0.01f;
			hiltDepth = hiltWidth;

		break;


		}


		weaponBladeSize = weaponBlade.transform.localScale;
		weaponBladeSize.y = bladeLength;
		weaponBladeSize.z = bladeWidth;
		weaponBladeSize.x = bladeDepth;

		weaponGuardSize = weaponGuard.transform.localScale;
		weaponGuardSize.y = guardLength;
		weaponGuardSize.z = guardWidth;
		weaponGuardSize.x = guardDepth;

		weaponHiltSize = weaponHilt.transform.localScale;
		weaponHiltSize.y = hiltLength;
		weaponHiltSize.z = hiltWidth;
		weaponHiltSize.x = hiltDepth;

		weaponBlade.transform.localScale = weaponBladeSize;
		weaponGuard.transform.localScale = weaponGuardSize;
		weaponHilt.transform.localScale = weaponHiltSize;
	}
}
