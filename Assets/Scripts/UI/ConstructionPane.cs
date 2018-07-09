using System;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionPane : MonoBehaviour
{
    private readonly List<ConstructionItem> availableDefenders = new List<ConstructionItem>();
    private Defender selectedDefender;

    public GameObject SelectedDefenderPrefab
    {
        get
        {
            GameObject result = null;
            if (selectedDefender)
            {
                result = selectedDefender.gameObject;
            }
            return result;
        }
        set
        {
            var defender = value.GetComponent<Defender>();
            if (defender)
            {
                selectedDefender = defender;
            }
            else
            {
                throw new ArgumentException("Only Defenders allowed! (i.e. GameObjects with Defender component)");
            }
        }
    }

    public void UpdateSelection(ConstructionItem selectedItem)
    {
        if (!availableDefenders.Contains(selectedItem))
        {
            availableDefenders.Add(selectedItem);
        }

        availableDefenders.ForEach(defender => defender.Disable());

        if (selectedItem != null)
        {
            if (selectedDefender == selectedItem.DefenderPrefab)
            {
                selectedItem.Disable();
                selectedDefender = null;
            }
            else
            {
                selectedItem.Enable();
                selectedDefender = selectedItem.DefenderPrefab;
            }          
        }
        else
        {
            Debug.LogWarning("Calling UpdateSelection with null has no effect!");
        }
    }
}
