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

   private IEnumerator spawnEnemy(float interval, GameObject enemy)// spawns enemies at random points on the generated terrain 
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(10f, 230f), Random.Range(20f,22f), 0), Quaternion.identity);//spawns enemies above the y20 coordinate
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
