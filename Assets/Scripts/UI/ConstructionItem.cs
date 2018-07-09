using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConstructionItem : MonoBehaviour, IPointerDownHandler
{
    public Defender DefenderPrefab;  

    [SerializeField] 
#pragma warning disable 649
    private Image defenderImage;
#pragma warning restore 649

    public DefenderSelectedEvent DefenderSelected;

    public void Enable()
    {
        defenderImage.color = Color.white;
    }

    public void Disable()
    {
        defenderImage.color = Color.black;
    }

    [Serializable]
    public class DefenderSelectedEvent : UnityEvent<ConstructionItem> {}

    public void OnPointerDown(PointerEventData eventData)
    {
        DefenderSelected.Invoke(this);       
    }
}
