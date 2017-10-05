using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rearleftsnap : MonoBehaviour {

	public GameObject midrearPole;
	public GameObject trashmidrearPole;

	public GameObject backPole;
	public GameObject trashbackPole;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider shortPoles)
	{
		if (shortPoles.tag == "shortPole") {

			trashmidrearPole.SetActive (false);
			midrearPole.SetActive (true);
		}
		if (shortPoles.tag == "rearPole") {
			trashbackPole.SetActive (false);
			backPole.SetActive (true);
		}
	}

}
