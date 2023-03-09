using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour{
    public int checkpoint;

    private void Start(){
        GameData data = SaveSystem.LoadPlayerData();
        checkpoint = data.checkpoint;
        Debug.Log("Loaded Save");
    }

    public void Back() {
        SaveSystem.SaveGameData(this);
        SceneManager.LoadScene("SavesMenu");
    }

    public void LevelOne() {
        SceneManager.LoadScene("level 1");
    }
}
