using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform redEnemyPrefab;
    public Transform blueEnemyPrefab;
    public Transform magentaEnemyPrefab;
    public Transform spawnPoint;
    public Transform target;

    public float timeBetweenWaves = 5f;
    // private float countdown = 1f;
    private int waveIndex = 1;
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.R))
        {
            StartCoroutine(SpawnRedWave());
            //countdown = timeBetweenWaves;
        } 
        
        if (Input.GetKeyUp(KeyCode.B))
        {
            StartCoroutine(SpawnBlueWave());
        } 
        
        if (Input.GetKeyUp(KeyCode.M))
        {
            StartCoroutine(SpawnMagentaWave());
        }

        //countdown -= Time.deltaTime;
    }

    IEnumerator SpawnRedWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnRedEnemy();
            yield return new WaitForSeconds(0.5f);
        }
   
    }

    void SpawnRedEnemy()
    {
        Transform enemy = Instantiate(redEnemyPrefab,spawnPoint.position, spawnPoint.rotation);
        enemy.GetComponentInChildren<SimpleAgent>().setTarget(target);
    }

    IEnumerator SpawnBlueWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnBlueEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnBlueEnemy()
    {
        Transform enemy = Instantiate(blueEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemy.GetComponentInChildren<SimpleAgent>().setTarget(target);
    }

    IEnumerator SpawnMagentaWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnMagentaEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnMagentaEnemy()
    {
        Transform enemy = Instantiate(magentaEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemy.GetComponentInChildren<SimpleAgent>().setTarget(target);
    }
}
