using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameLogic : NetworkBehaviour
{

    public GameObject player;
    public GameObject eventSystem;
    public GameObject startUI, restartUI;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void startPuzzle()
    { //Begin the puzzle sequence
        startUI.SetActive(false);
		restartUI.SetActive (true);
        
        Debug.Log("foo");

    }

    


    public void resetGame()
    {
        restartUI.SetActive(false);
        startUI.SetActive(true);
		NetworkManager.singleton.ServerChangeScene("main");
    }


    public void gameOver()
    { 
        restartUI.SetActive(true);

    }

}