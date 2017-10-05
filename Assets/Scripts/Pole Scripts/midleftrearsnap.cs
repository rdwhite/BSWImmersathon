using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midleftrearsnap : MonoBehaviour {



	public GameObject rearLeftPole;
	public GameObject spRearLeftPole;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider collider)
	{
		
		if (collider.tag == "shortPole") {
			spRearLeftPole = collider.gameObject;
			spRearLeftPole.SetActive (false);
			rearLeftPole.SetActive (true);
		}

	}

}

