using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Player Health
    [SerializeField] float health = 50f;
    //Player Speed
    [SerializeField] float moveSpeed = 10f;
    //Player Padding
    [SerializeField] float padding = 1f;

    //Audio for Player
    [SerializeField] AudioClip playerHitSound;
    [SerializeField] [Range(0, 1)] float playerHitSoundVolume = 0.7f;

    //Camera's Minimum and Maximum Values
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

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //Gets the damage dealer class from the object
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        //If there is no dmgDealer in obstacle/bullet end method 
        if(!dmgDealer)
        {
            return;
        }

        RegisterHit(dmgDealer);
    }

    private void RegisterHit(DamageDealer dmgDealer)
    {
        //Reduce Health by Damage Given
        health -= dmgDealer.GetDamage();

        AudioSource.PlayClipAtPoint(playerHitSound, Camera.main.transform.position, playerHitSoundVolume);

        //If Player Health is equal of lower than 0, Player dies
        if (health <= 0)
        {
            Destroy(gameObject);
        }
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
        //Player Movement From Left To Right
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        var newXPos = transform.position.x + deltaX;

        newXPos = Mathf.Clamp(newXPos, xCamMin, xCamMax);

        this.transform.position = new Vector2(newXPos, transform.position.y);
    }
}
