using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Enemy spawner")]
    public List<GameObject> EnemyPrefabs;
    public float SpawnRangeX;
    public float SpawnDelay;
    public float SpawnInterval;

    [Header("UI components")]
    public Text ScoreText;
    public Text LivesText;
    public GameObject EndGamePanel;
    public Text EndGameScoreText;
    public GameObject PausePanel;
    public Text PausePanelScoreText;
    public GameObject StartMenuPanel;
    public GameObject BackgroundPanel;
    public GameObject DifficultyPanel;
    public GameObject ControlsPanel;



    [SerializeField]
    private int score = 0;
    [SerializeField]
    private int playerLives = 5;

    void Start()
    {
        ScoreText.text = score.ToString();
        LivesText.text = playerLives.ToString();
        BackgroundPanel.SetActive(false);
        EndGamePanel.SetActive(false);
        PausePanel.SetActive(false);
        StartMenuPanel.SetActive(true);
        ControlsPanel.SetActive(false);
        DifficultyPanel.SetActive(false);
        Time.timeScale = 0;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SpawnEnemy();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanelScoreText.text = "Your score is " + score;
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }



    public void ReallyEasy()
    {
        SpawnRangeX = 10;
        SpawnInterval = 2;
        InvokeRepeating("SpawnEnemy", SpawnDelay, SpawnInterval);
    }

    public void Easy()
    {
        SpawnRangeX = 10;
        SpawnInterval = 1;
        InvokeRepeating("SpawnEnemy", SpawnDelay, SpawnInterval);
    }

    public void Normal()
    {
        SpawnRangeX = 10;
        SpawnInterval = 0.5f;
        InvokeRepeating("SpawnEnemy", SpawnDelay, SpawnInterval);
    }

    public void Hard()
    {
        SpawnRangeX = 15;
        SpawnInterval = 0.25f;
        InvokeRepeating("SpawnEnemy", SpawnDelay, SpawnInterval);
    }

    public void ReallyHard()
    {
        SpawnRangeX = 15;
        SpawnInterval = 0.1f;
        InvokeRepeating("SpawnEnemy", SpawnDelay, SpawnInterval);
    }

    public void AddScore()
    {
        score++;
        ScoreText.text = score.ToString();
    }

    public void ManagePlayerLives(int amount)
    {
        playerLives += amount;
        LivesText.text = playerLives.ToString();

        if(playerLives <= 0)
        {
            Debug.Log("GAME OVER");
            EndGameScoreText.text = "Your final score is " + score;

            EndGamePanel.SetActive(true);

            Time.timeScale = 0;
        }
    }

    private void SpawnEnemy()
    {
        //1. dohvatiti random index od enemy liste
        int randomIndex = Random.Range(0, EnemyPrefabs.Count);
        //2. definirati random poziciju spawnanja
        float randomX = Random.Range(-SpawnRangeX, SpawnRangeX);
        Vector3 randomPosition = new Vector3(randomX, 0, transform.position.z);
        //3. stvoriti radnom objekt na random poziciji
        GameObject enemyClone =  Instantiate(EnemyPrefabs[randomIndex], randomPosition,
            EnemyPrefabs[randomIndex].transform.rotation);
        EnemyController enemyControl = enemyClone.GetComponent<EnemyController>();
        if(!enemyControl)//isto kao enemyControl == false
        {
            Debug.LogError("Missing component: Enemy controller");
            return;
        }

        //spremamo referencu na ovu skriptu u enemy-a
        enemyControl.GameManager = this;
    }
}
