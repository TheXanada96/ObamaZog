using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RobaAcaso : MonoBehaviour {
    // Variabili globali
    private int a = 2;
    private int b = 3;
    private int contatore = 0;

    // Altri tipi di variabili
    private int numero = 52;
    private float virgola = 56.65f;
    private int numeroSpecificato = 45;
    private float numeroVirgolettato = 9.99969f;
    private string stringaProva = "Obama";
    private bool boolProva = false;
    private GameObject obama = null;

    // Enumerazione per gli stati del giocatore
    public enum StatoGiocatore { VIVO, FERITO, MORTO }

    // Dizionario e Array di esempio
    private Dictionary<string, int> punteggi = new Dictionary<string, int>()
    {
        {"Giocatore1", 100},
        {"Giocatore2", 150},
        {"Giocatore3", 80}
    };

    private List<int> numeriArray = new List<int>(){ 1, 2, 3, 4, 5 };

    // Utilizzare gli attributi [SerializeField] o [HideInInspector] per controllare l'esposizione nell'editor di Unity
    [SerializeField]
    private int ses;
    [SerializeField]


    private int Somma(int a, int b, int ses)
    {
        // Correzione: la funzione originale moltiplica invece di sommare. Qui sommiamo.
        return a + b + ses;
    }

    private string SommaDue(string a, string b)
    {
        return a + " " + b;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(numero);
        Debug.Log(virgola);
        Debug.Log(a + b);
        Debug.Log(Somma(2, 5, ses));
        Debug.Log(SommaDue("Sesso", "Turkmeno"));

        IfEcoseVarie();

        // Stampa gli stati dei giocatori usando l'enumerazione
        Debug.Log("Stati dei giocatori: ");
        Debug.Log(StatoGiocatore.VIVO);
        Debug.Log(StatoGiocatore.FERITO);
        Debug.Log(StatoGiocatore.MORTO);

        Debug.Log("Punteggi: " + punteggi);
        Debug.Log("Numeri nell'array: " + string.Join(", ", numeriArray.Select(i => i.ToString()).ToArray()));

        // Ciclo for che itera sull'array
        for (int i = 0; i < numeriArray.Count; i++)
        {
            Debug.Log("Indice: " + i + " Valore: " + numeriArray[i]);
        }

        // Ciclo for each per iterare sul dizionario
        foreach (KeyValuePair<string, int> entry in punteggi)
        {
            Debug.Log("Giocatore: " + entry.Key + " Punteggio: " + entry.Value);
        }
    }

    // Funzione che contiene esempi di if, elif, else, and, or, while, continue, break
    void IfEcoseVarie()
    {
        int voto = 75;
        if (voto >= 90)
        {
            Debug.Log("Voto eccellente!");
        }
        else if (voto >= 80)
        {
            Debug.Log("Voto molto buono.");
        }
        else
        {
            Debug.Log("Voto sufficiente.");
        }

        int eta = 18;
        bool ha_patente = true;

        if (eta >= 18 && ha_patente)
        {
            Debug.Log("Puoi guidare!");
        }
        else
        {
            Debug.Log("Non puoi guidare.");
        }

        string giorno = "sabato";
        string tempo = "soleggiato";

        if (giorno == "sabato" || tempo == "soleggiato")
        {
            Debug.Log("È un bel sabato!");
        }
        else
        {
            Debug.Log("Forse dovresti restare a casa.");
        }

        // Ciclo while
        contatore = 0; // Assicurati che il contatore sia reimpostato per evitare loop infiniti
        while (contatore < 5)
        {
            Debug.Log("Contatore: " + contatore);
            contatore++;
        }

        // Ciclo for each con continue e break
        foreach (int numero in numeriArray)
        {
            if (numero == 3)
            {
                continue;
            }
            if (numero == 5)
            {
                break;
            }
            Debug.Log(numero);
        }
    }
}