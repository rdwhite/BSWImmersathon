using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midrightrearsnap : MonoBehaviour {

	public GameObject rearRightPole;
	public GameObject spRearRightPole;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider collider)
	{

		if (collider.tag == "shortPole") {
			spRearRightPole = collider.gameObject;
			spRearRightPole.SetActive (false);
			rearRightPole.SetActive (true);
		}

	}

}

