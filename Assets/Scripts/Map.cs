using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Map : MonoBehaviour
{
    private void Start(){
        if (File.Exists(Application.persistentDataPath + "/player.ugabuga")) {
            GameData data = SaveSystem.LoadPlayer();
            // nu mai am timp
            Debug.Log("Loaded Save");
        }
    }

    public void Back() {
        SceneManager.LoadScene("SavesMenu");
    }

    public void LevelOne() {
        SceneManager.LoadScene("level 1");
    }
}
