using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject[] enemyPrefabs;
    private int maxEnemies;
    bool waveSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        maxEnemies = Random.Range(8, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == maxEnemies - 1)
        {
            waveSpawned = true;
        }

        if (GetComponent<Collider2D>().isTrigger && GetComponent<Collider2D>().bounds.Contains(GameObject.FindGameObjectWithTag("Player").transform.position) && !waveSpawned)
        {
            print("Player is in the room");
            SpawnEnemy();
        }
    }

    void SpawnEnemy() {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        Collider2D roomCollider = GetComponent<Collider2D>();
        float randomX = Random.Range(roomCollider.bounds.min.x, roomCollider.bounds.max.x);
        float randomY = Random.Range(roomCollider.bounds.min.y, roomCollider.bounds.max.y);
        Vector3 randomPosition = new Vector3(randomX, randomY, transform.position.z);
        GameObject enemy = Instantiate(enemyPrefabs[randomIndex], randomPosition, Quaternion.identity);
        enemy.transform.SetParent(transform);
    }
}
