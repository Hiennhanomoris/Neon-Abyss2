using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; 
    public static AudioManager Instaince;

    private void Awake() 
    {
        //singleton
        if(Instaince == null)
        {
            Instaince = this;
        }
        else 
        {
            Destroy(this.gameObject);
            return;
        }

        foreach(Sound s in sounds)
        {
            s.sorce = gameObject.AddComponent<AudioSource>();
            s.sorce.clip = s.clip;
            s.sorce.pitch = s.pitch;
            s.sorce.volume = s.volume;
            s.sorce.loop = s.loop;
        }    
    }

    private void Start() 
    {
        Play("mainLoop");    
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.sorce.Play();
    }
}
