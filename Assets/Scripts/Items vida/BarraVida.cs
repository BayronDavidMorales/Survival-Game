using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarraVida : MonoBehaviour
{
    public PlayerManager playerManager;

    public int cantidad;
    public float damageTime;
    float currentDamageTime;

    public bool isEnemy = false;
    public bool isApple = false;

    public AudioManager audioManager;

    public void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void FixedUpdate()
    {
        if (playerManager.vida < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                if (isEnemy)
                {
                    gameObject.GetComponent<Animator>().SetBool("Attack", true);
                        audioManager.PlayClip(2, 0.2f);
                }
                if (cantidad < 0) { 
                    other.gameObject.GetComponent<Animator>().SetBool("Hurt", true);
                    //if(audioManager.audioSource.isPlaying == false){
                        audioManager.PlayClip(0, 0.5f);
                    //}
                }
                else
                {
                    audioManager.PlayClip(1, 1);
                }
                playerManager.vida += cantidad;
                currentDamageTime = 0.0f;

                if (isApple)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Animator>().SetBool("Hurt", false);
        }
        if (isEnemy)
        {
            gameObject.GetComponent<Animator>().SetBool("Attack", false);
        }
    }
}
