using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHpScript : MonoBehaviour
{
    [SerializeField] TowerHealth TowerHP;
    public float Thealth = 100f;
    public float TmaxHP = 100f;

    private void Awake()
    {
        TowerHP = GetComponent<TowerHealth>();
    }

    public void towerTakingDamage(float amount)
    {
        Thealth -= amount;
        TowerHP.UpdateTowerHealth(Thealth, TmaxHP);

        if (Thealth<=0)
        {
            Destroy(gameObject);
        }
    }
}
