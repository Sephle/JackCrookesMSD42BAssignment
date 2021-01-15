using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShredder : MonoBehaviour
{
    [SerializeField] int scoreValue = 5;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        Destroy(otherObject.gameObject);

        //Adds up to Score
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
    }
}
