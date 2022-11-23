using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData  {

    //Am sa adaug si health si enemy health cand pot eu Armand; nu umblati ma ocup
    public float[] position;

    public PlayerData (PlayerCombat player) {

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
    
}
