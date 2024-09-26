using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {
    public enum SliderType { Music, SoundEffects }
    
    [SerializeField] private Slider volumeSlider;
    private AudioManager audioManager;
    [SerializeField] private SliderType sliderType;
    
    private void Start() {
        volumeSlider.onValueChanged.AddListener (delegate {ChangeVolume();});
        audioManager = AudioManager.instance;
        
        if (sliderType == SliderType.Music) {
            volumeSlider.value = audioManager.GetMusicVolume();
        }
        else {
            volumeSlider.value = audioManager.GetSFXVolume();
        }
    }

    private void ChangeVolume() {
        if (sliderType == SliderType.Music) {
            audioManager.ChangeMusicVolume(volumeSlider.value);
        }
        else {
            audioManager.ChangeSFXVolume(volumeSlider.value);
        }
    }
}