using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mundo : MonoBehaviour
{

    public Player pl;
    public int mode;//0start1classic1dark2caos

    public GameObject[] pisosTotales;
    public GameObject[] pisos1;
    public GameObject[] pisos2;

    int carrilesIniciales = 10;
    int carril = 1;

    private void Start()
    {
        if (mode != 0)//si esta en una pantalla distinta a la inicial crea primeros carriles
        {
            for (int i = 0; i < carrilesIniciales; i++)
            {
                CrearCarril();
            }
        }//si esta en la pantalla inicial no se puede mover
        else {
            pl.vivo = false;
        }
    }

    public void CrearCarril() {

        //solo puede ser 1 y 2
        if (mode == 1)//modo 1 aleatorio
        {
            Instantiate(pisosTotales[Random.Range(0, pisosTotales.Length)], Vector3.forward * carril, Quaternion.identity);
        }
        else {//modo 2 con sentido evolutivo
            if (carril < 50)
            {
                Instantiate(pisos1[Random.Range(0, pisos1.Length)], Vector3.forward * carril, Quaternion.identity);
            }
            else {
                Instantiate(pisos2[Random.Range(0, pisos2.Length)], Vector3.forward * carril, Quaternion.identity);
            }
            
        }
        
        carril++;
        Debug.Log(carril);
    }

}
