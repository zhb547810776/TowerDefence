using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static int EnemyAliveCount = 0;
    public Wave[] waves;
    public Transform START;
    public float waveRate = 2;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        foreach(Wave wave in waves)
        {
            for (int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.enemyPrefeb, START.position, Quaternion.identity);
                EnemyAliveCount++;
                if (i != wave.count - 1)
                {
                    yield return new WaitForSeconds(wave.rate);
                }
            }
            while (EnemyAliveCount > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waveRate);
        }
    }
}
