using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyHealthBar HPbar;
    public float health = 100f;
    public float MaxHealth = 100f;

    public int currencyDrop = 5;

    private Currency currencyPickup;

    




    void Start()
    {
        
    }

    
    private void Awake()
    {
        HPbar = GetComponentInChildren<EnemyHealthBar>();
        currencyPickup = FindObjectOfType<Currency>();
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        HPbar.UpdateHealthBar(health, MaxHealth);
        if (health<=0)
        {
            Destroyed();
        }
        
    }
    void Destroyed()
    {
        currencyPickup.AIGivesCurrency(currencyDrop);

        Destroy(gameObject);

        Debug.Log("you R getting rich");
    }
    
   



}
