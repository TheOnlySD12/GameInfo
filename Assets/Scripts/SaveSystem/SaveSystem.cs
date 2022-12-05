using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

//Cod direct de la Brackeys nu are erori nu schimbati cred ca o sa corupa din cauza fisierului
public class SaveSystem{
     
    public static void SavePlayer(PlayerCombat player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.ugabuga";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer(){
        string path = Application.persistentDataPath + "/player.ugabuga";

        if(File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;

        } else {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
