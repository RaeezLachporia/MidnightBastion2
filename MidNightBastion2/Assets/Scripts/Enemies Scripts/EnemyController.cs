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

    public int currencyDrop = 5; //currency amount that enemies drop

    private Currency currencyPickup; //reference to currency script
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
            Destroyed(); //calls upon destroyed method that adds currency and destoys dead ai
        }
    }
    void Destroyed()
    {
        currencyPickup.AIGivesCurrency(currencyDrop);

        Destroy(gameObject);

        Debug.Log("you R getting rich");
    }


}
