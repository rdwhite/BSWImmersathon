using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midrightsnap : MonoBehaviour {



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
		

		if (collider.tag == "Roof") {
			spRoofPole = collider.gameObject;
			spRoofPole.SetActive (false);
			roofPole.SetActive (true);
		}
	}

}
