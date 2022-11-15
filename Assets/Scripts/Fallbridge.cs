using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallbridge : MonoBehaviour
{
    public AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;

            if (audioManager.audioSource.isPlaying == false)
            {
                audioManager.PlayClip(3, 0.5f);
            }
        }
    }
}
