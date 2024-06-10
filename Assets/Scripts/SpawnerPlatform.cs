using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlatform : MonoBehaviour {


 public GameObject platform;
Vector3 ultimaPos;
float size;

	// Use this for initialization
	void Start () {
		ultimaPos = platform.transform.position;
		size = platform.transform.localScale.x;

		for (int i = 0; i<5; i++) {
		SpawnX ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	void SpawnX () {
	Vector3 pos = ultimaPos;
	pos.x+=size;
	ultimaPos = pos;
	Instantiate (platform, pos, Quaternion.identity);
	}

	void SpawnZ () {
	Vector3 pos = ultimaPos;
	pos.z+=size;
	ultimaPos = pos;
	Instantiate (platform, pos, Quaternion.identity);
	}
}
