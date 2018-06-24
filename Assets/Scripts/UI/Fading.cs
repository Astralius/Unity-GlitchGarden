using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{
    [Tooltip("[optional] Time (in seconds) before the effect starts.")]
    public float Delay = 0f;

    [Tooltip("How long does it take for the fading effect to complete.")]
    public float EffectDuration = 1f;

    [Tooltip("True = fade-in, False = fade-out")]
    public bool fadeIn;

    private Image image;
    private Color color;
    private float fadePerSecond;

    private void Awake()
    {
        image = GetComponent<Image>();
        if (!image.enabled)
        {
            image.enabled = true;
        }
    }

    private void Start()
    {        
        color = image.color;
        fadePerSecond = (fadeIn ? color.a : 1 - color.a) / EffectDuration;
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad > Delay + EffectDuration)
        {
            this.enabled = false;
        }

        if (Time.timeSinceLevelLoad > Delay)
        {
            color.a += (fadeIn ? -fadePerSecond : fadePerSecond) * Time.deltaTime;
            image.color = color;
        }      
    }
}
