using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
#pragma warning disable 649

public class ConstructionItem : MonoBehaviour, IPointerDownHandler
{
    public Defender DefenderPrefab;
   
    [SerializeField]
    private Image defenderImage;
    [SerializeField]
    private Text lightCostText;

    public DefenderSelectedEvent DefenderSelected;

    private void Start()
    {
        if (lightCostText)
        {
            lightCostText.text = DefenderPrefab.LightCost.ToString();
        }
        else
        {
            throw new MissingReferenceException(
                "Missing Light Cost Text reference for construction button: " + 
                DefenderPrefab.name);
        }
        
    }

    public void Enable()
    {
        defenderImage.color = Color.white;
    }

    public void Disable()
    {
        defenderImage.color = Color.gray;
    }

    [Serializable]
    public class DefenderSelectedEvent : UnityEvent<ConstructionItem> {}

    public void OnPointerDown(PointerEventData eventData)
    {
        DefenderSelected.Invoke(this);       
    }
}
