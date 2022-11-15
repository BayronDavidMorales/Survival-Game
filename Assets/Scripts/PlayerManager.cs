using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public ThirdPersonController thirdPersonController;

    public float vida = 100;
    public Image barraDeVida;

    public Animator animator;
    public bool flag = false;


    public AudioSource drag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vida = Mathf.Clamp(vida, 0, 100);
        barraDeVida.fillAmount = vida / 100;
    }

    private void OnTriggerEnter(Collider other)
    {
    }
    private void OntriggerStay(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {
    }



    private void CrawZone(Collider other, bool action)
    {
        if(other.gameObject.tag == "Craw")
        {
            animator.SetBool("Craw", action);
        }
    }
}
