using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

public GameObject Ball;
public float larpRate;
Vector3 offset;
public bool gameOver = false;



	// Use this for initialization
	void Start () {
		offset = Ball.transform.position - transform.position; // calcola la distanza fra la palla e la camera
	    gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
			FollowBall();
		}
	}

void FollowBall() {
Vector3 pos = transform.position; // calcola la posizione attuale della camera
Vector3 targetPos = Ball.transform.position- offset;
pos = Vector3.Lerp (pos, targetPos, larpRate * Time.deltaTime);
transform.position = pos;
    }
}
