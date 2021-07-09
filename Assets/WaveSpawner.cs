using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 10f;

    public Text WaveCountdownText;

    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        WaveCountdownText.text = Mathf.Round(countdown).ToString();

    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
