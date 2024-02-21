using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private int numberEnemies, spawnPointRange, timer;
    private List<GameObject> enemies;
    private Vector3 spawnPoint;
    private float currentTimer;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        currentTimer = 0;
        if(timer == 0)
        {
            timer = 20;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTimer > 0)
        {
            currentTimer -= Time.deltaTime; 
        }
        if (transform.childCount < numberEnemies && currentTimer <= 0)
        {
            setSpawnPoint();
            currentTimer += timer;
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
