using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//Szekelyland nu exista
public class GameData  {

    //Checkpoint trebuie implementat in level
    public int checkpoint;

    public GameData (SMInfo map_data) {
        checkpoint = map_data.checkpoint;
    }
    
}
