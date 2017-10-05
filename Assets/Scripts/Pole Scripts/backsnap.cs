using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backsnap : MonoBehaviour {

	public GameObject rearRoofPole;
	public GameObject trashrearRoofPole;


	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "rearRoof") {

			trashrearRoofPole.SetActive (false);
			rearRoofPole.SetActive (true);
		}

	}

}