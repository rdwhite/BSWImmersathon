using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midleftsnap : MonoBehaviour {

	public GameObject poleSwap;
	public GameObject trashPole;

	public GameObject rearLeftPole;
	public GameObject spRearLeftPole;

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

			trashPole.SetActive (false);
			poleSwap.SetActive (true);
		}
		if (shortPoles.tag == "Roof") {
			spRoofPole.SetActive (false);
			roofPole.SetActive (true);
		}
	}

}

