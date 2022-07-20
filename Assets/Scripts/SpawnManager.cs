using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    private MainManager mainManager;
    public GameObject[] enemyPrefabs;
    public TextMeshProUGUI scoreText;

    private int score;
    private float spawnRangeX = 21;
    private float spawnPosZ = 1;
    private float spawnDelay = 2;
    private float spawnIntervalEnemy = 2f;
   

    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnIntervalEnemy);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        if (mainManager.gameOver == false)
        {
            //Randomly generate enemy index and spawn position.
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
            

    }

    
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
