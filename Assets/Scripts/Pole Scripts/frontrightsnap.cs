using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frontrightsnap : MonoBehaviour {

	public GameObject rtPoleSwap;
	public GameObject rtTrashPole;

	public GameObject hiddenArch;
	public GameObject trashArch;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "shortPole") {
			rtTrashPole = collider.gameObject;
			rtTrashPole.SetActive (false);
			rtPoleSwap.SetActive (true);
		}
		if (collider.tag == "Arch") {
			trashArch.SetActive (false);
			hiddenArch.SetActive (true);
		}
	}

}
