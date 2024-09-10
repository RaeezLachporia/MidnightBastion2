using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    [SerializeField] public Slider TowerHealthSlider;
    
    void Update()
    {
        
    }

    public void UpdateTowerHealth(float CurrentValue, float MaxValue)
    {
        TowerHealthSlider.value = CurrentValue / MaxValue;
    }




}
