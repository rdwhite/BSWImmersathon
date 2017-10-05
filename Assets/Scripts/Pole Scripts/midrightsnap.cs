using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midrightsnap : MonoBehaviour {

	public GameObject midRightPole;
	public GameObject trashMRPole;


	public GameObject roofPole;
	public GameObject spRoofPole;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider shortPoles)
	{
		if (shortPoles.tag == "shortPole") {

			trashMRPole.SetActive (false);
			midRightPole.SetActive (true);
		}

		if (shortPoles.tag == "Roof") {
			spRoofPole.SetActive (false);
			roofPole.SetActive (true);
		}
	}

}
