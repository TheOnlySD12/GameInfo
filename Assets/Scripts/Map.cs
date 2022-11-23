using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Map : MonoBehaviour
{
    public void BackAScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame() {
        Application.Quit();
    }

 //Aici nu cred ca se incarca ca inca nu merge scena voi rezolva eu Armand
    public void LoadPlayer() {
        if (File.Exists(Application.persistentDataPath + "/player.ugabuga")) {
            PlayerData data = SaveSystem.LoadPlayer();
            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.position = position;
        }
    }
}
