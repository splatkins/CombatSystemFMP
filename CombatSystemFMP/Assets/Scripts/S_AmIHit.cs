using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AmIHit : MonoBehaviour
{
	Material material;

	// Use this for initialization
	void Start ()
	{
		material = GetComponent<Renderer> ().material; // get my material componenet and store it in material
		material.color = Color.grey;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter(Collider other) // when I enter a trigger zone
	{
		//if (other.tag == "PlayerWeapon") // if the trigger is tagged as PLayerWeapon
		//{
			print ("hit"); // print out hit
			material.color = Color.red; // change my colour to red
		//}
	}

	void OnTriggerExit(Collider other) // when I leave a trigger zone
	{
		if (other.tag == "PlayerWeapon") // if the trigger is tagged as PLayerWeapon
		{
			print ("not hit anymore"); // print not hit anymore
			material.color = Color.grey; // change my colour back to grey
		}
	}
}
