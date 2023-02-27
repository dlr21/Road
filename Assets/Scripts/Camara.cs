using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

    public Movimiento movimiento;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Vector3.forward * movimiento.carril, movimiento.velocidad * Time.deltaTime);
    }

}
