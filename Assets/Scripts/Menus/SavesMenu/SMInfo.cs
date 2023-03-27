using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SMInfo : MonoBehaviour{
    public TMP_Text Title;
    public TMP_Text Info;
    public int checkpoint;

    void Start(){
        if (SMOther.CreateSave)
        {
            SaveSystem.SaveGameData(this);
            SMOther.CreateSave = false;
            Debug.Log("Created Save");
        }
        else
        {
            GameData data = SaveSystem.LoadPlayerData();
            checkpoint = data.checkpoint;
            Debug.Log("Loaded Save");
        }
        Title.text = "Save " + SMOther.SaveNumber;
        Info.text = "Checkpoint = " + checkpoint;
    }

    public void Load(){
        SceneManager.LoadScene("Map");
    }

    public void OpenFile(){
        //nu stiu exact cum dar o sa folosim path din SaveSystem care e static
    }

    public void Delete(){
        //ca la openfile()
    }

    public void Back()
    {
        SaveSystem.SaveGameData(this);
    }


}
