using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform redEnemyPrefab;
    public Transform blueEnemyPrefab;
    public Transform magentaEnemyPrefab;
    public Transform spawnPoint;
    public Transform target;

    public Text waveText;
    public Text countdownTimer;

    public float timeBetweenWaves = 3f;

    private float countdown = 5.0f;
    private int waveIndex = 0;
    private void Update()
    {
        waveText.text = "Wave " + waveIndex;
        countdownTimer.text = countdown.ToString("0.0");
        if(Input.GetKeyUp(KeyCode.R))
        {
            StartCoroutine(SpawnRedWave());
            countdown = timeBetweenWaves;
        } 
        
        if (Input.GetKeyUp(KeyCode.B))
        {
            StartCoroutine(SpawnBlueWave());
        } 
        
        if (Input.GetKeyUp(KeyCode.M))
        {
            StartCoroutine(SpawnMagentaWave());
        }

        countdown -= Time.deltaTime;

        if(countdown <= 0)
        {
            countdown = timeBetweenWaves;
            waveIndex++;

            SpawnBlueEnemy();
            SpawnRedEnemy();
            SpawnMagentaEnemy();
        }
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
