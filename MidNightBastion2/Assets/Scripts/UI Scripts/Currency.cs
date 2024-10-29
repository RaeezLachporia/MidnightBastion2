using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{

    [SerializeField] public int startingCurrency = 15; //players starting currency
    [SerializeField] public int[] towerCosts = { 10, 25, 35 };
    [SerializeField] public TMP_Text currencyText;

    [SerializeField] public int presentCurrency;

    public int currentTowerCost;

    void Start()
    {
        presentCurrency = startingCurrency;//on start game checks for starting currency and makes it the present currency using the CurrencyUI method
        CurrencyUI();
        currentTowerCost = towerCosts[0];
    }

    
    void Update()
    {
        /*if (presentCurrency == towerCost)
        {
            if (Input.GetMouseButton(0)) //if player presses left mouse button game checks for what present currency is and if the player cna afford if not then the return method runs
            {
                PlaceTower();
            }
        }
        else if (presentCurrency > towerCost)
        {
            return;
        }*/
        if (presentCurrency == currentTowerCost && Input.GetMouseButtonDown(0)) // Place tower if there’s enough currency
        {
            PlaceTower();
        }


    }

    public void SetTowerCost(int towerIndex)
    {
        if (towerIndex >=0 && towerIndex < towerCosts.Length)
        {
            currentTowerCost = towerCosts[towerIndex];
        }
    }
    public void PlaceTower()
    {
        if(presentCurrency >= currentTowerCost)
        {
            presentCurrency -= currentTowerCost; //checks if player has enough money to place tower if not the they will not be able to
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
