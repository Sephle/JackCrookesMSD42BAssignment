using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;
    int health = 0;

    void Awake()
    {
        SetUpSingleton();
    }

    //Deletes one of the other GameSession if there is one
    private void SetUpSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHealth()
    {
        return health;
    }

    public void AddToScore(int scoreValue)
    {

        score += scoreValue;
        print(score);
    }

    public void AddToHealth(int healthValue)
    {
        health = healthValue;
        print(health);
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
