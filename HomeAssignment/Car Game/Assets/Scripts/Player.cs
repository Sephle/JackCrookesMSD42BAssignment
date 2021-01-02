using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Player Speed
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;

    float xCamMin, xCamMax, yCamMin, yCamMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void SetUpMoveBoundaries()
    {
        //Setting Up boundaries
        Camera gameCamera = Camera.main;

        xCamMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xCamMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yCamMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yCamMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void Move()
    {
        //Update deltaX with movement left and right
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        var newXPos = transform.position.x + deltaX;

        newXPos = Mathf.Clamp(newXPos, xCamMin, xCamMax);

        this.transform.position = new Vector2(newXPos, transform.position.y);
    }
}
