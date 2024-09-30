using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectiles : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;
    public float lifetime = 10f;
    void Start()
    {
        //destroys the projectiles after they have been moving for a certain time
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // checks if the projectiles that are fired from the enemies are colliding with any object that is tagged with tower 
        if (collision.gameObject.CompareTag("Tower"))
        {
            var tower = collision.gameObject.GetComponent<TowerHpScript>();
            if (tower != null)
            {
                tower.towerTakingDamage(damage);
            }

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
