using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    //Obstacle Health
    [SerializeField] float health = 100f;

    //Obstacle Explosion Sound
    [SerializeField] AudioClip obstacleExplosionSound;
    [SerializeField] [Range(0, 1)] float obstacleExplosionSoundVolume = 0.7f;

    //VFX for explosion of player
    [SerializeField] GameObject DeathVFX;
    [SerializeField] float explosionDuration = 1f;

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
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);

        //Explosion VFX & Sound
        GameObject explosion = Instantiate(DeathVFX, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(obstacleExplosionSound, Camera.main.transform.position, obstacleExplosionSoundVolume);

        //Destroy explosion after 1 second
        Destroy(explosion, explosionDuration);
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
