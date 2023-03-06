using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Map : MonoBehaviour
{
    private void Start(){
        // aici va da load la map din save ul folosit
    }

    public void Back() {
        SceneManager.LoadScene("SavesMenu");
    }

    public void LevelOne() {
        SceneManager.LoadScene("level 1");
    }
}
