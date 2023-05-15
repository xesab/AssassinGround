using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    public Slider _MusicSlider, _SFXSlider;
    
    private void Start() {
        _MusicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        _SFXSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    public void MusicVolume(){
        float Musicvolume = _MusicSlider.value;
        PlayerPrefs.SetFloat("musicVolume",Musicvolume);
        AudioManager.Instance.musicVolume(Musicvolume);
        _MusicSlider.value = Musicvolume;
    }

    public void SFXVolume(){
        float SFXvolume = _SFXSlider.value;
        PlayerPrefs.SetFloat("sfxVolume",SFXvolume);
        AudioManager.Instance.sfxVolume(SFXvolume);
        _SFXSlider.value = SFXvolume;
    }
}
