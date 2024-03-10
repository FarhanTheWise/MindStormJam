using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceOfficer : MonoBehaviour
{
    
    private Transform playerTarget;
    private float moveSpeed;
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private GameObject bullet;
    private float timeToShoot;
    public float delayTime =2f;
    public Transform bar;
    private float health = 1.5f; // Health value (between 0 and 1)
    [SerializeField]
    private GameObject smokeParticle;
    [SerializeField]
    private GameObject destroyParticle;
    [SerializeField]
    public GameObject[] tires;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip destroyClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthBar();
        moveSpeed = Random.Range(30f,40f);
   playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        timeToShoot = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeToShoot -= Time.deltaTime;
       transform.GetChild(0).LookAt(playerTarget.position);
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        if (timeToShoot <= 0f)
        {
            Instantiate(smokeParticle, spawnPoint.transform.position, spawnPoint.transform.rotation);
            GameObject newBullet = Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
            Vector3 bulletDirection = playerTarget.position - spawnPoint.transform.position;
            bulletDirection.Normalize();
            newBullet.GetComponent<Rigidbody>().AddForce(bulletDirection * 70f, ForceMode.Impulse);
            timeToShoot = delayTime;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            DecreaseHealth(0.1f);
        }
    }

    // Function to decrease health
    public void DecreaseHealth(float amount)
    {
        if (health > 0.1f)
        {
            health -= amount; // Decrease health by the given amount
            health = Mathf.Clamp01(health); // Ensure health stays between 0 and 1
            UpdateHealthBar(); // Update the health bar
        }
        else
        {
            audioSource.clip = destroyClip;
            audioSource.Play();
            Instantiate(destroyParticle, transform.position, transform.rotation);
          for(int i=0; i < Random.Range(1,tires.Length); i++)
            {
               for(int j=0; j < Random.Range(1, tires.Length); j++)
                {
                    Destroy(tires[i].gameObject);
                    Destroy(tires[j].gameObject);
                }
            }

            
            transform.GetChild(1).GetComponent<Rigidbody>().freezeRotation = false;
            Destroy(this.gameObject,1.2f);
        }
    }

    // Function to update the health bar
    void UpdateHealthBar()
    {
        // Calculate the new scale of the health bar cube
        float newScaleX = health;
        float newPosX = (1f - health) / 2f; // Adjust the position of the health bar from the right side
        // Set the scale and position of the health bar cube
        bar.localScale = new Vector3(newScaleX, bar.localScale.y, bar.localScale.z);
        bar.localPosition = new Vector3(newPosX, bar.localPosition.y, bar.localPosition.z);
    }


}
