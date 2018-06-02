using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float autoLoadDelay;

    private void Start() 
    {
        Invoke("LoadNextLevel", autoLoadDelay);
    }

    public void LoadLevel(string levelName)
    {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
