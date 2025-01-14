using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gestisce il punteggio e l'high score nel gioco
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager current; // Istanza statica per l'accesso globale
    int score; // Punteggio attuale del giocatore
    int highScore; // Record del punteggio più alto
    bool highScorePlayed; // Flag per verificare se l'audio dell'high score è stato riprodotto

    // Array di suoni per l'high score
    public AudioClip[] highScoreSFX;
    // Array di suoni per l'ottenimento di diamanti
    public AudioClip[] diamondSFX;

    void Awake()
    {
        // Imposta l'istanza statica se non è già stata impostata
        if (current == null)
            current = this;
    }

    void Start()
    {
        score = 0; // Inizializza il punteggio a zero
        highScorePlayed = false; // Reimposta il flag per l'high score
    }

    // Incrementa il punteggio di 1
    public void IncrementScore()
    {
        score += 1; // Aumenta il punteggio

        // Mostra il punteggio aggiornato nella UI
        UImanager.current.diamondLabel.text = score.ToString();

        // Controlla se esiste un high score salvato
        if (PlayerPrefs.HasKey("highScore"))
        {
            // Controlla se il punteggio attuale supera l'high score salvato
            if (score > PlayerPrefs.GetInt("highScore") && !highScorePlayed)
            {
                UImanager.current.highScoreText.SetActive(true); // Mostra il messaggio di high score
                PlayRandomSound(highScoreSFX); // Riproduce un suono casuale per l'high score
                highScorePlayed = true; // Imposta il flag per evitare ripetizioni
            }
        }
    }

    // Aggiunge un punteggio casuale per l'ottenimento di un diamante
    public void DiamondScore()
    {
        // Genera un numero casuale tra 5 e 15
        int rand = Random.Range(5, 15);
        score += rand; // Aumenta il punteggio

        // Aggiorna l'etichetta del punteggio nella UI
        UImanager.current.diamondLabel.text = score.ToString();

        // Riproduce un suono casuale per l'ottenimento di un diamante
        PlayRandomSound(diamondSFX);

        // Controlla se il nuovo punteggio è maggiore dell'high score
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore") && !highScorePlayed)
            {
                UImanager.current.highScoreText.SetActive(true);
                PlayRandomSound(highScoreSFX);
                highScorePlayed = true; // Imposta highScorePlayed a true per evitare di riprodurre di nuovo il suono
            }
        }
        else
        {
            // Se non esiste un high score salvato, imposta l'high score e mostra il messaggio
            PlayerPrefs.SetInt("highScore", score);
            UImanager.current.highScoreText.SetActive(true);
            PlayRandomSound(highScoreSFX);
            highScorePlayed = true; // Imposta highScorePlayed
        }

        // Salva l'high score nel caso sia stato superato
        PlayerPrefs.Save();
    }

    // Metodo per avviare il conteggio del punteggio
    public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f); // Incrementa il punteggio ogni 0.5 secondi
    }

    // Metodo per fermare il conteggio del punteggio
    public void StopScore()
    {
        CancelInvoke("IncrementScore"); // Ferma l'incremento del punteggio

        // Registra l'ultimo punteggio ottenuto
        PlayerPrefs.SetInt("score", score);

        // Registra l'high score solo se il punteggio attuale è maggiore dell'high score salvato
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score); // Aggiorna l'high score
            }
        }
        else
        {
            // Se non esiste un high score salvato, impostalo
            PlayerPrefs.SetInt("highScore", score);
        }

        // Salva le modifiche in PlayerPrefs
        PlayerPrefs.Save();
    }

    // Metodo per riprodurre un suono casuale da un array di AudioClip
    void PlayRandomSound(AudioClip[] clips)
    {
        if (clips != null && clips.Length > 0)
        {
            int randomIndex = Random.Range(0, clips.Length); // Seleziona un indice casuale
            AudioClip clipToPlay = clips[randomIndex];
            AudioManager.current.PlaySound(clipToPlay); // Riproduce il suono
        }
    }
}
