using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject carToSpawn;
    [SerializeField]
    private int numberOfSpawnCars;
    [SerializeField]
    private float delayTime = 3f;
    private float timeToSpawn;
    public int minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = delayTime;

    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn <= 0f && numberOfSpawnCars>0)
        {    
            Instantiate(carToSpawn,new Vector3(Random.Range(minX,maxX),transform.position.y,transform.position.z),Quaternion.identity);
            timeToSpawn = delayTime;
            numberOfSpawnCars--;
        }
    }
}
