using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject[] enemyPrefabs;
    private int maxEnemies;
    private bool waveSpawned = false;
    private new BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        maxEnemies = Random.Range(8, 15);
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == maxEnemies - 1)
        {
            waveSpawned = true;
        }

        if (collider.isTrigger && collider.bounds.Contains(GameObject.FindGameObjectWithTag("Player").transform.position) && !waveSpawned)
        {
            print("Player is in the room");
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        float randomX = Random.Range(collider.bounds.min.x + 1, collider.bounds.max.x - 1);
        float randomY = Random.Range(collider.bounds.min.y + 1, collider.bounds.max.y - 1);
        Vector3 randomPosition = new Vector3(randomX, randomY, transform.position.z);
        GameObject enemy = Instantiate(enemyPrefabs[randomIndex], randomPosition, Quaternion.identity);
        enemy.transform.SetParent(transform);
    }
}
