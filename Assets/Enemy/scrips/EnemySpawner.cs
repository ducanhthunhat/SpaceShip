using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool isLooping;
    WaveConfig currentWave;
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemy()
    {
        do
        {
            foreach (WaveConfig wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(0), currentWave.GetStartingWayPoint().position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(currentWave.GetSpawnerTime());
                }
            }
        }
        while (isLooping);
    }
}
