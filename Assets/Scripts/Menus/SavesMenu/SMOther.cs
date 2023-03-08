using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SMOther : MonoBehaviour {
    public static int SaveNumber;

    public void QuitGame(){
        Application.Quit();
    }

    public void Back2Menu(){
        SceneManager.LoadScene("SavesMenu");
    }

    public void LoadMap(int save){
        if (File.Exists(Application.persistentDataPath + "/save-" + save + ".ugabuga"))
        {
            // mai am de facut implementare
            SaveNumber = save;
            Debug.Log("Save exists");
            SceneManager.LoadScene("Map");
        }
        Debug.Log("Save doesn't exist.");
        // Aici sistemul va fi mai destept in viitor, va scane pentru save-uri reale si le va arata
    }
}
