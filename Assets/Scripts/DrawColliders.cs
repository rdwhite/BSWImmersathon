using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawColliders : MonoBehaviour
{

    public bool drawColliders;

    void Start()
    {

    }

    void OnDrawGizoms()
    {
        if (!drawColliders)
        {
            return;
        }
        BoxCollider b = GetComponent<BoxCollider>();
        Transform t = GetComponent<Transform>();

        // Draw BoxColliders
        if (b != null)
        {
            Vector3 tl = new Vector3(t.position.x - (b.size.x / 2), t.position.y + (b.size.y / 2), 0f);
            Vector3 bl = new Vector3(t.position.x - (b.size.x / 2), t.position.y - (b.size.y / 2), 0f);
            Vector3 br = new Vector3(t.position.x + (b.size.x / 2), t.position.y - (b.size.y / 2), 0f);
            Vector3 tr = new Vector3(t.position.x + (b.size.x / 2), t.position.y + (b.size.y / 2), 0f);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(tl, bl);
            Gizmos.DrawLine(bl, br);
            Gizmos.DrawLine(br, tr);
            Gizmos.DrawLine(tr, tl);
        }
    }
}
