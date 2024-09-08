using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

   [SerializeField] private GameObject EnemyType1;

   [SerializeField] private float SpawnInterval = 3.5f;

    void Start()
    {
        StartCoroutine(spawnEnemy(SpawnInterval, EnemyType1));
    }

   private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
