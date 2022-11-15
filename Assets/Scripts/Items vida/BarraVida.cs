using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraVida : MonoBehaviour
{
    public PlayerManager playerManager;

    public int cantidad;
    public float damageTime;
    float currentDamageTime;

    public bool isEnemy = false;
    public bool isApple = false;
    public void Start()
    {

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
                }
                if (cantidad < 0) { 
                    other.gameObject.GetComponent<Animator>().SetBool("Hurt", true);
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
