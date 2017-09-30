using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour
{

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    private InteractableObject pickup;

    // Use this for initialization
    void Start()
    {
        this.trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.GetPressDown(triggerButton) && this.pickup != null)
        {
            this.pickup.BeginInteraction(this);
        }
        if (controller.GetPressUp(triggerButton) && this.pickup != null)
        {
            this.pickup.EndInteraction(this);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        var pickup = collider.GetComponent<InteractableObject>();
        if (pickup != null)
        {
            this.pickup = pickup;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        var pickup = collider.GetComponent<InteractableObject>();
        if (pickup != null)
        {
            this.pickup = null;
        }
    }
}
