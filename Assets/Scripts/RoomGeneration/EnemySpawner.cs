using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject[] enemyPrefabs;
    private int maxEnemies;

    // Start is called before the first frame update
    void Start()
    {
        maxEnemies = Random.Range(8, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Collider2D>().isTrigger && GetComponent<Collider2D>().bounds.Contains(GameObject.FindGameObjectWithTag("Player").transform.position) && transform.childCount < maxEnemies)
        {
            print("Player is in the room");
            SpawnEnemy();
        }
    }

    void SpawnEnemy() {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        float randomX = Random.Range(transform.position.x - 1.5f, transform.position.x + 1.5f);
        float randomY = Random.Range(transform.position.y - 1.5f, transform.position.y + 1.5f);
        Vector3 randomPosition = new Vector3(randomX, randomY, transform.position.z);
        GameObject enemy = Instantiate(enemyPrefabs[randomIndex], randomPosition, Quaternion.identity);
        enemy.transform.SetParent(transform);
    }
}
