using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevolverCoche : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche")) {
            other.transform.parent.gameObject.transform.Translate(0, 0, -35);
        }
    }

}
