using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private int numberEnemies, spawnPointRange;
    private List<GameObject> enemies;
    private Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < numberEnemies)
        {
            setSpawnPoint();
            enemies.Add(Instantiate(enemy, spawnPoint, this.transform.rotation, this.transform));
        }
    }

    private void setSpawnPoint()
    {
        float randomZ = Random.Range(-spawnPointRange, spawnPointRange);
        float randomX = Random.Range(-spawnPointRange, spawnPointRange);
        spawnPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    }
}
