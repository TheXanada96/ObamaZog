using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
	public static ScoreManager current;
	int score;
	int highScore; 

	void Awake() {
	if (current == null)
		current = this;
	}

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void IncrementScore(){
	score += 1;
	}

	public void StartScore(){
		InvokeRepeating("IncrementScore", 0.1f, 0.5f);
	}
	public void StopScore (){
		CancelInvoke ("IncrementScore");
		//registro l'ultimo score ottenuto
		PlayerPrefs.SetInt("score",score);
		//registro l'highScore ottenuto
		if (PlayerPrefs.HasKey("highScore")){
			if (score > PlayerPrefs.GetInt("highScore")){
				PlayerPrefs.SetInt("highScore", score);
			}
			else 
				PlayerPrefs.SetInt("highScore", score);
		}
	}
}
