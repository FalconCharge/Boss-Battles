using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnPoints;
    [SerializeField] private List<GameObject> enemies;
    private float spawnTime;
    [SerializeField] private float timeBTWSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int rand1;
        int rand2;

        int rands = Random.Range(0, 10);

        if(rands <= 1)
        {
            do{
                rand1 = Random.Range(0, spawnPoints.Count);
                rand2 = Random.Range(0, spawnPoints.Count);
            } while (rand1 == rand2);
            if(Time.time >= spawnTime + timeBTWSpawn)
            {
                Instantiate(enemies[0], spawnPoints[rand1].transform.position, Quaternion.identity);
                Instantiate(enemies[0], spawnPoints[rand2].transform.position, Quaternion.identity);
                spawnTime = Time.time;
            }
        }
        else
        {
            int rand = Random.Range(0, spawnPoints.Count);
            if (Time.time >= spawnTime + timeBTWSpawn)
            {
                Instantiate(enemies[0], spawnPoints[rand].transform.position, Quaternion.identity);
                spawnTime = Time.time;
            }
        }
        
        
    }
}
