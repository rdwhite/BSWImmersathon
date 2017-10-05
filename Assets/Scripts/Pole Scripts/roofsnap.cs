using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roofsnap : MonoBehaviour {

	public GameObject topRoofPole;
	public GameObject trashRoofPole;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider shortPoles)
	{
		if (shortPoles.tag == "Roof") {

			trashRoofPole.SetActive (false);
			topRoofPole.SetActive (true);
		}

	}

}

