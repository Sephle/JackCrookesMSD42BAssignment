using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShooters : MonoBehaviour
{
    //Obstacle Health
    [SerializeField] float health = 100f;
    //Obstacle Shot Counter
    [SerializeField] float shotCounter;
    //Obstacle Shooting Min Time
    [SerializeField] float minTimeBetweenShots = 0.2f;
    //Obstacle Shooting Max Time
    [SerializeField] float maxTimeBetweenShots = 3f;
    //Obstacle Bullet
    [SerializeField] GameObject obstacleBulletPrefab;
    //Obstacle Bullet Speed
    [SerializeField] float obstacleBulletSpeed = 0.3f;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //Gets the damage dealer class from the object
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        //If there is no dmgDealer in obstacle/bullet end method 
        if (!dmgDealer)
        {
            return;
        }

        RegisterHit(dmgDealer);
    }

    private void RegisterHit(DamageDealer dmgDealer)
    {
        //Reduce Health by Damage Given
        health -= dmgDealer.GetDamage();

        //If Player Health is equal of lower than 0, Player dies
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        //Every frame will decrease the timer for the obstacle to shoot
        shotCounter -= Time.deltaTime;

        //If timer reaches 0 then obstacle shoot.
        if (shotCounter <= 0f)
        {
            ObstacleFire();
            //This will reset shotCounter
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);

        }
    }

    private void ObstacleFire()
    {
        //This will allow the bullet to spawn from the position of the obstacle
        GameObject obstacleBullet = Instantiate(obstacleBulletPrefab, transform.position, Quaternion.identity) as GameObject;
        //This will make the bullet go downwards
        obstacleBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstacleBulletSpeed);
    }
}
