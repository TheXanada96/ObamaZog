using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// La classe GameManager gestisce la logica principale del gioco
public class GameManager : MonoBehaviour {
    public static GameManager current; // Riferimento statico per accedere facilmente al GameManager

    public AudioClip gameOverSFX; // Clip audio da riprodurre quando il gioco termina

    private bool isGameOver = false; // Variabile per tracciare se il gioco è finito

    void Awake() {
        // Metodo chiamato all'avvio dell'oggetto
        if (current == null) // Verifica se non esiste già un'istanza di GameManager
            current = this; // Imposta l'istanza corrente
    }

    // Funzione per avviare il gioco
    public void StartGame() {
        // Chiama la funzione GameStart dell'UImanager per iniziare l'interfaccia utente
        UImanager.current.GameStart();
        // Avvia il conteggio del punteggio
        ScoreManager.current.StartScore();
        isGameOver = false; // Resetta isGameOver quando il gioco inizia
    }

    // Funzione per terminare il gioco
    public void GameOver() {
        if (!isGameOver) { // Verifica se il gioco è già finito
            isGameOver = true; // Imposta isGameOver su true per evitare chiamate ripetute
            // Chiama la funzione GameOver dell'UImanager per aggiornare l'interfaccia utente
            UImanager.current.GameOver();
            // Ferma il conteggio del punteggio
            ScoreManager.current.StopScore();
            // Riproduce il suono di fine gioco
            AudioManager.current.PlaySound(gameOverSFX);
        }
    }
}
