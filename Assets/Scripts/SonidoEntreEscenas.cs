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

    [SerializeField] private Slider musicaSlider;
    [SerializeField] private Slider efectosSlider;
    
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

    private void Start()
    {
        setAudioSliders();
    }

    public void CambiarVolumenMusica() {
        musicGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicaSlider.value) *20);
    }

    public void CambiarVolumenEfectos()
    {
        sfxGroup.audioMixer.SetFloat("SFXVolume", Mathf.Log10(efectosSlider.value) * 20);
    }

    public void OnBackOptions()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicaSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", efectosSlider.value);
    }

    public void setAudioSliders() {
        efectosSlider = GameObject.Find("VolumenFX").GetComponent<Slider>();
        musicaSlider = GameObject.Find("VolumenMusica").GetComponent<Slider>();

        efectosSlider.onValueChanged.AddListener(delegate { CambiarVolumenEfectos(); });
        musicaSlider.onValueChanged.AddListener(delegate { CambiarVolumenMusica(); });

        musicaSlider.value = PlayerPrefs.GetFloat("MusicVolume", musicaSlider.value);
        efectosSlider.value = PlayerPrefs.GetFloat("SFXVolume", efectosSlider.value);
    }

}
