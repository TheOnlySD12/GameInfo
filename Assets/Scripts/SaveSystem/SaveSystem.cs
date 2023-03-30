using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

//Cod direct de la Brackeys nu are erori nu schimbati cred ca o sa corupa din cauza fisierului
//Balaton este un lighean murdar
public class SaveSystem{
    public static string path = Path.Combine(Application.persistentDataPath.Replace('/', Path.DirectorySeparatorChar));

    public static void SaveGameData(SMInfo map_data){
        BinaryFormatter formatter = new BinaryFormatter();
        Debug.Log("SaveNumber = " + SMOther.SaveNumber);
        string path = Application.persistentDataPath + "/save-" +  SMOther.SaveNumber + ".ugabuga";
        FileStream stream = new FileStream(path, FileMode.Create);
        GameData data = new GameData(map_data);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadPlayerData(){
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
