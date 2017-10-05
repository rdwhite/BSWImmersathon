using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midleftsnap : MonoBehaviour {

	public GameObject midLeftPole;
	public GameObject trashMLPole;


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

			trashMLPole.SetActive (false);
			midLeftPole.SetActive (true);
		}

		if (shortPoles.tag == "Roof") {
			spRoofPole.SetActive (false);
			roofPole.SetActive (true);
		}
	}

}

