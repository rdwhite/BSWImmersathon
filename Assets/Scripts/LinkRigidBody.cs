using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnRigidBodyLinkHandler(object sender, object link);

[RequireComponent(typeof(Rigidbody))]
public class LinkRigidBody : MonoBehaviour
{

    public Rigidbody parentBody;
    private Rigidbody selfBody;

    public event OnRigidBodyLinkHandler OnLink;
    public event OnRigidBodyLinkHandler OnUnlink;

    // Use this for initialization
    void Start()
    {
        this.selfBody = GetComponent<Rigidbody>();
    }

    void SetParent(GameObject parent)
    {
        this.parentBody = parent.GetComponent<Rigidbody>();
        if (parentBody != null)
        {
            this.selfBody.isKinematic = true;
            this.transform.parent = this.parentBody.transform;
            OnLink(this, parentBody);
        }
    }

    void DetachParent()
    {
        this.transform.parent = null;
        this.selfBody.isKinematic = false;
        OnUnlink(this, parentBody);
        this.parentBody = null;
    }
}
