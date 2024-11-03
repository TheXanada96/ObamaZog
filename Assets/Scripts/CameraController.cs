using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// La classe CameraController gestisce il movimento della telecamera in relazione alla palla
public class CameraController : MonoBehaviour {

    // Riferimento al GameObject della palla
    public GameObject Ball;
    
    // Velocità di interpolazione per la telecamera
    public float larpRate;
    
    // Offset della telecamera rispetto alla palla
    Vector3 offset;
    
    // Flag per verificare se il gioco è finito
    public bool gameOver = false;

    // Metodo chiamato quando l'oggetto viene creato in gioco
    void Start() {
        // Calcola la distanza iniziale tra la palla e la telecamera
        offset = Ball.transform.position - transform.position; 
        gameOver = false; // Imposta il flag di fine gioco come falso
    }
    
    // Metodo Update viene chiamato ogni frame
    void Update() {
        // Se il gioco non è finito, chiama il metodo per seguire la palla
        if (!gameOver) {
            FollowBall();
        }
    }

    // Metodo per far seguire alla telecamera la palla
    void FollowBall() {
        // Calcola la posizione attuale della telecamera
        Vector3 pos = transform.position; 
        
        // Calcola la posizione target della telecamera, sottraendo l'offset dalla posizione della palla
        Vector3 targetPos = Ball.transform.position - offset;
        
        // Interpola tra la posizione attuale della telecamera e la posizione target
        pos = Vector3.Lerp(pos, targetPos, larpRate * Time.deltaTime);
        
        // Aggiorna la posizione della telecamera
        transform.position = pos;
    }
}
