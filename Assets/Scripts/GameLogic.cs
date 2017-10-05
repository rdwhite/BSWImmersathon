using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour
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
        eventSystem.SetActive(false);
        Debug.Log("foo");

    }

    


    public void resetGame()
    {
        restartUI.SetActive(false);
        startUI.SetActive(true);
    }


    public void gameOver()
    { 
        restartUI.SetActive(true);

    }

}