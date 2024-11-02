using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
	public static ScoreManager current;
	int score;
	int highScore; 
	bool highScorePlayed;
	public AudioClip highScoreSFX;
	public AudioClip DiamondSFX;

	void Awake() {
	if (current == null)
		current = this;
	}

	// Use this for initialization
	void Start () {
		score = 0;
		highScorePlayed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void IncrementScore(){
	score += 1;

	// mostro il punteggio nella Labal
	UImanager.current.diamondLabel.text = score.ToString();
	

	if (PlayerPrefs.HasKey("highScore")){
		if (score > PlayerPrefs.GetInt("highScore") && !highScorePlayed) {
			UImanager.current.highScoreText.SetActive(true);
			AudioManager.current.PlaySound(highScoreSFX);
			highScorePlayed = true;
			}
		}
	}
	public void DiamondScore(){
    // Genera un numero casuale tra 5 e 15
    int rand = Random.Range(5, 15);
    score += rand;

    // Aggiorna l'etichetta del punteggio
    UImanager.current.diamondLabel.text = score.ToString();
    
    // Riproduce il suono per l'ottenimento di un diamante
    AudioManager.current.PlaySound(DiamondSFX);

    // Controlla se il nuovo punteggio è maggiore dell'high score e se il suono high score non è già stato riprodotto
    if (PlayerPrefs.HasKey("highScore")) {
        if (score > PlayerPrefs.GetInt("highScore") && !highScorePlayed) {
            UImanager.current.highScoreText.SetActive(true);
            AudioManager.current.PlaySound(highScoreSFX);
            highScorePlayed = true; // Imposta highScorePlayed a true per evitare di riprodurre di nuovo il suono
        }
    } else {
        // Se non esiste un highScore salvato, imposta l'highScore e mostra il messaggio
        PlayerPrefs.SetInt("highScore", score);
        UImanager.current.highScoreText.SetActive(true);
        AudioManager.current.PlaySound(highScoreSFX);
        highScorePlayed = true;
    }

    // Salva l'high score nel caso sia stato superato
    PlayerPrefs.Save();
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
