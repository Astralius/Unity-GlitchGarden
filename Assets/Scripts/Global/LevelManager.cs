using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool AutoLoadNextLevelEnabled;
    [Range(0f, 20f)]
    public float AutoLoadDelay;

    private void Start() 
    {
        if (AutoLoadNextLevelEnabled)
        {
            Invoke("LoadNextLevel", AutoLoadDelay);
        }
        else
        {
            Debug.Log("Level auto load disabled.");
        }
        
    }

    public void LoadLevel(string levelName)
    {
        Debug.Log("Attempting to load level: " + levelName + " ...");
        Cursor.visible = true;
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);        
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void LoadNextLevel()
    {
        int nextSceneBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        var nextScene = SceneManager.GetSceneByBuildIndex(nextSceneBuildIndex);
        Debug.Log("Attempting to load next level (" + nextScene.name + ")...");
        SceneManager.LoadScene(nextSceneBuildIndex);
    }
}
