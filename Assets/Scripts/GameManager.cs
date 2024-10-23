using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager current;

void Awake() {
	if (current == null)
		current = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StartGame(){
		UImanager.current.GameStart();
		ScoreManager.current.StartScore();
	}
	public void GameOver(){
		UImanager.current.GameOver();
		ScoreManager.current.StopScore();
	}
}

