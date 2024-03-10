using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private List<Level> gameLevels = new List<Level>();
    public GameObject streetTwo, streetThree;
    [SerializeField]
    private Text noOfEnemiesText,noOfAmmosText;
    [SerializeField]
    private PoliceCarSpawner policeCarSpawner;


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
        numberOfEnemies = policeCarSpawner.GetEnemyCars();
        noOfAmmosText.text = "Ammos: "+numberOfBullets.ToString();
        noOfEnemiesText.text = "Enemies: " + numberOfEnemies.ToString();

    }


    public void DecreaseEnemies()
    {
        if (numberOfEnemies > 0)
        {
            numberOfEnemies--;

            numberOfEnemies = policeCarSpawner.GetEnemyCars();
        }
        else
        {
            //LevelComplete
        }
    }

    public void DecreaseAmmos()
    {
        if (numberOfBullets > 0)
        {
            numberOfBullets--;
        }
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


  [System.Serializable]
  public class Level
    {
        public string levelName;
        public int numberOfCars;


    }
}
