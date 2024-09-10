using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{

    [SerializeField] public int startingCurrency = 15; //sets starting currency to 15
    [SerializeField] public int towerCost = 10; //sets tower cost to 10 currency
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
            if (Input.GetMouseButton(0)) //when the player presses the left mouse button if they have enough currency they are able to place currency
            {
                PlaceTower();
            }
        }
        else if (presentCurrency > towerCost) //will do else statement if player tries to place tower and will not allow them to if they do not have enough currency
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
            Debug.Log("no moneys");
        }
    }
    public void CurrencyUI()
    {
        currencyText.text = "Currency: " + presentCurrency.ToString(); //updates currency UI textbox

    }
    public void AIGivesCurrency(int moneygiven) //method that is used for the AI to give currency to player when they die
    {
        presentCurrency += moneygiven;
        CurrencyUI();

    }
    
    

}
