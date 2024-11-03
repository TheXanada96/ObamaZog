using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// La classe BallController gestisce il movimento della palla, il cambio di direzione e la raccolta di diamanti
public class BallController : MonoBehaviour {

    // Prefab per l'effetto di particelle da generare alla raccolta dei diamanti
    public GameObject particle;

    // Suono da riprodurre quando la palla cambia direzione
    public AudioClip directionalSound;

    // Velocità di movimento della palla, visibile solo nell'Inspector grazie a [SerializeField]
    [SerializeField]
    private float speed;

    // Riferimento al componente Rigidbody per controllare la fisica della palla
    Rigidbody rb; 

    // Variabili per controllare se il gioco è iniziato e se è finito
    bool started;
    bool gameOver;

    // Metodo chiamato quando l'oggetto viene creato in gioco
    void Awake() {
        // Ottiene il componente Rigidbody collegato a questo GameObject
        rb = GetComponent<Rigidbody>();
    }

    // Inizializza i valori necessari all'inizio del gioco
    void Start() {
        started = false;  // Il gioco inizia come non avviato
    }

    // Metodo Update viene chiamato ogni frame
    void Update() {
        // Controlla se il gioco è già iniziato
        if (!started) {
            // Avvia il gioco al primo clic del mouse
            if (Input.GetMouseButtonDown(0)) {
                // Imposta la velocità iniziale della palla verso destra
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;  // Il gioco è ora avviato
                
                // Chiama i metodi per avviare la generazione delle piattaforme e per iniziare il gioco
                SpawnerPlatform.current.cominciaSpawn();
                GameManager.current.StartGame();
            }
        }

        // Controlla se la palla non ha piattaforme sotto di essa (il gioco finisce)
        if (!Physics.Raycast(transform.position, Vector3.down, 1f)) {
            gameOver = true;  // Imposta gameOver a true per bloccare altre azioni
            rb.velocity = new Vector3(0, -25f, 0);  // Fa cadere la palla velocemente verso il basso

            // Informa la telecamera e il gestore delle piattaforme che il gioco è terminato
            Camera.main.GetComponent<CameraController>().gameOver = true;
            SpawnerPlatform.current.gameOver = true;

            // Chiama il GameManager per eseguire le azioni di Game Over
            GameManager.current.GameOver();
        }

        // Cambia direzione al clic del mouse, ma solo se il gioco è in corso
        if (Input.GetMouseButtonDown(0) && !gameOver) {
            DirectionalChange();  // Cambia la direzione della palla
            AudioManager.current.PlaySound(directionalSound);  // Riproduce il suono di cambio direzione
        }
    }

    // Metodo per cambiare la direzione della palla
    void DirectionalChange() {
        // Se la palla sta andando in avanti (asse z), cambiala per andare verso destra (asse x)
        if (rb.velocity.z > 0) { 
            rb.velocity = new Vector3(speed, 0, 0);
        }
        // Se la palla sta andando a destra (asse x), cambiala per andare in avanti (asse z)
        else if (rb.velocity.x > 0) {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    // Metodo per gestire le collisioni con oggetti con cui la palla interagisce
    void OnTriggerEnter(Collider col) {
        // Controlla se la palla ha toccato un oggetto con tag "Diamond"
        if (col.gameObject.tag == "Diamond") {
            // Genera un effetto di particelle alla posizione del diamante
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;

            // Distrugge il diamante e le particelle dopo 2 secondi
            Destroy(col.gameObject);
            Destroy(part, 2f);

            // Incrementa il punteggio per la raccolta del diamante
            ScoreManager.current.DiamondScore();
        }
    }
}
