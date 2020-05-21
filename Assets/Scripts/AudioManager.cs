﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    // Start is called before the first frame update
    public AudioSource[] soundEffects;
    public AudioSource bgm, levelEndMusic;
    void Awake() {
      instance = this;   
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();

        soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);

        soundEffects[soundToPlay].Play();
    }
}
