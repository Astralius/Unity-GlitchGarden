using System;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionPane : MonoBehaviour
{
    private readonly List<ConstructionItem> buttons = new List<ConstructionItem>();
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
        buttons.ForEach(button => button.Disable());

        if (selectedItem != null)
        {
            if (!buttons.Contains(selectedItem))
            {
                buttons.Add(selectedItem);
            }

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
            selectedDefender = null;
        }
    }

    public void DeselectEverything()
    {
        UpdateSelection(null);
    }
}
