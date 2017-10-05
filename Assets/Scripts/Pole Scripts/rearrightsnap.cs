using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rearrightsnap : MonoBehaviour {

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
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "shortPole") {
			trashmidrearPole = collider.gameObject;
			trashmidrearPole.SetActive (false);
			midrearPole.SetActive (true);
		}
		if (collider.tag == "rearPole") {
			trashbackPole.SetActive (false);
			backPole.SetActive (true);
		}
	}

}