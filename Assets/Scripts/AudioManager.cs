using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Questa classe gestisce la riproduzione dei suoni nel gioco.
// Permette di riprodurre suoni senza interrompere quelli già in corso.
public class AudioManager : MonoBehaviour {

    // Rende disponibile una sola istanza di AudioManager, accessibile tramite AudioManager.current
    public static AudioManager current;

    // Componente AudioSource usato per riprodurre i suoni
    private AudioSource audioSource;

    // Metodo chiamato quando l'oggetto viene creato in gioco
    void Awake() {
        // Controlla se non esiste già un'istanza di AudioManager
        // Se non c'è, assegna l'istanza corrente alla variabile 'current'
        if (current == null)
            current = this;
        
        // Recupera il componente AudioSource associato a questo oggetto
        audioSource = GetComponent<AudioSource>();

        // Controlla se l'oggetto non ha già un AudioSource
        if (audioSource == null) {
            // Aggiunge un AudioSource al GameObject, necessario per riprodurre suoni
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Metodo per riprodurre un suono senza interrompere suoni già in corso
    public void PlaySound(AudioClip clip) {
        // Imposta il volume dell'audio (0.5f è la metà del volume massimo)
        audioSource.volume = 0.5f;

        // Usa PlayOneShot per riprodurre l'audio una volta, sovrapponendolo ad altri eventuali suoni
        audioSource.PlayOneShot(clip);
    }
}
