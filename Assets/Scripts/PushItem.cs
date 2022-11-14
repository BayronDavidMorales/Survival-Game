using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PushItem : MonoBehaviour
{
    public GameObject player;
    public bool isKinematic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Para que no empuje mientras esta en el aire
        if (player.GetComponent<BasicRigidBodyPush>().canPush)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = player.GetComponent<Animator>().GetBool("Grounded") ? false : true;
            gameObject.GetComponent<Rigidbody>().isKinematic = player.GetComponent<Animator>().GetBool("FreeFall") ? true : false;
        }
    }
}
