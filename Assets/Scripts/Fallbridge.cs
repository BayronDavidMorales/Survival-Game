using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallbridge : MonoBehaviour
{


    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
