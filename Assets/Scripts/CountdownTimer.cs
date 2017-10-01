using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void CountdownTimerEvent(int timeLeft);

public class CountdownTimer : MonoBehaviour
{

    public static CountdownTimer instance = null;

    public event CountdownTimerEvent TimerStart;
    public event CountdownTimerEvent TimerStop;
    public event CountdownTimerEvent TimerAdd;
    public event CountdownTimerEvent TimerRemove;
    public event CountdownTimerEvent TimerExpire;
    public event CountdownTimerEvent TimerTick;

    public float initialTime = 90.0f;
    private float timeLeft;
    private bool stopped = true;

    public void startTimer()
    {
        stopped = false;
        this.TimerStart((int)this.timeLeft);
    }

    public void stopTimer()
    {
        stopped = true;
        this.TimerStop((int)this.timeLeft);
    }

    public void setTime(float timeToSet)
    {
        this.timeLeft = timeToSet;
    }

    public void addTime(float timeToAdd)
    {
        this.timeLeft += timeToAdd;
        this.TimerAdd((int)this.timeLeft);
    }

    public void removeTime(float timeToRemove)
    {
        this.timeLeft -= timeToRemove;
        this.TimerRemove((int)this.timeLeft);
    }

    void Awake()
    {

        //SINGLETON
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        this.timeLeft = this.initialTime;
        this.updateTime();
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
            this.updateTime();
        }
        else
        {
            this.TimerExpire(0);
        }
    }

    private void updateTime()
    {
        int left = (int)timeLeft;
       
        this.TimerTick(left);
    }
}
