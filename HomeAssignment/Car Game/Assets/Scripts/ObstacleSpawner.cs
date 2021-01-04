using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    //a list of WaveConfigs
    [SerializeField] List<WaveConfig> waveConfigList;

    [SerializeField] bool looping = false;

    //we always start from Wave 0
    int startingWave = 0;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        //loop all waves if true
        do
        {
            //start coroutine that spawns all waves
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping); //while (looping == true)
    }

    void Update()
    {

    }

    private IEnumerator SpawnAllObstaclesInWave(WaveConfig waveToSpawn)
    {
        //loop to spawn all obstacles in wave
        for (int enemyCount = 1; enemyCount <= waveToSpawn.GetNumberOfObstacles(); enemyCount++)
        {
            var newObstacle = Instantiate(
                            waveToSpawn.GetObstaclePrefab(),
                            waveToSpawn.GetWaypoints()[0].transform.position,
                            Quaternion.identity);

            newObstacle.GetComponent<ObstaclePathing>().SetWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }

    }

    private IEnumerator SpawnAllWaves()
    {
        foreach (WaveConfig currentWave in waveConfigList)
        {
            yield return StartCoroutine(SpawnAllObstaclesInWave(currentWave));
        }
    }
}
