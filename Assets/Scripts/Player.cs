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
    }

    public int getPuntos() {
        return puntuacion;
    }

    public void muere() {
        vivo = false;
        //animacion de muerte y pop up opciones
        options.GetComponent<OptionsInGame>().Opciones();
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
