using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{

    public int startingCurrency = 25;
    public int towerCost = 10;
    public TMP_Text currencyText;

    private int currentCurrency;



    void Start()
    {
        currentCurrency = startingCurrency;
        UpdateCurrencyUI();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaceTower();
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
        currencyText.text = "Currency: " + currencyText.ToString();
    }
}
