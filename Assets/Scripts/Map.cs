using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour{
    public int checkpoint;

    private void Start(){
        // aici voi transforma dharta dupa checkpoint
        // jos ungaria jos szekelyland
    }

    public void Back() {
        SceneManager.LoadScene("SavesMenu");
    }

    public void LevelOne() {
        SceneManager.LoadScene("level 1");
    }
}
