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

    private List<float> timeBetweenWaves = new List<float>(){15f, 10f, 10f, 15f, 30f, 35, 30f, 35f, 30f, 40f};

    [SerializeField] private Image VictoryImage = null;
    [SerializeField] private Text startText = null;
    [SerializeField] private Text pauseText = null;
    [SerializeField] private GameObject player1 = null;
    [SerializeField] private GameObject player2 = null;

    private float countdown;
    private int waveIndex;
    private bool hasStarted;
    private void Start()
    {
        print(timeBetweenWaves[0]);
        countdown = timeBetweenWaves[0];
        waveIndex = 0;
        VictoryImage.enabled = false;
        hasStarted = false;
        startText.enabled = true;
        pauseText.enabled = false;
    }
    private void Update()
    {
        waveText.text = "Wave " + waveIndex + "/8";
        countdownTimer.text = countdown.ToString("0.0");
        if(Input.GetKeyUp(KeyCode.P))
        {
            hasStarted = true;
            startText.enabled = false;
        } 
        
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            
            TogglePause();
        } 
        
        if (Input.GetKeyUp(KeyCode.M))
        {
           // StartCoroutine(SpawnMagentaWave());
        }
        if(hasStarted)
         countdown -= Time.deltaTime;

        if(countdown <= 0)
        {
            waveIndex++;
            SpawnWave();
            countdown = timeBetweenWaves[waveIndex];

        }
        if(waveIndex == 9)
        {
            StartCoroutine(VictoryScreen());
        }

    if(waveIndex == 8)
        {
            GameObject temp1 = GameObject.Find("TempEnemyBlue(Clone)");
            GameObject temp2 = GameObject.Find("TempEnemyRed(Clone)");
            GameObject temp3 = GameObject.Find("TempEnemyMAgenta(Clone)");
            if(temp1 == null && temp2 == null && temp3 == null)
                StartCoroutine(VictoryScreen());
        }
    }

   void TogglePause()
    {
        if(!player1.GetComponent<Player>().onTower && !player2.GetComponent<Player>().onTower)
            {
            if (Time.timeScale != 0f)
            {
                Time.timeScale = 0f;
                pauseText.enabled = true;
            }
            else
            {
                Time.timeScale = 1f;
                pauseText.enabled = false;
            }
        }
    }
    IEnumerator VictoryScreen()
    {
        VictoryImage.enabled = true;
        waveText.enabled = false;
        countdown = 10f;
        yield return new WaitForSeconds(10f);
        Cursor.lockState = CursorLockMode.None;
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
        int maxIndex = waveIndex;
        if (maxIndex > 7)
        {
            maxIndex = 4;
        }
        for (int i = 0; i < maxIndex; i++)
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
        int maxIndex = waveIndex;
        if (maxIndex > 7)
        {
            maxIndex = 4;
        }
        for (int i = 0; i < maxIndex; i++)
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
        int maxIndex = waveIndex;
        if(maxIndex > 3)
        {
            maxIndex = 4;
        }
        for (int i = 0; i < maxIndex; i++)
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
