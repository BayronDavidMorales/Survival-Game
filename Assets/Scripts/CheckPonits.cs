using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPonits : MonoBehaviour
{
    public bool activePush = false;
    public BasicRigidBodyPush pushBody;

    public LayerMask pushLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Push")
        {
            //pushBody.canPush = activePush;
            other.GetComponent<Rigidbody>().isKinematic = !activePush;
        }
        if(other.tag == "Player")
        {
            Debug.Log("Entro");
            pushBody.canPush = activePush;
        }
    }
}
