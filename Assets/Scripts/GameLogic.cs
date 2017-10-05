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


    public float XRotateAmount = 1f;
    public float YRotateAmount = 1f;
    public float ZRotateAmount = 1f;

    private Quaternion initialRotation;
    private bool shouldRotate;
    private bool restoreRotation = false;

    void Start()
    {
        this.initialRotation = this.transform.rotation;

    }

    private void Instance_TimerStart(int timeLeft)
    {
        this.shouldRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ready == true)
        {

            if (this.shouldRotate)
            {
                this.transform.Rotate(new Vector3(XRotateAmount, YRotateAmount, ZRotateAmount) * Time.deltaTime);
            }
            else if (this.restoreRotation)
            {
                if (this.transform.rotation == initialRotation)
                {
                    this.restoreRotation = false;
                }
                else
                {
                    this.transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, 10.0f);
                }
            }


            if (targetTime <= 0.0f)
            {
                timerEnded();
            }
        }

    }


    public void startPuzzle()
    { //Begin the puzzle sequence
        startUI.SetActive(false);
        targetTime -= Time.deltaTime;
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