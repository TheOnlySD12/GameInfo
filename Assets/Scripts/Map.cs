using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour{
    public int checkpoint;

    private void Start(){
        // aici voi transforma dharta dupa checkpoint
    }

    public void Back() {
        SceneManager.LoadScene("SaveMenu");
    }

    public void LevelOne() {
        SceneManager.LoadScene("level 1");
    }
}
