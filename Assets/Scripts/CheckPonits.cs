using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPonits : MonoBehaviour
{
    public bool activePush = false;
    public BasicRigidBodyPush pushBody;

    private bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Push" && flag)
        {
            pushBody.canPush = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            flag = false;
        }
        if(activePush && other.tag == "Player")
        {
            pushBody.canPush = true;
        }
    }
}
