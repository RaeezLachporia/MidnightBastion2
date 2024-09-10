using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingScript : MonoBehaviour
{
    public float towerDetectionRadius = 10f;
    public float fireRate = 1f;
    public GameObject Arrow;
    public Transform EnemyBow;
    public Transform EnemyTower;
    public float nextShotTimer;

    // Update is called once per frame
    void Update()
    {
        DetectingTower();

        if(EnemyTower != null)
        {
            ShootTower();
        }
    }

    private void ShootTower()
    {
        Vector3 direction = (EnemyTower.position - EnemyBow.position).normalized;
        EnemyBow.forward = direction;

        Instantiate(Arrow, EnemyBow.position, Quaternion.LookRotation(direction));
        nextShotTimer = Time.time + 1f / nextShotTimer;
    }

    private void DetectingTower()
    {
        Collider[] shootColliders = Physics.OverlapSphere(transform.position, towerDetectionRadius);
        foreach (var shootCollider in shootColliders)
        {
            if (shootCollider.CompareTag("Tower"))
            {
                EnemyTower = shootCollider.transform;
                return;
            }
        }
        EnemyTower = null;
    }
}
