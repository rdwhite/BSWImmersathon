using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSnap : MonoBehaviour {

    public Collider[] colliders;

	public float _unsnapMouseDistance = 25;

	Vector2     _snapMousePos;
	Transform   _snapTarget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this._snapTarget)
		{
			this.transform.parent = this._snapTarget.transform.parent;
			_snapTarget.GetComponentInParent<Rigidbody> ().isKinematic = true;
			if (Vector2.Distance(this._snapMousePos, Input.mousePosition) >= this._unsnapMouseDistance)
			{
				this._snapTarget = null;
				//Here you could also move the object to an appropriate distance regarding the current mouse position so the user feels he got back control of it
				//Also if you have troubles with the trigger being re-triggerer too fast, you could have a add a small timer to prevent it for about half a second...
			}
		}
	}

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.tag =="Pole")
//        {
//
//        }
//    }
	void OnTriggerEnter(Collider collider)
	{
		if(this.enabled && collider.transform.tag == "snappoint")
		{
			this._snapTarget =  collider.transform;
			Debug.Log (this + "found collider" + collider);
			this._snapMousePos = Input.mousePosition;
		}
	}
}


