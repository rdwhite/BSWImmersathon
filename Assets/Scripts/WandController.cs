using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour
{

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    private GameObject pickup;

    // Use this for initialization
    void Start()
    {
        this.trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.GetPressDown(triggerButton))
        {
            if(this.pickup != null)
            {
                this.pickup.transform.parent = this.transform;
            }
        }
        if (controller.GetPressUp(triggerButton))
        {
            this.pickup.transform.parent = null;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        this.pickup = collider.gameObject;
    }

    void OnTriggerExit(Collider collider)
    {
        this.pickup = null;
    }
}
