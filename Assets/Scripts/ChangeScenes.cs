using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape") && isPaused == false)
        {
            Time.timeScale = 0;
            isPaused = true;
            pause.SetActive(true);
        }
        if (Input.GetKey("escape") && isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            pause.SetActive(false);
        }
    }

    public void PlayScene()
    {
        SceneManager.LoadScene("Juego");
    }    
    
    public void Exitgame()
    {
        Application.Quit();
    }    
    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
        pause.SetActive(false);
    }
}
