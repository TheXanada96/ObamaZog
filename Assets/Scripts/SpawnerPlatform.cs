using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; // Assicura che Random venga utilizzato dalla libreria Unity

// Classe per gestire la generazione di piattaforme e diamanti
public class SpawnerPlatform : MonoBehaviour {

    public GameObject platform; // Riferimento al prefab della piattaforma
    public GameObject diamond; // Riferimento al prefab del diamante
    Vector3 ultimaPos; // Posizione dell'ultima piattaforma generata
    Vector3 pos; // Posizione attuale per la generazione
    float size; // Dimensione della piattaforma
    public bool gameOver; // Stato di fine gioco
    public static SpawnerPlatform current; // Riferimento statico all'istanza corrente della classe

    void Awake() {
        // Imposta l'istanza statica all'inizio
        current = this;
    }

    // Inizializzazione
    void Start () {
        ultimaPos = platform.transform.position; // Imposta l'ultima posizione alla posizione iniziale della piattaforma
        size = platform.transform.localScale.x; // Ottiene la dimensione della piattaforma

        // Genera le prime 20 piattaforme
        for (int i = 0; i < 20; i++) {
            SpawnPlatformer();
        }
        // Puoi attivare la generazione continua qui se necessario
        // cominciaSpawn();
    }

    // Inizia a generare piattaforme ripetutamente
    public void cominciaSpawn() {
        InvokeRepeating("SpawnPlatformer", 1f, 0.2f); // Chiama SpawnPlatformer ogni 0.2 secondi dopo 1 secondo di attesa
    }

    // Aggiornamento di ogni frame
    void Update () {
        // Se il gioco è finito, ferma la generazione delle piattaforme
        if (gameOver) {
            CancelInvoke("SpawnPlatformer");
        }
    }

    // Crea un diamante con una probabilità
    void CreateDiamond() {
        int rand = Random.Range(0, 4); // Genera un numero casuale tra 0 e 3
        if (rand < 1) // C'è una probabilità su quattro di generare un diamante
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1f, pos.z), diamond.transform.rotation);
    }

    // Sposta la posizione per generare una piattaforma lungo l'asse X
    void SpawnX () {
        pos = ultimaPos; // Usa l'ultima posizione
        pos.x += size; // Incrementa la posizione x
        ultimaPos = pos; // Aggiorna l'ultima posizione
        Instantiate(platform, pos, Quaternion.identity); // Crea la piattaforma

        CreateDiamond(); // Potrebbe generare un diamante
    }

    // Sposta la posizione per generare una piattaforma lungo l'asse Z
    void SpawnZ () {
        pos = ultimaPos; // Usa l'ultima posizione
        pos.z += size; // Incrementa la posizione z
        ultimaPos = pos; // Aggiorna l'ultima posizione
        Instantiate(platform, pos, Quaternion.identity); // Crea la piattaforma

        CreateDiamond(); // Potrebbe generare un diamante
    }

    // Genera una piattaforma in modo casuale lungo X o Z
    void SpawnPlatformer() {
        int rand = Random.Range(0, 6); // Genera un numero casuale tra 0 e 5

        // Decidi se generare lungo l'asse X o Z
        if (rand < 3)
            SpawnX(); // Se il numero è 0, 1 o 2, genera lungo X
        else
            SpawnZ(); // Se il numero è 3, 4 o 5, genera lungo Z
    }
}
