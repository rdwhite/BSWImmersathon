using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBySecond : MonoBehaviour
{


    public float XRotateAmount = 1f;
    public float YRotateAmount = 1f;
    public float ZRotateAmount = 1f;

    private Quaternion initialRotation;
    private bool shouldRotate;
    private bool restoreRotation = false;
    // Use this for initialization
    void Start()
    {
        this.initialRotation = this.transform.rotation;
        if (CountdownTimer.instance != null)
        {
            CountdownTimer.instance.TimerStart += Instance_TimerStart;
            CountdownTimer.instance.TimerExpire += Instance_TimerExpire;
        }
    }

    private void Instance_TimerExpire(int timeLeft)
    {
        //this.shouldRotate = false;
        //this.restoreRotation = true;
    }

    private void Instance_TimerStart(int timeLeft)
    {
        this.shouldRotate = true;
    }

    // Update is called once per frame
    void Update()
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
    }
}
