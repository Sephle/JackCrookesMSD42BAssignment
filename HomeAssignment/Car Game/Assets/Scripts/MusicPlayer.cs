using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            //Destroys Second MusicPlayer
            Destroy(gameObject);
        }
        else
        {
            //Do not delete musicplayer on switch of scenes
            DontDestroyOnLoad(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
