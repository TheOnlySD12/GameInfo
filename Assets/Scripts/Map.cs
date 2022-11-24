using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Map : MonoBehaviour
{
    public void Back() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LevelOne() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelOneTest() {
        SceneManager.LoadScene("SaveMoveTest");
        PlayerData data = SaveSystem.LoadPlayer();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    public void QuitGame() {
        Application.Quit();
    }
}
