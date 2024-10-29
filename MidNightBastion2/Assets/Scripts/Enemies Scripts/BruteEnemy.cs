using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteEnemy : MonoBehaviour
{
    public float attackDamage = 20f;
    public float timeInbetweenAttacks = 1f;
    public float lastAttack = 0f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Tower"))
        {
            var tower = collision.gameObject.GetComponent<TowerHpScript>();
            if (tower != null)
            {
                DealDamage(tower);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            TowerHpScript tower = collision.gameObject.GetComponent<TowerHpScript>();
            if (tower != null && Time.time >= lastAttack + timeInbetweenAttacks)
            {
                DealDamage(tower);
                lastAttack = Time.time;
            }
        }
    }

    private void DealDamage(TowerHpScript tower)
    {
        tower.towerTakingDamage(attackDamage);
        Debug.Log("Brute dealt" + attackDamage + "damage to the tower");
    }
}
