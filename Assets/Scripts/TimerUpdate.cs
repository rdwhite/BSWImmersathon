using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerUpdate : MonoBehaviour {

    public Text timerText;
    public string flavorText;
	// Use this for initialization
	void Start () {
		if (CountdownTimer.instance != null)
        {
            CountdownTimer.instance.TimerTick += Instance_TimerTick;
            this.Instance_TimerTick((int)CountdownTimer.instance.initialTime);
        } else
        {
            this.timerText.text = "No countdown timer in scene!";
        }
	}

    private void Instance_TimerTick(int left)
    {
        int minutes = (int)(left / 60f);
        int seconds = (int)(left - minutes * 60);
        this.timerText.text = string.Format("{0} {1:0}:{2:00}", flavorText, minutes, seconds);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
