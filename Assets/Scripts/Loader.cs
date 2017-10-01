using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameManager;
    public GameObject countdownTimer;

	void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
        if (CountdownTimer.instance == null)
        {
            Instantiate(countdownTimer);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
