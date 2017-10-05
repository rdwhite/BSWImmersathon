using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameLogic : NetworkBehaviour
{

    public GameObject player;
    public GameObject eventSystem;
    public GameObject startUI, restartUI;

    public float targetTime = 600.0f;
    public bool ready = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ready == true)
        {
            targetTime -= Time.deltaTime;


            if (targetTime <= 0.0f)
            {
                timerEnded();
            }
        }

    }


    public void startPuzzle()
    { //Begin the puzzle sequence
        startUI.SetActive(false);
    
        ready = true;
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

    void timerEnded()
    {
        restartUI.SetActive(true);
        ready = false;
        //do your stuff here.
    }

}