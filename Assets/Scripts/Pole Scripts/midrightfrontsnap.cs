using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midrightfrontsnap : MonoBehaviour {


	public GameObject frontMidRightPole;
	public GameObject trashfrontmidrightPole;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Roof") {
			trashfrontmidrightPole = collider.gameObject;
			trashfrontmidrightPole.SetActive (false);
			frontMidRightPole.SetActive (true);
		}

	}

}
