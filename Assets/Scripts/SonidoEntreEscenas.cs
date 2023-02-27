using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SonidoEntreEscenas : MonoBehaviour
{

    private SonidoEntreEscenas _instance;

    public SonidoEntreEscenas Instance {
        get {
            return _instance;
        }
    }

    [SerializeField] private AudioMixerGroup musicGroup;
    [SerializeField] private AudioMixerGroup sfxGroup;

    
    public Slider musicaSlider;
    public Slider efectosSlider;

    void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        }

        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void CambiarVolumenMusica() {
        musicGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicaSlider.value) *20);
    }

    public void CambiarVolumenEfectos()
    {
        sfxGroup.audioMixer.SetFloat("SFXVolume", Mathf.Log10(efectosSlider.value) * 20);
    }

}