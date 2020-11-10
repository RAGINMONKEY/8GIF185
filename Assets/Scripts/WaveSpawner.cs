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
        Instantiate(redEnemyPrefab,spawnPoint.position, spawnPoint.rotation);
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
        Instantiate(blueEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
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
        Instantiate(magentaEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
