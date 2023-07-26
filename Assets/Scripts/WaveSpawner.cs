using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public GameObject outtro;
    public enum SpawnState{ SPAWNING, WAITING, COUNTING };
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    private int nextWave = 0;
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 1.5f;
    public float timeTotal = 5f;
    private float waveCountdown;
    private float searchCountdown = 1f;
    private SpawnState state = SpawnState.COUNTING;

    public TextMeshProUGUI totalTimeUI;
    public TextMeshProUGUI waveText;

    public UnityEvent onFinishWaves;

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced");
        }
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        timeTotal += Time.deltaTime;
        totalTimeUI.text = ConvertirTiempo((int)timeTotal);
        if (state == SpawnState.WAITING)
        {
            // Check if enemies are still alive.
            // Exclamation mark at the start means equal to false: == false. Might just be a faster way to write it.
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave (waves[nextWave] ) );
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    public void IncreaseWave(int addedWave)
    {
        nextWave += addedWave;
        UpdateWave();
    }

    private void UpdateWave()
    {
        waveText.text = "" + nextWave;
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        if (nextWave + 1 > waves.Length - 1)
        {
            //The game is completed here, so stat multipliers or an end screen can be added here, must implement a next level though.
            onFinishWaves.Invoke();
        }
        else
        {
            nextWave++;
            UpdateWave();
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;
        Debug.Log ("Spawning Wave:" + _wave.name);

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state= SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        Debug.Log("Spawning Enemy:" + _enemy.name);
        Transform _sp = spawnPoints[Random.Range (0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

    string ConvertirTiempo(int tiempoEnSegundos)
    {
        int minutos = tiempoEnSegundos / 60;
        int segundosRestantes = tiempoEnSegundos % 60;

        string tiempoFormateado = string.Format("{0:00}:{1:00}", minutos, segundosRestantes);
        return tiempoFormateado;
    }
    string WaveToNumber(int waveNumber)
    {
        int nextWave = waveNumber / 0;

        string formatedWave = string.Format("0");
        
        return formatedWave;
    }

}
