using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject streetTwo, streetThree;
    [SerializeField]
    private Text noOfEnemiesText,noOfAmmosText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }


    private int numberOfEnemies;
    private int numberOfBullets;
    // Start is called before the first frame update
    void Start()
    {
        noOfAmmosText.text = "Ammos: "+numberOfBullets.ToString();
        noOfEnemiesText.text = "Enemies: " + numberOfEnemies.ToString();

    }


    public void DecreaseEnemies()
    {
        if (numberOfEnemies > 0)
        {
            numberOfEnemies--;
        }
        else
        {
            //GameOver
        }
    }

    public void DecreaseAmmos()
    {
        if (numberOfBullets > 0)
        {
            numberOfBullets--;
        }
    }

  


}
