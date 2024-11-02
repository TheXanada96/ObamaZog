using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager current;
	// public AudioClip highScoreSFX;
	private AudioSource audioSource;

void Awake() {
	if (current == null)
		current = this;
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlaySound(AudioClip clip){
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = clip;
		audioSource.volume = 0.5f;
		audioSource.Play();
	}
}
