using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject options;

    public AudioSource audioWater;
    public AudioSource audioCar;

    public int puntuacion;
    public bool vivo = true;
    public bool pausado = false;

    private void Start()
    {
        puntuacion = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche")) {
            crash();
            muere();
        }
    }

    public void AumentarPuntos() {
        puntuacion += 10;
        options.GetComponent<OptionsInGame>().puntosUI.GetComponent<TMPro.TextMeshProUGUI>().text = getPuntos().ToString();
    }

    public int getPuntos() {
        return puntuacion;
    }

    public void muere() {
        vivo = false;

        //animacion de muerte y pop up opciones
        if (options != null) {
            options.GetComponent<OptionsInGame>().Opciones(vivo);
        }
        
    }

    public void chof(){
        if(vivo)
        audioWater.Play();
    }

    public void crash()
    {
        if (vivo)
        audioCar.Play();
    }

}
