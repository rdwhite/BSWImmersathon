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
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "shortPole") {
			trashMRPole = collider.gameObject;
			trashMRPole.SetActive (false);
			midRightPole.SetActive (true);
		}

		if (collider.tag == "Roof") {
			spRoofPole.SetActive (false);
			roofPole.SetActive (true);
		}
	}

}
