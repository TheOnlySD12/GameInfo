using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

//Cod direct de la Brackeys nu are erori nu schimbati cred ca o sa corupa din cauza fisierului
public class SaveSystem{
     
    public static void SavePlayer(PlayerCombat player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save-" +  SMOther.SaveNumber + ".ugabuga";
        FileStream stream = new FileStream(path, FileMode.Create);
        GameData data = new GameData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadPlayer(){
        string path = Application.persistentDataPath + "/save-" + SMOther.SaveNumber + ".ugabuga";

        if(File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;

        } else {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
