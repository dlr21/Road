using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject options;

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
        options.GetComponent<OptionsInGame>().Opciones();
    }

}
