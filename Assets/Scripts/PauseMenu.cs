using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//NU umblati va rog
public class PauseMenu : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameIsPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Back2Menu(){
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("SavesMenu");
    }

    public void Resume(){
        if (settingsMenuUI){
            settingsMenuUI.SetActive(false);
            
        }
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause(){
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitGame(){
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Map");
    }
}
