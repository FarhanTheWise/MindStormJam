using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCar : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime; 

        if(transform.position.z > 100)
        {
            GameManager.instance.streetTwo.SetActive(true);
        }

        if(transform.position.z > 200)
        {
            GameManager.instance.streetThree.SetActive(true);
        }
    }
}
