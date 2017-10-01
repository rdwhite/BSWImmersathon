using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private Rigidbody mRigidBody;


    private Vector3 posDelta;

    private float velocityFactor = 20000f;

    private float rotationFactor = 400f;
    private Quaternion rotationDelta;
    private float angle;
    private Vector3 axis;
    private bool currentlyInteracting;
    private WandController attachedController = null;
    private HashSet<FixedJoint> joints = new HashSet<FixedJoint>();

    private GameObject collidedObject;

    private CanBePlanted plantable;
    // Use this for initialization
    void Start()
    {
        this.mRigidBody = GetComponent<Rigidbody>();
        this.plantable = GetComponent<CanBePlanted>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentlyInteracting && attachedController != null)
        {
            // posDelta = attachedController.transform.position - interactionPoint.position;

            this.mRigidBody.MovePosition(attachedController.transform.position);
            this.mRigidBody.MoveRotation(attachedController.transform.rotation);

            //mRigidBody.velocity = posDelta * velocityFactor * Time.deltaTime;
            //rotationDelta = attachedController.transform.rotation * Quaternion.Inverse(interactionPoint.rotation);
            //rotationDelta.ToAngleAxis(out angle, out axis);

            //if (angle > 180)
            //{
            //    angle -= 360;
            //}

            //mRigidBody.angularVelocity = (Time.deltaTime * angle * axis) * rotationFactor;
        }
    }

    public void BeginInteraction(WandController controller)
    {




        this.attachedController = controller;
        this.mRigidBody.useGravity = false;
        this.mRigidBody.isKinematic = true;
        foreach (var j in joints)
        {
            j.connectedBody.isKinematic = this.mRigidBody.isKinematic;
        }

        this.currentlyInteracting = true;
        if (this.plantable)
        {
            this.plantable.setIsPlanted(false);
        }
    }

    public void EndInteraction(WandController controller)
    {
        if (controller == attachedController)
        {
            if (this.collidedObject != null)
            {
                var joint = this.gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = collidedObject.GetComponent<Rigidbody>();
                this.joints.Add(joint);
            }

            if (this.plantable)
            {
                if (this.plantable.planterBox != null)
                {
                    this.plantable.setIsPlanted(true);
                }
                else
                {
                    this.plantable.setIsPlanted(false);
                }
            }
            this.mRigidBody.useGravity = true;
            this.mRigidBody.isKinematic = false;
            foreach (var j in joints)
            {
                j.connectedBody.isKinematic = this.mRigidBody.isKinematic;
                Debug.LogWarning(j.currentTorque);
            }
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

    void OnCollisionEnter(Collision collision)
    {
        var c = collision.collider;
        var interactableObject = c.GetComponent<InteractableObject>();
        if (interactableObject != null)
        {
            this.collidedObject = c.gameObject;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // no longer in contact with this object.
        var c = collision.collider;
        var interactableObject = c.GetComponent<InteractableObject>();
        if (interactableObject != null && collidedObject == c.gameObject)
        {
            this.collidedObject = null;
        }
    }
}
