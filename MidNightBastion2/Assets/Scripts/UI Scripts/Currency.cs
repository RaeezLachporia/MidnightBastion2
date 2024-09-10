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

    [SerializeField] public int presentCurrency;



    void Start()
    {
        presentCurrency = startingCurrency;
        CurrencyUI();
    }

    
    void Update()
    {
        if (presentCurrency == towerCost)
        {
            if (Input.GetMouseButton(0))
            {
                PlaceTower();
            }
        }
        else if (presentCurrency > towerCost)
        {
            return;
        }

        
    }
    public void PlaceTower()
    {
        if(presentCurrency >= towerCost)
        {
            presentCurrency -= towerCost; //checks if player has enough money to place tower if not the they will not be able to
            CurrencyUI(); //calls CurrencyUI method and uses it to update the currency to the textbox

            
        }
        else
        {
            Debug.Log("No Moneys");
        }
    }
    void CurrencyUI()
    {
        currencyText.text = "Currency: " + presentCurrency.ToString(); //updates currency UI textbox
    }
    public void AIGivesCurrency(int moneygiven) //method that is used for the AI to give currency to player when they die
    {
        
        presentCurrency += moneygiven;
        CurrencyUI();

    }

}
