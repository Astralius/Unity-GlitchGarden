using System;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider VolumeSlider;
    public TextToggleButton DifficultyToggle;

    private MusicManager musicManager;
    private const float MediumVolume = 0.5f;


    public void ChangeVolume()
    {
        if (musicManager)
        {
            musicManager.SetVolume(VolumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music manager in the scene - Volume will not be changed!");
        }
    }

    public void ChangeDifficulty(string difficulty)
    {
        try
        {
            var parsedDifficulty =
                (Difficulties) Enum.Parse(typeof(Difficulties), DifficultyToggle.CurrentText.text, true);
            // TODO: Change the actual game's difficulty
            Debug.Log("Difficulty changed to: " + parsedDifficulty);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }    
    }

    public void SetDefaults()
    {
        VolumeSlider.value = MediumVolume;
        DifficultyToggle.TryChangeText(Difficulties.Normal.ToString());
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.MasterVolume = VolumeSlider.value;
        PlayerPrefsManager.Difficulty = (Difficulties) Enum.Parse(typeof(Difficulties), DifficultyToggle.CurrentText.text, true);
    }

    private void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        SetDefaults();
        VolumeSlider.value = PlayerPrefsManager.MasterVolume;
        DifficultyToggle.TryChangeText(PlayerPrefsManager.Difficulty.ToString());
        DifficultyToggle.OnClick.AddListener(ChangeDifficulty);
    }   
}
