using UnityEngine;

public class BallRotation : MonoBehaviour
{
    // Riferimento al Rigidbody della palla
    private Rigidbody rb;

    // Velocità di movimento della palla
    [SerializeField]
    private float speed = 50f;

    // Fattore di moltiplicazione per controllare la velocità di rotazione
    public float rotationSpeed = 5f;

    // Metodo chiamato all'inizio per inizializzare i componenti
    void Start()
    {
        // Ottiene il componente Rigidbody collegato alla palla
        rb = GetComponent<Rigidbody>();
    }

    // Metodo FixedUpdate per aggiornare la fisica e la rotazione
    void FixedUpdate()
    {
        // Calcola la direzione del movimento basandosi sulla velocità
        Vector3 movementDirection = rb.velocity;

        // Controlla se la palla si sta effettivamente muovendo
        if (movementDirection.magnitude > 0.1f)
        {
            // Calcola l'asse di rotazione come perpendicolare al movimento e al piano orizzontale
            Vector3 rotationAxis = Vector3.Cross(movementDirection.normalized, Vector3.down);

            // Calcola la quantità di rotazione basata sulla velocità della palla
            float rotationAmount = movementDirection.magnitude * rotationSpeed * Time.fixedDeltaTime;

            // Applica la rotazione alla palla
            transform.Rotate(rotationAxis, rotationAmount, Space.World);
        }
    }

    // Metodo per cambiare direzione
    public void DirectionalChange()
    {
        // Controlla la direzione attuale e cambia verso
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0); // Cambia direzione verso destra
            FlipBall(Vector3.forward);            // Ribalta la palla sull'asse in avanti
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed); // Cambia direzione verso avanti
            FlipBall(Vector3.right);               // Ribalta la palla sull'asse destro
        }
    }

    // Metodo per ribaltare la palla
    private void FlipBall(Vector3 flipAxis)
    {
        // Ruota la palla di 180 gradi attorno all'asse specificato
        transform.Rotate(flipAxis, 180f, Space.World);
    }
}
