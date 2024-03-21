using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

[SerializeField]
	private float speed;

	Rigidbody rb; 

	bool started;

    void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start () {
	started = false;	
	}
	
	// Update is called once per frame
	void Update () {

		if(!started) {
			 if (Input.GetMouseButtonDown(0)) {
				rb.velocity= new Vector3 (speed,0,0);
				started = true;
			 }
		}

		if (Input.GetMouseButtonDown(0)){
			DirectionalChange();
		}
	}

	void DirectionalChange () {
		if (rb.velocity.z > 0) { 
			rb.velocity= new Vector3 (speed,0,0);
		}
		else if (rb.velocity.x > 0) {
			rb.velocity = new Vector3(0, 0, speed);
		}
    }
}
