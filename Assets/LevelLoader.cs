using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    
    public void LoadLevel (int sceneIndex)
    {
        
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex)

        while (operation.isDone)
        {
            Debug.log(operation.progress);

            yield return null;
        }
    }
}
