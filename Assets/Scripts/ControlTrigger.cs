using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// La classe ControlTrigger gestisce il comportamento di un oggetto quando un altro oggetto esce da un trigger
public class ControlTrigger : MonoBehaviour {

    // Metodo chiamato quando un oggetto esce dal trigger
    void OnTriggerExit(Collider col)
    {
        // Controlla se l'oggetto che esce dal trigger ha il tag "Ball"
        if (col.gameObject.tag == "Ball") { 
            // Chiama la funzione che fa cadere la piattaforma
            Invoke("PlatformFall", 0.5f); // Chiama la funzione PlatformFall dopo 0.5 secondi
        }
    }

    // Metodo che gestisce la caduta della piattaforma
    void PlatformFall () {
        // Abilita la gravità sul Rigidbody della piattaforma padre
        GetComponentInParent<Rigidbody>().useGravity = true;
        
        // Imposta il Rigidbody della piattaforma padre come non cinetico per permettere la caduta
        GetComponentInParent<Rigidbody>().isKinematic = false;

        // Distrugge il genitore dell'oggetto corrente dopo 2 secondi
        Destroy(transform.parent.gameObject, 2f);
    }
}
