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

	// mostro il punteggio nella Labal
	UImanager.current.diamondLabel.text = score.ToString();
	}

	public void DiamondScore(){
		int rand = Random.Range(5,15);
		score += rand;

		UImanager.current.diamondLabel.text = score.ToString();
	}

	public void StartScore(){
		InvokeRepeating("IncrementScore", 0.1f, 0.5f);
	}
	public void StopScore (){
	CancelInvoke("IncrementScore");
	// Registra l'ultimo score ottenuto
	PlayerPrefs.SetInt("score", score);
	
	// Registra l'highScore solo se il punteggio attuale è maggiore dell'highScore salvato
	if (PlayerPrefs.HasKey("highScore")){
		if (score > PlayerPrefs.GetInt("highScore")){
			PlayerPrefs.SetInt("highScore", score);
		}
	}
	else {
		// Se non esiste un highScore salvato, impostalo
		PlayerPrefs.SetInt("highScore", score);
	}
	
	// Non dimenticare di salvare le modifiche in PlayerPrefs
	PlayerPrefs.Save();
		}
	}
