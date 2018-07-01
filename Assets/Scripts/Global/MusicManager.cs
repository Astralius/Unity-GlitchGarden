using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public AudioClip[] Soundtracks;
    private AudioSource audioSource;

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.MasterVolume;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        audioSource.loop = !scene.name.Contains("Win") && !scene.name.Contains("Lose");
        var thisLevelMusic = Soundtracks[scene.buildIndex];
        if (thisLevelMusic)
        {
            if (audioSource.clip == null || !audioSource.clip.name.Equals(thisLevelMusic.name))
            {
                audioSource.Stop();
                audioSource.clip = thisLevelMusic;
                audioSource.Play();
            }            
        }            
    }
}
