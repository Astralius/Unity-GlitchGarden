using UnityEngine;
using UnityEngine.UI;

public class LoseCollider : MonoBehaviour
{
    [SerializeField]
    private Text loseText;

    private AudioSource audioSource;
    private LevelManager levelManager;
    private bool hasLost;

    private void Awake()
    {
        audioSource.volume = PlayerPrefsManager.MasterVolume;
    }

    private void Start()
    {       
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
        if (levelManager == null)
        {
            Debug.LogError("Could not find a Level Manager in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasLost)
        {
            Defeat();
        }      
    }

    private void Defeat()
    {
        hasLost = true;

        if (loseText)
        {
            loseText.gameObject.SetActive(true);
        }

        if (audioSource && !hasLost)
        {
            Invoke("LoadLoseScreen", audioSource.clip.length);
            audioSource.Play();
        }
        else
        {
            LoadLoseScreen();
        }
    }

    private void LoadLoseScreen()
    {
        levelManager.LoadLevel("03b Lose");
    }
}
