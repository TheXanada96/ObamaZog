using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager current;
	public AudioClip gameOverSFX;

	private bool isGameOver = false; // Variabile per tracciare se il gioco è finito

	void Awake() {
		if (current == null)
			current = this;
	}

	// Funzione per avviare il gioco
	public void StartGame() {
		UImanager.current.GameStart();
		ScoreManager.current.StartScore();
		isGameOver = false; // Resetta isGameOver quando il gioco inizia
	}

	// Funzione per terminare il gioco
	public void GameOver() {
		if (!isGameOver) { // Verifica se il gioco è già finito
			isGameOver = true; // Imposta isGameOver su true per evitare chiamate ripetute
			UImanager.current.GameOver();
			ScoreManager.current.StopScore();
			AudioManager.current.PlaySound(gameOverSFX);
		}
	}
}
