using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

     void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;
            s.source.volume = s.Volume;
            s.source.pitch = s.pitch;

        }
    }

    public void Play (string name)
    {
        Sound S = Array.Find(sounds, sound => sound.name == name);
        S.source.Play();
    }
    public void Stop(string name)
    {
        Sound S = Array.Find(sounds, sound => sound.name == name);
        S.source.Stop();
    }

}
