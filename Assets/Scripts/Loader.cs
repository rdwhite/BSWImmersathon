using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameManager;
    public GameObject networkManager;

	void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        if (NetworkManager.instance == null)
        {
            Instantiate(networkManager);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
