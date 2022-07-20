using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    
    public AudioClip launchSound;
    public AudioClip explosionSound;

    private float speed = 10;
    public float horizontalInput;
    public float verticalInput;
    public GameObject projectilePrefab;
    
    public TextMeshProUGUI liveText;
    private int live;

    public float xBound = 22;
    public float topBound = 10;
    public float botBound = -5;
    // Start is called before the first frame update
    void Start()
    {
        live = 3;
        playerAudio = GetComponent<AudioSource>();
        liveText.text = "Live: " + live;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RestrainPlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch the projectile from the player.
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            playerAudio.PlayOneShot(launchSound, 3.0f);
        }
    }

    //Move the player with arrow keys
    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
       
        transform.Translate( Vector3.forward * speed * verticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

    }

    //Contain player movement
    void RestrainPlayer()
    {
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.z > topBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, topBound);
        }
        if (transform.position.z < botBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, botBound);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
          
            Destroy(other.gameObject);
            
        }
        if (other.gameObject.CompareTag("EnemyFire"))
        {
            live--;
            liveText.text = "Lives: " + live;
          
            Destroy(other.gameObject);

            playerAudio.PlayOneShot(explosionSound, 1.0f);
            explosionParticle.Play();
           if(live<=0)
            {
                
                Destroy(gameObject,0.5f);
                
            }
            
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")|| collision.gameObject.CompareTag("Meteorit"))
        {
            
            live--;
            liveText.text = "Lives: " + live;
            playerAudio.PlayOneShot(explosionSound, 1.0f);
            explosionParticle.Play();

            if (live <= 0)
            {
                
                Destroy(gameObject,0.5f);
                
            }
            Destroy(collision.gameObject);
        }
        
       
    }
    
}
