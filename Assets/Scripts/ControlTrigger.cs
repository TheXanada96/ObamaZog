using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Ball") { 
			// chiamo la void che fa cadere la piattaforma 
			Invoke ("PlatformFall", 0.5f); // chiama la void dopo 0.5 secondi
		}
	}
	void PlatformFall () {
		GetComponentInParent<Rigidbody>().useGravity = true;
		GetComponentInParent<Rigidbody>().isKinematic = false;

		Destroy (transform.parent.gameObject, 2f);
	}

}
