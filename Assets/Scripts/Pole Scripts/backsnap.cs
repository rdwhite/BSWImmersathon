using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backsnap : MonoBehaviour {

	public GameObject rearRoofPole;
	public GameObject trashrearRoofPole;


	void OnTriggerEnter(Collider shortPoles)
	{
		if (shortPoles.tag == "rearRoof") {

			trashrearRoofPole.SetActive (false);
			rearRoofPole.SetActive (true);
		}

	}

}