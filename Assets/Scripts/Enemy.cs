using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;

    public AudioClip launchSound;
    public AudioClip explosionSound;

    public GameObject projectilePrefabs;
    private float spawnDelay = 2;
    private float spawnIntervalFire = 4f;
    private SpawnManager spawnManager;
    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        playerAudio = GetComponent<AudioSource>();
        InvokeRepeating("SpawnEnemyFire", spawnDelay, spawnIntervalFire);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnemyFire()
    {
        //Randomly generate enemy fire.
        Instantiate(projectilePrefabs, transform.position, projectilePrefabs.transform.rotation);
        playerAudio.PlayOneShot(launchSound, 3.0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("PlayerFire"))
        {
            playerAudio.PlayOneShot(explosionSound, 2f);
            explosionParticle.Play();
            spawnManager.UpdateScore(pointValue);
            Destroy(collision.gameObject);
            Destroy(gameObject,0.3f);


        }


    }
    

}