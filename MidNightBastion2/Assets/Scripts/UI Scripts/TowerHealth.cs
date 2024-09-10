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


    //this script is a carbon copy of the aihealth script and merely acts in place for the tower health

}
