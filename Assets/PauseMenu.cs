using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour 
{

    public static bool GameIsPaused = false

    public GameObject PauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (input.GetKeyDown.Escape))
        {
        if (GameIsPaused) 
            {
             Resume();
            }else
            {
             Pause();
            }
        }
    }

    void Resume () 
    {
     
    }

    void Pause ()
    {
       PauseMenuUI.SetActive(true);
       Time.timeScale = 0f;
       GameIsPaused = true;
    }
}
