using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPonits : MonoBehaviour
{
    public BasicRigidBodyPush pushBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Push")
        {
            pushBody.canPush = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
