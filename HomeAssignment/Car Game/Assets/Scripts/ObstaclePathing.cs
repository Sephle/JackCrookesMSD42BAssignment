using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;

    [SerializeField] WaveConfig waveConfig;

    //saves the waypoint 
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //get the List waypoints from WaveConfig
        waypoints = waveConfig.GetWaypoints();

        //set the start position of Obstacle to the 1st waypoint position
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMove();
    }

    private void ObstacleMove()
    {
        //If Obstacle Hasn't Reached Destination Move to Destination
        //Else If Obstacle Reached Destination Move To Next Way Point
        //Else No Destination, Destroy Obstacle
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;

            targetPosition.z = 0f;

            var obstacleMovement = waveConfig.GetObstacleMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, obstacleMovement);

            //if obstacle reaches the target position
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }

        }

        //if obstacle reaches last waypoint
        else
        {

            Destroy(gameObject);
        }
    }

    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}
