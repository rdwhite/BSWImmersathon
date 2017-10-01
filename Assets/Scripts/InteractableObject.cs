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
    private Transform interactionPoint;
    private HashSet<FixedJoint> joints = new HashSet<FixedJoint>();

    private GameObject collidedObject;

    private CanBePlanted plantable;
    // Use this for initialization
    void Start()
    {
        this.mRigidBody = GetComponent<Rigidbody>();
        this.plantable = GetComponent<CanBePlanted>();
        this.interactionPoint = new GameObject().transform;
        velocityFactor /= mRigidBody.mass;
        rotationFactor /= mRigidBody.mass;
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

        if (collidedObject != null)// remove the joint as soon as we begin interacting with the object.
        {
            var objectBody = collidedObject.GetComponent<Rigidbody>();
            FixedJoint foundJoint = null;
            if (objectBody != null)
            {
                foreach (var j in joints)
                {
                    if (j.connectedBody == objectBody)
                    {
                        foundJoint = j;
                        break;
                    }
                }
            }
            if (foundJoint != null)
            {
                joints.Remove(foundJoint);
                Destroy(foundJoint);
            }
        }

        this.attachedController = controller;
        this.interactionPoint.transform.position = controller.transform.position;
        this.interactionPoint.transform.rotation = controller.transform.rotation;
        interactionPoint.SetParent(controller.transform);
        this.mRigidBody.useGravity = false;
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

    void OnCollissionEnter(Collider c)
    {
        var interactableObject = c.GetComponent<InteractableObject>();
        if (interactableObject != null)
        {
            this.collidedObject = c.gameObject;
        }
    }

    void OnColissionExit(Collider c)
    {
        // no longer in contact with this object.
        var interactableObject = c.GetComponent<InteractableObject>();
        if (interactableObject != null && collidedObject == c.gameObject)
        {
            this.collidedObject = null;
        }
    }
}
