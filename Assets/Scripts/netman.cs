using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkManager_Custom : NetworkManager {

	//[SerializeField] Vector3 playerSpawnPos;
	//[SerializeField] GameObject Helicopter;
	//[SerializeField] GameObject Soldier;

	//bool soldier = true,helicop = true;

	//GameObject choosenCharacter; // Helicopter or Soldier


//	public void HelicopterChoose()
//	{
//		if (helicop) {
//			choosenCharacter = Helicopter;
//			playerSpawnPos = new Vector3 (-112.7f, 4f, -121.4f);
//			helicop = false;
//			JoinGame ();
//		}
//	}

//	public void SoldierChoose()
//	{
//		if (soldier) {
//			choosenCharacter = Soldier;
//			playerSpawnPos = new Vector3 (0f, 0f, 0f);
//			soldier = false;
//			JoinGame ();
//		}
//	}

	public void StartupHost()
	{
		SetPort();
		NetworkManager.singleton.StartHost ();
	}

	public void JoinGame()
	{
		SetIPAddress ();
		SetPort ();
		NetworkManager.singleton.StartClient ();
	}

	void SetIPAddress()
	{
		string ipAdress = "192.168.1.2";
		NetworkManager.singleton.networkAddress = ipAdress;

	}

	void SetPort()
	{
		NetworkManager.singleton.networkPort = 7777;
	}

	void OnLevelWasLoaded(int level)
	{
		if (level == 0) {

			SetupMenuSceneButton ();
		}
	}

	void SetupMenuSceneButton()

	{
		GameObject.Find ("ButtonStartHost").GetComponent<Button> ().onClick.RemoveAllListeners ();
		GameObject.Find ("ButtonStartHost").GetComponent<Button> ().onClick.AddListener (StartupHost);

		//GameObject.Find ("ButtonHelicoppter").GetComponent<Button> ().onClick.RemoveAllListeners ();
		//GameObject.Find ("ButtonHelicoppter").GetComponent<Button> ().onClick.AddListener (HelicopterChoose);

		//GameObject.Find ("ButtonSoldier").GetComponent<Button> ().onClick.RemoveAllListeners ();
		//GameObject.Find ("ButtonSoldier").GetComponent<Button> ().onClick.AddListener (SoldierChoose);

	}

//	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {
//
//		var player = (GameObject)GameObject.Instantiate(choosenCharacter, playerSpawnPos, Quaternion.identity);
//
//		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
//	}
}