using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class spawnscript : NetworkBehaviour {
	public GameObject rightContSource;

	public GameObject leftContSource;

	public GameObject headObjSource;

	public GameObject ipadcamSource;

	public GameObject tentPrefab;
	public GameObject ipadCamPrefab;
	public GameObject headPrefab;
	public GameObject lefthandPrefab;
	public GameObject righthandPrefab;
	public float sendInterval = .01f;
	// Use this for initialization
	GameObject ipadcam;
	GameObject head;
	GameObject lefthand;
	GameObject righthand;

	public override void OnStartServer() {
		ipadcam = (GameObject)Instantiate(ipadCamPrefab);
		head = (GameObject)Instantiate(headPrefab);
		lefthand = (GameObject)Instantiate(lefthandPrefab);
		righthand = (GameObject)Instantiate(righthandPrefab);
		var tent = (GameObject)Instantiate(tentPrefab, transform.position, transform.rotation);
		NetworkServer.Spawn (tent);
		NetworkServer.Spawn (ipadcam);
		NetworkServer.Spawn (head);
		NetworkServer.Spawn (lefthand);
		NetworkServer.Spawn (righthand);
	}
	void update()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		//sync pos on network
		CmdControllerPositionSync();
	}
	//sync position on VR controller objects so that VR player movemnts/action can be viewd by normal user
	[Command]
	public void CmdControllerPositionSync()
	{

		head.transform.localRotation = headObjSource.transform.localRotation;
		head.transform.position = headObjSource.transform.position;
		lefthand.transform.localRotation = leftContSource.transform.localRotation;
		righthand.transform.localRotation = rightContSource.transform.localRotation;
		lefthand.transform.localPosition = leftContSource.transform.position;
		righthand.transform.localPosition = rightContSource.transform.position;
		ipadcam.transform.localPosition = ipadcamSource.transform.position;
		ipadcam.transform.localPosition = ipadcamSource.transform.position;
	}
}
