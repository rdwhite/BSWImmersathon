using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frontleftsnap : MonoBehaviour {

	public GameObject poleSwap;
	public GameObject trashPole;

	public GameObject hiddenArch;
	public GameObject trashArch;
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
		if (shortPoles.tag == "Arch") {
			trashArch.SetActive (false);
			hiddenArch.SetActive (true);
		}
	}

}
