using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSound, sfxSound, footSound;
    public AudioSource musicSource, sfxSource, footSource;

    private void Awake() {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
           
    }

    public void playMusic(string name){
        Sound s = Array.Find(musicSound, x => x.name == name);

        if(s == null){
            Debug.Log("No Sound");
        }else{
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void playSFX(string name){
        Sound s = Array.Find(sfxSound, x => x.name == name);

        if(s == null){
            Debug.Log("No Sound");
        }else{
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }
    }

    public void playFoot(){
        name = "FootStep";
        Sound s = Array.Find(footSound, x => x.name == name);

        if(s == null){
            Debug.Log("No Sound");
        }else{
            footSource.clip = s.clip;
            footSource.Play();
        }
    }

    public void stopFoot(){
        footSource.Stop();
        
    }

    public void musicVolume(float volume){
        musicSource.volume = volume;
    }

    public void sfxVolume(float volume){
        sfxSource.volume = volume;
        footSource.volume = volume;
    }
}
