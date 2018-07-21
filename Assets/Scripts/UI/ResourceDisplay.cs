using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour
{
    private Text AmountText;

    private void Start()
    {
        AmountText = GetComponentInChildren<Text>();
    }

    public void UpdateAmount(int difference, int newTotal, ResourceOperationType operationType)
    {
        AmountText.text = newTotal.ToString();
        // TODO: Add animation based on difference and operationType
    }
}
