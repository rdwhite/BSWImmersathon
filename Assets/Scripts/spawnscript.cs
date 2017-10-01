using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class spawnscript : NetworkBehaviour {

	public GameObject tentPrefab;
	// Use this for initialization
	public override void OnStartServer() {


		var tent = (GameObject)Instantiate(tentPrefab, transform.position, transform.rotation);
		NetworkServer.Spawn(tent);
	}
	void Start () {
		
	}
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
