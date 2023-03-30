using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using System.IO;

public class SMInfo : MonoBehaviour{
    public TMP_Text Title;
    public TMP_Text Info;
    public int checkpoint;

    void Start(){
        if (SMOther.CreateSave)
        {
            SaveSystem.SaveGameData(this);
            SMOther.CreateSave = false;
            UnityEngine.Debug.Log("Created Save");
        }
        else
        {
            GameData data = SaveSystem.LoadPlayerData();
            checkpoint = data.checkpoint;
            UnityEngine.Debug.Log("Loaded Save");
        }
        Title.text = "Save " + SMOther.SaveNumber;
        Info.text = "Checkpoint = " + checkpoint + "\nJos Ungaria \nTraiasca Romania Mare \nBalaton e un lighean murdar \nJos Sekelyland";
    }

    public void Load(){
        SceneManager.LoadScene("Map");
    }

    public void OpenFile(){
        Process.Start("explorer.exe", @SaveSystem.path);
    }

    public void Delete(){
        File.Delete(SaveSystem.path + "/save-" + SMOther.SaveNumber + ".ugabuga");
    }

    public void Back()
    {
        SaveSystem.SaveGameData(this);
    }


}
