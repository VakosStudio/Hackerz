using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;
    }

    public WaveSpawner spawner;
    public GameObject start;
    public GameObject complete;
    public Text nameWave;
    public Wave[] waves;
    public Transform[] spawnPoints;
    public int nextWave = 0;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    private SpawnState state = SpawnState.COUNTING;
    public float searchCountdown = 1f;

    public void Start()
    {
        nameWave = GameObject.FindGameObjectWithTag("StartWave").GetComponentInChildren<Text>();
        waveCountdown = timeBetweenWaves;
    }

    public void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if(EnemyIsAlive() == false)
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
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown = waveCountdown - Time.deltaTime;
        }
    }

    public void WaveCompleted()
    {

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            Debug.Log("ALL WAVES COMPLETED!");
            spawner.enabled = false;
        }
        else
        {
            StartCoroutine(CompleteWave());
            nextWave++;
        }
    }

    IEnumerator CompleteWave()
    {
        Debug.Log("Complete Wave!");
        complete.SetActive(true);
        yield return new WaitForSeconds(3f);
        complete.SetActive(false);
    }

    bool EnemyIsAlive ()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if(GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Start " + _wave.name);
        nameWave.text = "Start " + _wave.name;
        start.SetActive(true);
        state = SpawnState.SPAWNING;

        yield return new WaitForSeconds(2f);

        start.SetActive(false);

        for(int i=0; i<_wave.count; i++)
        {
            SpawnEnemy(_wave.enemy[Random.Range(0, _wave.enemy.Length)]);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;
    }

    public void SpawnEnemy(Transform _enemy)
    {
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, sp.position, sp.rotation);
    }
}
