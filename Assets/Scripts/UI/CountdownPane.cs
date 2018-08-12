using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class CountdownPane : MonoBehaviour
{   
    [SerializeField]
    private Text countText;
    [SerializeField]
    private Text winText;

    private LevelManager levelManager;
    private AudioSource audioSource;
    private Slider slider;
    private int current;
    private int max;
    private bool hasWon;

    private void Awake()
    {
        audioSource.volume = PlayerPrefsManager.MasterVolume;
    }

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
        if (levelManager == null)
        {
            Debug.LogError("Could not find a Level Manager in the scene!");
        }
    }

    public void Initialize(int maxValue)
    {       
        if (maxValue <= 0)
        {
            throw new ArgumentException("Initializing value must be greater than zero!");
        }

        this.current = maxValue;
        this.max = maxValue;
        slider = GetComponent<Slider>();
        slider.minValue = 0;
        slider.maxValue = max;

        UpdateDisplay();
    }

    public void Decrement()
    {
        current = (current <= 0) ? 0 : current - 1;
        UpdateDisplay();
        if (current == 0 && !hasWon)
        {
            Victory();
        }
    }

    private void Victory()
    {
        hasWon = true;

        DestroyAllObjects();

        if (winText)
        {
            winText.gameObject.SetActive(true);
        }

        if (audioSource)
        {
            Debug.Log(audioSource.clip.ToString());
            Invoke("LoadWinScreen", audioSource.clip.length);
            audioSource.Play();
        }
        else
        {
            LoadWinScreen();
        }
    }

    private void DestroyAllObjects()
    {
        foreach (var taggedObject in GameObject.FindGameObjectsWithTag("DestroyOnWin"))
        {
            Destroy(taggedObject);
        }
    }
    
    public void UpdateDisplay()
    {
        slider.value = current;
        countText.text = current + "/" + max;
    }

    public void LoadWinScreen()
    {
        levelManager.LoadLevel("03a Win");
    }
}
