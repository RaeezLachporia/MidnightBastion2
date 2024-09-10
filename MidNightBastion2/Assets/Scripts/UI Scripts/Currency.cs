using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{

    [SerializeField] public int startingCurrency = 15;
    [SerializeField] public int towerCost = 10;
    [SerializeField] public TMP_Text currencyText;

    [SerializeField] public int currentCurrency;



    void Start()
    {
        currentCurrency = startingCurrency;
        UpdateCurrencyUI();
    }

    
    void Update()
    {
        if (currentCurrency == towerCost)
        {
            if (Input.GetMouseButton(0))
            {
                PlaceTower();
            }
        }
        else if (currentCurrency > towerCost)
        {
            return;
        }

        
    }
    public void PlaceTower()
    {
        if(currentCurrency>= towerCost)
        {
            currentCurrency -= towerCost;
            UpdateCurrencyUI();

            Debug.Log("Tower Place. Remaining currency:  " + currentCurrency);
        }
        else
        {
            Debug.Log("No Resources");
        }
    }
    void UpdateCurrencyUI()
    {
        currencyText.text = "Currency: " + currentCurrency.ToString();
    }
    /*public void ButtonDisable()
    {
        if (currentCurrency > towerCost)
        {
            this.ButtonDisable();
        }

    }*/

}
