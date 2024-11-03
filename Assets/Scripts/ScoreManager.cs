using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gestisce il punteggio e l'high score nel gioco
public class ScoreManager : MonoBehaviour {
    public static ScoreManager current; // Istanza statica per l'accesso globale
    int score; // Punteggio attuale del giocatore
    int highScore; // Record del punteggio più alto
    bool highScorePlayed; // Flag per verificare se l'audio dell'high score è stato riprodotto
    public AudioClip highScoreSFX; // Suono da riprodurre quando si ottiene un nuovo high score
    public AudioClip DiamondSFX; // Suono da riprodurre quando si ottiene un diamante

    void Awake() {
        // Imposta l'istanza statica se non è già stata impostata
        if (current == null)
            current = this;
    }

    // Start è chiamato prima del primo frame update
    void Start () {
        score = 0; // Inizializza il punteggio a zero
        highScorePlayed = false; // Reimposta il flag per l'high score
    }

    // Incrementa il punteggio di 1
    public void IncrementScore() {
        score += 1; // Aumenta il punteggio

        // Mostra il punteggio aggiornato nella UI
        UImanager.current.diamondLabel.text = score.ToString();

        // Controlla se esiste un high score salvato
        if (PlayerPrefs.HasKey("highScore")) {
            // Controlla se il punteggio attuale supera l'high score salvato
            if (score > PlayerPrefs.GetInt("highScore") && !highScorePlayed) {
                UImanager.current.highScoreText.SetActive(true); // Mostra il messaggio di high score
                AudioManager.current.PlaySound(highScoreSFX); // Riproduci il suono dell'high score
                highScorePlayed = true; // Imposta il flag per evitare ripetizioni
            }
        }
    }

    // Aggiunge un punteggio casuale per l'ottenimento di un diamante
    public void DiamondScore() {
        // Genera un numero casuale tra 5 e 15
        int rand = Random.Range(5, 15);
        score += rand; // Aumenta il punteggio

        // Aggiorna l'etichetta del punteggio nella UI
        UImanager.current.diamondLabel.text = score.ToString();
        
        // Riproduce il suono per l'ottenimento di un diamante
        AudioManager.current.PlaySound(DiamondSFX);

        // Controlla se il nuovo punteggio è maggiore dell'high score
        if (PlayerPrefs.HasKey("highScore")) {
            if (score > PlayerPrefs.GetInt("highScore") && !highScorePlayed) {
                UImanager.current.highScoreText.SetActive(true);
                AudioManager.current.PlaySound(highScoreSFX);
                highScorePlayed = true; // Imposta highScorePlayed a true per evitare di riprodurre di nuovo il suono
            }
        } else {
            // Se non esiste un high score salvato, imposta l'high score e mostra il messaggio
            PlayerPrefs.SetInt("highScore", score);
            UImanager.current.highScoreText.SetActive(true);
            AudioManager.current.PlaySound(highScoreSFX);
            highScorePlayed = true; // Imposta highScorePlayed
        }

        // Salva l'high score nel caso sia stato superato
        PlayerPrefs.Save();
    }

    // Avvia il conteggio del punteggio
    public void StartScore() {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f); // Incrementa il punteggio ogni 0.5 secondi
    }

    // Ferma il conteggio del punteggio
    public void StopScore() {
        CancelInvoke("IncrementScore"); // Ferma l'incremento del punteggio

        // Registra l'ultimo punteggio ottenuto
        PlayerPrefs.SetInt("score", score);
        
        // Registra l'high score solo se il punteggio attuale è maggiore dell'high score salvato
        if (PlayerPrefs.HasKey("highScore")) {
            if (score > PlayerPrefs.GetInt("highScore")) {
                PlayerPrefs.SetInt("highScore", score); // Aggiorna l'high score
            }
        } else {
            // Se non esiste un high score salvato, impostalo
            PlayerPrefs.SetInt("highScore", score);
        }
        
        // Salva le modifiche in PlayerPrefs
        PlayerPrefs.Save();
    }
}
