using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] musicSounds, effectSounds;
    private Sound currentSound;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        foreach(Sound s in musicSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
        }
    }

    private void Start()
    {
        PlayMusic(0);
    }

    public void PlayMusic(int index)
    {
        if(index >= musicSounds.Length)
        {
            Debug.Log("Index out bound");
        }
        else
        {
            if (currentSound != null)
            {
                currentSound.source.Stop();
            }
            Sound s = musicSounds[index];
            s.source.Play();
            s.source.loop = true;
            currentSound = s;
        }
        
    }

    

    public void PlayEffect(string name)
    {
        Sound s = Array.Find(effectSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            
            
        }
    }

    public void ChangeSong()
    {
        if (currentSound != null)
        {
            currentSound.source.Stop();
        }
        int index = Array.FindIndex(musicSounds, x => x.name == currentSound.name);

        index = (index + 1) % musicSounds.Length;

        PlayMusic(index);

    }
}
