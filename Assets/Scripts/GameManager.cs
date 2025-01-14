using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// La classe GameManager gestisce la logica principale del gioco
public class GameManager : MonoBehaviour
{
    public static GameManager current; // Riferimento statico per accedere facilmente al GameManager

    public AudioClip[] gameOverSFX; // Array di clip audio per il Game Over

    private bool isGameOver = false; // Variabile per tracciare se il gioco è finito

    void Awake()
    {
        // Metodo chiamato all'avvio dell'oggetto
        if (current == null) // Verifica se non esiste già un'istanza di GameManager
            current = this; // Imposta l'istanza corrente
    }

    // Funzione per avviare il gioco
    public void StartGame()
    {
        // Chiama la funzione GameStart dell'UImanager per iniziare l'interfaccia utente
        UImanager.current.GameStart();
        // Avvia il conteggio del punteggio
        ScoreManager.current.StartScore();
        isGameOver = false; // Resetta isGameOver quando il gioco inizia
    }

    // Funzione per terminare il gioco
    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true; // Imposta isGameOver su true per evitare chiamate ripetute
            // Chiama la funzione GameOver dell'UImanager per aggiornare l'interfaccia utente
            UImanager.current.GameOver();
            // Ferma il conteggio del punteggio
            ScoreManager.current.StopScore();
            // Riproduce un suono casuale di fine gioco
            PlayRandomSound(gameOverSFX);
        }
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
