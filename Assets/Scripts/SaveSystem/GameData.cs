using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData  {

    //Checkpoint trebuie implementat in level
    public int checkpoint;

    public GameData (Map map_data) {
        checkpoint = map_data.checkpoint;
    }
    
}
