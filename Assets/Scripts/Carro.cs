using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{

    public float velocidad;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0, velocidad*Time.deltaTime);
    }
}
