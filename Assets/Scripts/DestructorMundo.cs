using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorMundo : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Suelo") || other.gameObject.layer == LayerMask.NameToLayer("Water")) {
            Destroy(other.transform.parent.gameObject);
        }
        
    }

}
