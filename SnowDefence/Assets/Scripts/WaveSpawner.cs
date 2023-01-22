using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    private bool isPaused;
    
    public static int EnemiesAlive;
    
    public WaveArray[] waves;
    public Transform spawnPoint;

    
    public float initialCountdown;
    public float countdown;

    public TextMeshProUGUI timer;
    
    public static int waveNumber;

    [Header("UI-WON")] public GameObject uiVictory;
    [Header("PauseScreen")] public GameObject pauseScreen;

    private void Start()
    {
        countdown = initialCountdown;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                isPaused = true;
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
        
        if (EnemiesAlive > 0)
        {
            return;
        }
        
        if (waveNumber == waves.Length)
        {
            resetWaveSpawner();
            uiVictory.SetActive(true);
            print("GAME WON");
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = initialCountdown;
        }
        
        countdown -= Time.deltaTime;
        double ct = Math.Round(Math.Floor(countdown)) + 1;
        
        if (timer != null){
            timer.text = ct.ToString();
        }
    }

    IEnumerator SpawnWave()
    {
        WaveArray wave = waves[waveNumber];
        
        // Wavearray[] = [[enemy1, enemy2], [count1, count2], rate]
        
        for (int j = 0; j < wave.enemy.Length; j++)
        {
            for (int i = 0; i < wave.count[j]; i++)
            {
                SpawnEnemy(wave.enemy[j]);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }

        sumWaveNumber();
        
    }

    public void sumWaveNumber()
    {
        waveNumber++;
        GameEvent.current.WaveChanged();
    }

    void SpawnEnemy(GameObject enemy)
    {
        Vector3 plus = new Vector3(0, 90, 0);
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }

    public static void resetWaveSpawner()
    {
        EnemiesAlive = 0;
        waveNumber = 0;
    }
}