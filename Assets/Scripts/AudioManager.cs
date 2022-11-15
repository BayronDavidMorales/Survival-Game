using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(int index, float vol)
    {
        audioSource.PlayOneShot(clips[index], vol);
    }
    public void PauseClip(int index, float vol)
    {
        audioSource.Pause();
    }
}
