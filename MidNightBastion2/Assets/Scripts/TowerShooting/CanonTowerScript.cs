using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTowerScript : MonoBehaviour
{
    public float enemyDetectionRadius = 40f;
    public float fireRate = 1f;
    public GameObject Canonprojectile;
    public Transform shootPosition;
    public Transform EnemyTarget;
    public float nextShotTimer;

    // Update is called once per frame
    void Update()
    {
        DetectingEnemy();

        if (EnemyTarget != null)
        {
            ShootThem();
        }
    }

    private void ShootThem()
    {
        if (Time.time >= nextShotTimer)
        {
            Vector3 direction = (EnemyTarget.position - shootPosition.position).normalized;
            shootPosition.forward = direction;
            //creates the projectile that is going to shoot at the enemies 
            Instantiate(Canonprojectile, shootPosition.position, Quaternion.LookRotation(direction));
            nextShotTimer = Time.time + 4f;
        }
    }

    private void DetectingEnemy()
    {
        Collider[] shotColliders = Physics.OverlapSphere(transform.position, enemyDetectionRadius);
        foreach (var shotCollider in shotColliders)
        {
            if (shotCollider.CompareTag("Humans"))
            {
                EnemyTarget = shotCollider.transform;
                return;
            }
        }
        EnemyTarget = null;
    }
}
