using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHpScript : MonoBehaviour
{
    [SerializeField] private TowerHealth TowerHP;
    public float Thealth = 100f;
    public float TmaxHP = 100f;

    private void Awake()
    {
        if (TowerHP == null)
        {
            TowerHP = GetComponent<TowerHealth>();
        }
    }

    public void towerTakingDamage(float amount)
    {
        Thealth -= amount;
        Thealth = Mathf.Clamp(Thealth, 0, TmaxHP); // Prevents health from going below 0
        TowerHP.UpdateTowerHealth(Thealth, TmaxHP);

        if (Thealth <= 0)
        {
            Destroy(gameObject); // Destroys the tower when health reaches 0
        }
    }
}
