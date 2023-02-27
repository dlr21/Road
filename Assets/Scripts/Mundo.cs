using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mundo : MonoBehaviour
{

    public Player pl;
    public int mode;//0start1classic2dark

    int carril = 1;

    public GameObject[] pisos;
    int carrilesIniciales = 10;

    private void Start()
    {
        if (mode != 0)
        {
            for (int i = 0; i < carrilesIniciales; i++)
            {
                CrearCarril();
            }
        }
        else {
            pl.vivo = false;
        }
    }

    public void CrearCarril() {
        Instantiate(pisos[Random.Range(0,pisos.Length)],Vector3.forward*carril, Quaternion.identity);
        carril++;
    }

}
