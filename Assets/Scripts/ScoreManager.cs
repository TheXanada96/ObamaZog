using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        ResetScore(); // Resetta il punteggio all'inizio
    }

    // Incrementa il punteggio di 1
    public void IncrementScore()
    {
        score += 1; // Aumenta il punteggio
        UImanager.current.diamondLabel.text = score.ToString(); // Aggiorna la UI

        // Controlla se il punteggio supera l'high score
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore") && !highScorePlayed)
            {
                UImanager.current.highScoreText.SetActive(true);
                PlayRandomSound(highScoreSFX);
                highScorePlayed = true;
            }
        }
    }

    // Aggiunge un punteggio casuale per l'ottenimento di un diamante
    public void DiamondScore()
    {
        int rand = Random.Range(5, 15);
        score += rand;
        UImanager.current.diamondLabel.text = score.ToString();
        PlayRandomSound(diamondSFX);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore") && !highScorePlayed)
            {
                UImanager.current.highScoreText.SetActive(true);
                PlayRandomSound(highScoreSFX);
                highScorePlayed = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
            UImanager.current.highScoreText.SetActive(true);
            PlayRandomSound(highScoreSFX);
            highScorePlayed = true;
        }

        PlayerPrefs.Save();
    }

    // Avvia il conteggio del punteggio
    public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
    }

    // Ferma il conteggio del punteggio e aggiorna la UI
    public void StopScore()
    {
        CancelInvoke("IncrementScore");
        UImanager.current.diamondLabel.text = score.ToString();
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }

        PlayerPrefs.Save();
    }

    // Resetta il punteggio
    public void ResetScore()
    {
        score = 0; // Resetta il punteggio a zero
        highScorePlayed = false; // Resetta il flag per l'high score

        // Aggiorna la UI con il punteggio resettato
        UImanager.current.diamondLabel.text = score.ToString();
    }

    // Ottieni il punteggio corrente
    public int GetCurrentScore()
    {
        return score;
    }

    // Riproduce un suono casuale
    void PlayRandomSound(AudioClip[] clips)
    {
        if (clips != null && clips.Length > 0)
        {
            int randomIndex = Random.Range(0, clips.Length);
            AudioClip clipToPlay = clips[randomIndex];
            AudioManager.current.PlaySound(clipToPlay);
        }
    }
}