using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float inputSpawnTimer;
    float spawnTimer;

    public GameObject monster;
    public GameObject boss;
    public int spawnLimit;
    public int currentMonsterLimit;

    int currentSpawnedMonster = 0;

    GameObject[] allEnemies;

    const int GameStart = 1;
    const int Win = 2;
    const int Lose = 3;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = inputSpawnTimer;
    }

    void FixedUpdate()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Musuh");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("cameraHolder").GetComponent<GameManager>().GetState() == GameStart && GameObject.Find("cameraHolder").GetComponent<GameManager>().GetGameOver() == false)
        {
            if (allEnemies.Length < currentMonsterLimit)
            {
                if (currentSpawnedMonster != spawnLimit)
                {
                    SpawnMonster();
                }
            }
            if(allEnemies.Length == 0)
            {
                SpawnBoss();
            }
        }                   
    }

    void SpawnMonster()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer < 0)
        {
            GameObject spawnedMonster;
            spawnedMonster = Instantiate(monster, this.transform.position, this.transform.rotation);

            //Do Something to the clone
            spawnedMonster.GetComponent<MonsterKayu>().player = GameObject.Find("charController").transform;
            spawnedMonster.GetComponent<MonsterAttack>().player = GameObject.Find("charController");

            currentSpawnedMonster++;

            spawnTimer = Random.Range(0, inputSpawnTimer);
        }             
    }

    public int GetCurrentEnemies()
    {
        return allEnemies.Length;
    }

    void SpawnBoss()
    {
        boss.SetActive(true);
    }
}
