using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        healthSlider.value = currentValue / maxValue;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
