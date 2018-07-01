using UnityEngine;

public class SetStartVolumeFromPrefs : MonoBehaviour
{
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefsManager.MasterVolume;
        source.Play();
    }
}
