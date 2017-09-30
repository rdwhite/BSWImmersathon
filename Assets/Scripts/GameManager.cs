using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            DestroyObject(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
