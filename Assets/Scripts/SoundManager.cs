using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioClip[] audioClip;

    private int index = 0;
    private AudioSource audioSource;
    
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        
        PlayMusic();
    }

    private void Update()
    {
        
    }

    private void PlayMusic()
    {        
        audioSource.Play();
    }
}
