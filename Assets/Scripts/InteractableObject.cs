using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private Rigidbody mRigidBody;


    private Vector3 posDelta;

    private float velocityFactor = 10f;

    private float rotationFactor = 400f;
    private Quaternion rotationDelta;
    private float angle;
    private Vector3 axis;
    private bool currentlyInteracting;
    private WandController attachedController = null;
    private Transform interactionPoint;
    // Use this for initialization
    void Start()
    {
        this.mRigidBody = GetComponent<Rigidbody>();
        this.currentlyInteracting = false;
        this.interactionPoint = new GameObject().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlyInteracting && attachedController != null)
        {
            posDelta = attachedController.transform.position - interactionPoint.position;
            this.mRigidBody.velocity = posDelta * velocityFactor * Time.fixedDeltaTime;
            rotationDelta = attachedController.transform.rotation * Quaternion.Inverse(interactionPoint.rotation);
            rotationDelta.ToAngleAxis(out angle, out axis);

            if (angle > 180)
            {
                angle -= 360;
            }

            this.mRigidBody.angularVelocity = (Time.fixedDeltaTime * angle * axis) * rotationFactor;
        }
    }

    public void BeginInteraction(WandController controller)
    {
        this.attachedController = controller;
        this.currentlyInteracting = true;
        this.interactionPoint.transform.position = controller.transform.position;
        this.interactionPoint.transform.rotation = controller.transform.rotation;
        interactionPoint.SetParent(controller.transform);
    }

    public void EndInteraction(WandController controller)
    {
        if (controller == attachedController)
        {
            this.attachedController = null;
            this.currentlyInteracting = false;
        }
    }

    public bool IsInteracting()
    {
        return this.currentlyInteracting;
    }

    public Rigidbody GetRigidbody()
    {
        return this.mRigidBody;
    }
}
