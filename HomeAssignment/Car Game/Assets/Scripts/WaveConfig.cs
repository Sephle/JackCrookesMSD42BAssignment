using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle Wave Config")]
public class WaveConfig : ScriptableObject
{
    //obstacle
    [SerializeField] GameObject obstaclePrefab;

    //path
    [SerializeField] GameObject pathPrefab;

    //time between spawns
    [SerializeField] float timeBetweenSpawns = 0.5f;

    //random difference time between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    //number of obstacles
    [SerializeField] int numberOfObstacles = 5;

    //obstacle speed
    [SerializeField] float obstacleMoveSpeed = 2f;

    public GameObject GetObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWayPoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;

    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfObstacles()
    {
        return numberOfObstacles;
    }

    public float GetObstacleMoveSpeed()
    {
        return obstacleMoveSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
