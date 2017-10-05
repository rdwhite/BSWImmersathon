using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midleftfrontsnap : MonoBehaviour {

	public GameObject frontMidLeftPole;
	public GameObject trashfrontmidleftPole;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Roof") {
			trashfrontmidleftPole = collider.gameObject;
			trashfrontmidleftPole.SetActive (false);
			frontMidLeftPole.SetActive (true);
		}

	}

}