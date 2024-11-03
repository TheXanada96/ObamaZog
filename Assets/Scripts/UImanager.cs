using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necessario per gestire le scene
using UnityEngine.UI; // Necessario per utilizzare elementi UI come Text

// Classe per gestire l'interfaccia utente del gioco
public class UImanager : MonoBehaviour {

    public GameObject startPanel; // Riferimento al pannello di avvio
    public GameObject gameOverPanel; // Riferimento al pannello di fine gioco
    public GameObject clickText; // Riferimento al testo di invito a cliccare
    public GameObject diamondText; // Riferimento al testo che mostra i diamanti
    public GameObject highScoreText; // Riferimento al testo dell'high score
    public Text diamondLabel; // Riferimento al componente Text per il punteggio dei diamanti
    public Text score; // Riferimento al componente Text per il punteggio finale
    public Text highScore1; // Riferimento al componente Text per visualizzare l'high score
    public Text highScore2; // Riferimento al componente Text per visualizzare l'high score finale
    public static UImanager current; // Riferimento statico per accedere globalmente all'istanza corrente

    void Awake() {
        // Inizializza l'istanza statica se non è già presente
        if (current == null)
            current = this;
    }

    // Inizializzazione
    void Start () {
        // Controlla se esiste un high score salvato e lo visualizza
        if (PlayerPrefs.HasKey("highScore"))
            highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        else 
            highScore1.text = "High Score: 0"; // Se non esiste, mostra 0
    }

    // Funzione per avviare il gioco
    public void GameStart(){
        // Attiva l'animazione per far scomparire il testo di invito a cliccare
        clickText.GetComponent<Animator>().Play("TextDisappear");
        // Attiva l'animazione per far scomparire il pannello di avvio
        startPanel.GetComponent<Animator>().Play("StartPanelDisappear");

        // Mostra il testo dei diamanti
        diamondText.SetActive(true);
    }
    
    // Funzione per gestire la fine del gioco
    public void GameOver(){
        // Mostra il punteggio finale e l'high score
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true); // Attiva il pannello di fine gioco

        diamondText.SetActive(false); // Nasconde il testo dei diamanti
    }

    // Funzione per riavviare il gioco
    public void Restart(){
        SceneManager.LoadScene(0); // Ricarica la scena iniziale (di solito la scena con l'interfaccia di avvio)
    }
}
