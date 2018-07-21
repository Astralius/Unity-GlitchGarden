using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    private const int FirstLevelIndex = 0;

    private static readonly PlayerPref<float> masterVolume = new PlayerPref<float>("master_volume");
    private static readonly PlayerPref<int> lastUnlockedLevel = new PlayerPref<int>("level_unlocked");
    private static readonly PlayerPref<string> difficulty = new PlayerPref<string>("difficulty");
    private static readonly PlayerPref<bool> gameFinished = new PlayerPref<bool>("game_finished");

    #region Properties

    public static float MasterVolume
    {
        get { return masterVolume.Value; }
        set
        {
            if (value < 0f && value > 1f)
            {
                Debug.LogError("Master volume out of range!");
            }
            else
            {
                masterVolume.Value = value;
            }
        }
    }

    public static int LastUnlockedLevel
    {
        get { return lastUnlockedLevel.Value; }
        set
        {
            if (value < 0 || value > SceneManager.sceneCountInBuildSettings - 1)
            {
                Debug.LogError("Level index to unlock not present in build order!");
            }
            else if (IsLevelUnlocked(value))
            {
                Debug.LogWarning("Level already unlocked!");
            }
            else
            {
                lastUnlockedLevel.Value = value;
            }
        }
    }

    public static Difficulty Difficulty
    {
        get
        {
            Difficulty result;
            try
            {
                result = (Difficulty) Enum.Parse(typeof(Difficulty), difficulty.Value);
            }
            catch (Exception)
            {
                result = Difficulty.Normal;
            }
            return result;
        }
        set
        {
            if (Difficulty == value)
            {
                Debug.LogWarning("Difficulty already set!");
            }
            else
            {
                difficulty.Value = value.ToString();
            }
        }
    }

    public static bool GameFinished
    {
        get { return gameFinished.Value; }
        set { gameFinished.Value = value; }
    }

    #endregion

    public static bool IsLevelUnlocked(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex > SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.LogError("There is no such level in build order!");
            return false;
        }
        return levelIndex <= lastUnlockedLevel.Value;
    }

    public static void RemoveAllPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public static void ResetGame()
    {
        lastUnlockedLevel.Value = FirstLevelIndex;
        gameFinished.Value = false;
    }
}