using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    [SerializeField] private Slider TowerHealthSlider;

    void Start()
    {
        if (TowerHealthSlider != null)
        {
            TowerHealthSlider.maxValue = 1f; // Since we're normalizing health
            TowerHealthSlider.value = 1f;    // Start at full health
        }
        else
        {
            Debug.LogWarning("TowerHealthSlider not assigned in Inspector!");
        }
    }

    public void UpdateTowerHealth(float CurrentValue, float MaxValue)
    {
        if (TowerHealthSlider != null)
        {
            TowerHealthSlider.value = CurrentValue / MaxValue;
        }
        else
        {
            Debug.LogWarning("TowerHealthSlider reference missing!");
        }
    }
    //pt is a carbon copy of the aihealth script and merely acts in place for the tower health

}
