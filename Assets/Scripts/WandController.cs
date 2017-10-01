﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour
{

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;

    public GameObject touchedObject;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    public InteractableObject pickup;

    private GameObject obj;
    private FixedJoint fJoint;

    // Use this for initialization
    void Start()
    {
        this.trackedObj = GetComponent<SteamVR_TrackedObject>();
        fJoint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (controller.GetPressDown(triggerButton))
        {
            if (!this.pickup.IsInteracting())
            {
                this.pickup.BeginInteraction(this);
            }
        }
        if (controller.GetPressUp(triggerButton))
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

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Pickupable")
        {
            obj = other.gameObject;
        }
        this.touchedObject = other.gameObject;
    }

    void OnTriggerExit(Collider other)
    {
        this.pickup = null;
        this.touchedObject = null;
    }

    void PickUpObj()
    {
        if (obj != null)
        {
            fJoint.connectedBody = obj.GetComponent<Rigidbody>();
        }
        else
        {
            fJoint.connectedBody = null;
        }
    }
}
