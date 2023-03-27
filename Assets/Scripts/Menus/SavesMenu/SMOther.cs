using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SMOther : MonoBehaviour {
    public static int SaveNumber;
    public static bool CreateSave;

    public void QuitGame(){
        Application.Quit();
    }

    public void Back2Menu(){
        SceneManager.LoadScene("SavesMenu");
    }

    public void LoadSave(int save){
        if (File.Exists(Application.persistentDataPath + "/save-" + save + ".ugabuga"))
        {
            SaveNumber = save;
            Debug.Log("Save exists");
        } else
        {
            SaveNumber = save;
            CreateSave = true;
            Debug.Log("Save doesn't exist");
        }
        // Aici sistemul va fi mai destept in viitor, va scane pentru save-uri reale si le va arata
    }
}
