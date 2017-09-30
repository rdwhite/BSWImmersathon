using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    public float initialTime = 90.0f;
    public Text timerText;
    public string flavorText = "Time Left";

    private float timeLeft;
    private bool stopped = true;

    public void startTimer()
    {
        stopped = false;
    }

    public void stopTimer()
    {
        stopped = true;
    }

    public void setTime(float timeToSet)
    {
        this.timeLeft = timeToSet;
    }

    public void addTime(float timeToAdd)
    {
        this.timeLeft += timeToAdd;
    }

    public void removeTime(float timeToRemove)
    {
        this.timeLeft -= timeToRemove;
    }

    // Use this for initialization
    void Start()
    {
        this.timeLeft = this.initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopped)
        {
            return;
        }
        timeLeft -= Time.deltaTime;
        if (timeLeft >= 0)
        {
            int minutes = Mathf.FloorToInt(timeLeft / 60f);
            int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
            this.timerText.text = string.Format("{2} {0:0}:{1:00}", minutes, seconds, flavorText);
        }
        else
        {
            // do somethign here
        }
    }
}
