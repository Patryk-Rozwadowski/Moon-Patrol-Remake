using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    //public static AudioManager instance; //powstrzymuje przed powieleniem obiektu przy przejściu między scenami
    
    void Awake ()
    {
        //DontDestoryOnLoad(gameObject); //może przechodzić między scenami nie przerywając audio
        /*if (instance == null)
            instance = this;
        else
        {
            Destory(gameObject);
            return;
        }*/ //sprawdzenie, czy obietk już istnieje w scenie i niszczenie duplikatu

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("Theme");
    }


    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + "not found!");
            return;
        }
        s.source.Play();
    }
}
