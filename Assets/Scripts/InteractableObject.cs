using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private Rigidbody mRigidBody;

    private bool currentlyInteracting;
    private WandController attachedController = null;
    private IList<FixedJoint> joints = new List<FixedJoint>();

    private Collider[] colliders;

    private GameObject collidedObject;

    private CanBePlanted plantable;
    // Use this for initialization
    void Start()
    {
        this.mRigidBody = GetComponent<Rigidbody>();
        this.plantable = GetComponent<CanBePlanted>();
        this.colliders = this.GetComponentsInChildren<Collider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentlyInteracting && attachedController != null)
        {
            // posDelta = attachedController.transform.position - interactionPoint.position;

            this.mRigidBody.MovePosition(attachedController.transform.position);
            this.mRigidBody.MoveRotation(attachedController.transform.rotation);
            this.mRigidBody.velocity = Vector3.zero;
            this.mRigidBody.angularVelocity = Vector3.zero;


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
        foreach (Collider c in this.colliders)
        {
            if (!c.CompareTag("AttachPoint"))
            {
                c.enabled = false;
            }
            else
            {
                c.isTrigger = true;
            }
        }
        foreach (var j in joints)
        {
            j.connectedBody.isKinematic = this.mRigidBody.isKinematic;
        }
        if (this.plantable)
        {
            this.plantable.setIsPlanted(false);
        }
        this.currentlyInteracting = true;
    }

    public void EndInteraction(WandController controller)
    {
        if (controller == attachedController)
        {

            if (this.collidedObject != null)
            {
                if (this.joints.Where(i => i.connectedBody == collidedObject.GetComponent<Rigidbody>()).FirstOrDefault() == null)
                {
                    var joint = this.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = collidedObject.GetComponent<Rigidbody>();
                    this.joints.Add(joint);
                }
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
            foreach (Collider c in this.colliders)
            {
                c.enabled = true;
                if (c.CompareTag("AttachPoint"))
                {
                    c.isTrigger = false;
                }
            }
            foreach (var j in joints)
            {
                j.connectedBody.isKinematic = this.mRigidBody.isKinematic;
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
        var contactPoint = collision.contacts[0];
        var thisCollider = collision.contacts[0].thisCollider;
        if (c.CompareTag("AttachPoint") && thisCollider.CompareTag("AttachPoint"))
        {
            var interactableObject = c.GetComponentInParent<InteractableObject>();
            if (interactableObject != null)
            {
                this.collidedObject = interactableObject.gameObject;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // no longer in contact with this object.
        var c = collision.collider;
        var interactableObject = c.GetComponentInParent<InteractableObject>();
        if (interactableObject != null && collidedObject == c.gameObject)
        {
            this.collidedObject = null;
        }
    }
}
