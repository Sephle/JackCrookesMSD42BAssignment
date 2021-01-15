using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    //Calling scoreText & gameSession
    Text scoreText;
    GameSession gameSession;


    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        //Constantly Updates score
        scoreText.text = gameSession.GetScore().ToString();
    }
}
