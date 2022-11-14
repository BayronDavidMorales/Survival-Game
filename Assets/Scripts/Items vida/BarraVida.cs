using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraVida : MonoBehaviour
{
    public PlayerManager playerManager;

    public int cantidad;
    public float damageTime;
    float currentDamageTime;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                playerManager.vida += cantidad;
                currentDamageTime = 0.0f;
            }
        }
    }
}
