using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnRigidBodyLinkHandler(object sender);

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

    // Update is called once per frame
    void Update()
    {
        if (parentBody != null)
        {
            this.selfBody.isKinematic = true;
            this.transform.parent = parentBody.transform;
        }
    }
}
