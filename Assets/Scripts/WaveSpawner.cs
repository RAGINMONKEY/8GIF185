using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public Transform redEnemyPrefab;
    public Transform blueEnemyPrefab;
    public Transform magentaEnemyPrefab;
    public Transform spawnPoint;
    public Transform target;

    public Text waveText;
    public Text countdownTimer;

    public float timeBetweenWaves = 15f;

    [SerializeField] private Image VictoryImage = null;

    private float countdown;
    private int waveIndex;
    private void Start()
    {
        countdown = timeBetweenWaves;
        waveIndex = 0;
        VictoryImage.enabled = false;
    }
    private void Update()
    {
        waveText.text = "Wave " + waveIndex + "/8";
        countdownTimer.text = countdown.ToString("0.0");
        if(Input.GetKeyUp(KeyCode.R))
        {
           // StartCoroutine(SpawnRedWave());
           // countdown = timeBetweenWaves;
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
            waveIndex++;
            SpawnWave();
            countdown = timeBetweenWaves;

        }
        if(waveIndex == 9)
        {
            StartCoroutine(VictoryScreen());
        }
    }

    IEnumerator VictoryScreen()
    {
        VictoryImage.enabled = true;
        waveText.enabled = false;
        countdown = 10f;
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("MenuScene");
    }
    void SpawnWave()
    {
        switch(waveIndex)
        {
            case 0:
                break;
            case 1:
                StartCoroutine(SpawnRedWave());
                StartCoroutine(SpawnBlueWave());
                break;
            case 2:
                StartCoroutine(SpawnRedWave());
                StartCoroutine(SpawnBlueWave());
                break;
            case 3:
                StartCoroutine(SpawnRedWave());
                StartCoroutine(SpawnBlueWave());
                break;
            case 4:
                StartCoroutine(SpawnRedWave());
                StartCoroutine(SpawnBlueWave());
                break;
            case 5:
                StartCoroutine(SpawnRedWave());
                StartCoroutine(SpawnBlueWave());
                SpawnMagentaEnemy();
                break;
            case 6:
                SpawnMagentaEnemy();
                SpawnMagentaEnemy();
                SpawnMagentaEnemy();
                break;
            case 7:
                StartCoroutine(SpawnRedWave());
                StartCoroutine(SpawnBlueWave());
                break;
            case 8:
                StartCoroutine(SpawnRedWave());
                StartCoroutine(SpawnBlueWave());
                StartCoroutine(SpawnMagentaWave());
                break;

        }
    }
    private IEnumerator SpawnRedWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            //Debug.Log("Spawn Red");
            SpawnRedEnemy();
            yield return new WaitForSeconds(0.5f);
        }
   
    }

    void SpawnRedEnemy()
    {
        Transform enemy = Instantiate(redEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemy.GetComponentInChildren<SimpleAgent>().setTarget(target);
    }

    IEnumerator SpawnBlueWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
           // Debug.Log("Spawn Blue");
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
