using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    //Calling scoreText & gameSession
    Text healthText;
    GameSession gameSession;


    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        //Constantly Updates score
        healthText.text = gameSession.GetHealth().ToString();
    }
}
