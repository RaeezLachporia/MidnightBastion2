using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyHealthBar HPbar;
    public float health = 100f;
    public float MaxHealth = 100f;
    private void Awake()
    {
        HPbar = GetComponentInChildren<EnemyHealthBar>();
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        HPbar.UpdateHealthBar(health, MaxHealth);
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }
        

}
