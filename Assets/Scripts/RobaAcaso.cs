using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// La classe RobaAcaso dimostra variabili, enumerazioni, dizionari e cicli in Unity
public class RobaAcaso : MonoBehaviour {
    // Variabili globali
    private int a = 2; // Un intero
    private int b = 3; // Un altro intero
    private int contatore = 0; // Un contatore per uso nei cicli

    // Altri tipi di variabili
    private int numero = 52; // Un numero intero
    private float virgola = 56.65f; // Un numero con virgola mobile
    private int numeroSpecificato = 45; // Un numero intero specificato
    private float numeroVirgolettato = 9.99969f; // Un altro numero con virgola mobile
    private string stringaProva = "Obama"; // Una stringa di testo
    private bool boolProva = false; // Un valore booleano (vero o falso)
    // private GameObject obama = null; // Un oggetto di gioco (commentato)

    // Enumerazione per gli stati del giocatore
    public enum StatoGiocatore { VIVO, FERITO, MORTO }

    // Dizionario e Array di esempio
    private Dictionary<string, int> punteggi = new Dictionary<string, int>()
    {
        {"Giocatore1", 100}, // Punteggio per Giocatore1
        {"Giocatore2", 150}, // Punteggio per Giocatore2
        {"Giocatore3", 80}   // Punteggio per Giocatore3
    };

    private List<int> numeriArray = new List<int>(){ 1, 2, 3, 4, 5 }; // Un array di numeri

    // Utilizzare gli attributi [SerializeField] o [HideInInspector] per controllare l'esposizione nell'editor di Unity
    [SerializeField]
    private int ses; // Variabile esposta nell'editor di Unity
    [SerializeField]
    private int nonUsato; // Un'altra variabile esposta (non utilizzata)

    // Funzione per sommare tre interi
    private int Somma(int a, int b, int ses)
    {
        // Correzione: la funzione originale moltiplica invece di sommare. Qui sommiamo.
        return a + b + ses; // Restituisce la somma di a, b e ses
    }

    // Funzione per concatenare due stringhe
    private string SommaDue(string a, string b)
    {
        return a + " " + b; // Restituisce la concatenazione di due stringhe
    }

    // Start è chiamato prima del primo frame update
    void Start()
    {
        // Stampa variabili nel log di debug
        Debug.Log(numeroSpecificato + numeroVirgolettato + stringaProva + boolProva);
        Debug.Log(numero);
        Debug.Log(virgola);
        Debug.Log(a + b); // Stampa la somma di a e b
        Debug.Log(Somma(2, 5, ses)); // Stampa il risultato della somma
        Debug.Log(SommaDue("Sesso", "Turkmeno")); // Stampa la concatenazione di due stringhe

        // Chiama la funzione che dimostra variabili e controlli
        IfEcoseVarie();

        // Stampa gli stati dei giocatori usando l'enumerazione
        Debug.Log("Stati dei giocatori: ");
        Debug.Log(StatoGiocatore.VIVO); // Stampa "VIVO"
        Debug.Log(StatoGiocatore.FERITO); // Stampa "FERITO"
        Debug.Log(StatoGiocatore.MORTO); // Stampa "MORTO"

        // Stampa il dizionario dei punteggi
        Debug.Log("Punteggi: " + punteggi);
        // Stampa i numeri nell'array
        Debug.Log("Numeri nell'array: " + string.Join(", ", numeriArray.Select(i => i.ToString()).ToArray()));

        // Ciclo for che itera sull'array
        for (int i = 0; i < numeriArray.Count; i++)
        {
            Debug.Log("Indice: " + i + " Valore: " + numeriArray[i]); // Stampa indice e valore
        }

        // Ciclo for each per iterare sul dizionario
        foreach (KeyValuePair<string, int> entry in punteggi)
        {
            Debug.Log("Giocatore: " + entry.Key + " Punteggio: " + entry.Value); // Stampa giocatore e punteggio
        }
    }

    // Funzione che contiene esempi di if, elif, else, and, or, while, continue, break
    void IfEcoseVarie()
    {
        int voto = 75; // Variabile voto
        if (voto >= 90) // Controlla se il voto è eccellente
        {
            Debug.Log("Voto eccellente!");
        }
        else if (voto >= 80) // Controlla se il voto è molto buono
        {
            Debug.Log("Voto molto buono.");
        }
        else // In tutti gli altri casi
        {
            Debug.Log("Voto sufficiente.");
        }

        int eta = 18; // Variabile età
        bool ha_patente = true; // Controlla se si ha la patente

        // Controlla se si può guidare
        if (eta >= 18 && ha_patente)
        {
            Debug.Log("Puoi guidare!"); // Messaggio se si può guidare
        }
        else
        {
            Debug.Log("Non puoi guidare."); // Messaggio se non si può guidare
        }

        string giorno = "sabato"; // Variabile giorno
        string tempo = "soleggiato"; // Variabile tempo

        // Controlla se è un bel giorno
        if (giorno == "sabato" || tempo == "soleggiato")
        {
            Debug.Log("È un bel sabato!"); // Messaggio se è un bel sabato
        }
        else
        {
            Debug.Log("Forse dovresti restare a casa."); // Messaggio alternativo
        }

        // Ciclo while
        contatore = 0; // Assicurati che il contatore sia reimpostato per evitare loop infiniti
        while (contatore < 5) // Continua finché contatore è minore di 5
        {
            Debug.Log("Contatore: " + contatore); // Stampa il valore del contatore
            contatore++; // Incrementa il contatore
        }

        // Ciclo for each con continue e break
        foreach (int numero in numeriArray)
        {
            if (numero == 3) // Se il numero è 3, salta il resto del ciclo
            {
                continue; // Passa al prossimo numero
            }
            if (numero == 5) // Se il numero è 5, interrompe il ciclo
            {
                break; // Esce dal ciclo
            }
            Debug.Log(numero); // Stampa il numero
        }
    }
}
