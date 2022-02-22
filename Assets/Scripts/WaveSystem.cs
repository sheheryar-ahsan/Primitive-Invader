using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSystem : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float enemiesXOffset;
    public float enemiesYOffset;
    private int totalWaves = 5;
    private int currentWave = 0;
    private float waveSpawnPosition = 0;

    public TextMeshProUGUI timeText;
    private float spawnedTime;
    private bool startTimer;

    private Vector2 endPosition = new Vector2(-4.3f, 0);
    private Vector2 startPosition;
    private float desiredDuration = 3f;
    private float elapsedTime;
    [SerializeField]
    private AnimationCurve curve;

    private int[,] patterenArray = new int[5,3];

    void Start()
    {
        spawnedTime = 0;
        startTimer = false;
    }
    void Update()
    {
        if (true)
        {
            SpawningTheWave();
        }
        CalculatingSPawnTime();
    }
    private void WavePosition()
    {
        float uBound0 = patterenArray.GetUpperBound(0) + 1f;
        waveSpawnPosition += (-uBound0 - enemiesXOffset);
        transform.position = new Vector2(waveSpawnPosition, 0);
    }
    private void SpawningTheWave()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == false && currentWave < totalWaves)
        {
            //StartCoroutine(GeneratingPatteren());
            GeneratingPatteren();
            currentWave++;
            startTimer = true;
        }
    }
    private void GeneratingPatteren()
    {
        int uBound0 = patterenArray.GetUpperBound(0);
        int uBound1 = patterenArray.GetUpperBound(1);
        float xLastPos;
        float yLastPos;
        for (int i = 0; i <= uBound0; i++)
        {
            xLastPos = i * enemiesXOffset;
            for (int j = 0; j <= uBound1; j++)
            {
                int randomGenerator = Random.Range(0, 2);
                if (randomGenerator == 0)
                {
                    yLastPos = j * enemiesYOffset;
                    Vector2 enemyPos = new Vector2(i + xLastPos, j + yLastPos);
                    Instantiate(enemyPrefab, enemyPos, enemyPrefab.transform.rotation, transform);
                }
            }
        }
        WavePosition();
    }
    private void MovingWaveHorizontally() // 
    {
        elapsedTime += Time.deltaTime;
        float percentageCompleted = elapsedTime / desiredDuration;

        transform.position = Vector2.Lerp(startPosition, endPosition, percentageCompleted);
    }
    private void CalculatingSPawnTime()
    {
        if (startTimer == true)
        {
            spawnedTime += Time.deltaTime;
        }
        timeText.text = "Time: " + spawnedTime.ToString("F2");
    }
}
