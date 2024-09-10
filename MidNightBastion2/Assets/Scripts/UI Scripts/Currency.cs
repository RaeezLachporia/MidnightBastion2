using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{

    [SerializeField] public int startingCurrency = 15; //players starting currency
    [SerializeField] public int towerCost = 10;//tower cost
    [SerializeField] public TMP_Text currencyText;

    [SerializeField] public int presentCurrency;



    void Start()
    {
        presentCurrency = startingCurrency;//on start game checks for starting currency and makes it the present currency using the CurrencyUI method
        CurrencyUI();
    }

    
    void Update()
    {
        if (presentCurrency == towerCost)
        {
            if (Input.GetMouseButton(0)) //if player presses left mouse button game checks for what present currency is and if the player cna afford if not then the return method runs
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
