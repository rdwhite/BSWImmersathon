using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class spawnscript : NetworkBehaviour {

	public GameObject tentPrefab;
	public GameObject ipadCamPrefab;
	// Use this for initialization


	public override void OnStartServer() {
		var ipadcam = (GameObject)Instantiate(ipadCamPrefab, transform.position, transform.rotation);

		var tent = (GameObject)Instantiate(tentPrefab, transform.position, transform.rotation);
		NetworkServer.Spawn(tent);
	}
	public override void OnStartClient (){
		var ipadcam = (GameObject)Instantiate(ipadCamPrefab, transform.position, transform.rotation);
		NetworkServer.Spawn (ipadcam);

	}

	void Start () {
		
	}
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
