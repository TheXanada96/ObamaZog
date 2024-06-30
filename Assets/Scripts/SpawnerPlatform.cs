using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnerPlatform : MonoBehaviour {


 public GameObject platform;
Vector3 ultimaPos;
float size;
public bool gameOver;
public static SpawnerPlatform current;

void Awake() {
	current = this;
}

	// Use this for initialization
	void Start () {
		ultimaPos = platform.transform.position;
		size = platform.transform.localScale.x;

		for (int i = 0; i<20; i++) {
		SpawnPlatformer();
		}
		//cominciaSpawn();
	}
	public void cominciaSpawn(){
InvokeRepeating("SpawnPlatformer", 1f, 0.2f);
		
	}
	// Update is called once per frame
	void Update () {
		
		if (gameOver){
			CancelInvoke ("SpawnPlatformer");
		}
		
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

	void SpawnPlatformer() {
	int rand = UnityEngine.Random.Range(0,6);
	
	if (rand < 3)
	SpawnX();
	else
	SpawnZ();
	}
}
