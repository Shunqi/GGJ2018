using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    /*public static GameMgr instance = null;

    private static UIManager uiController;
    private static bool isPause;
    private static int score;
    public static GameObject[] planets; 


    // Initialization
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        score = 0;
        isPause = true;
        
        GameObject UIManagerObject = GameObject.FindWithTag ("UIController");

        uiController = UIManagerObject.GetComponent<UIManager>();

        InitGame();
    }

    public static void InitGame()
    {
        // Initiate UI panel
        uiController.InitMenu();
        planets = new GameObject[2];
        planets[0] = SpawnPlanet(20, 0);

        float x = GenerateRandomX();
        float y = GenerateRandomY();
        planets[1] = SpawnPlanet(x, y);
    }

    public static void Pause()
    {
        // Change state to Pause
        isPause = true;
    }

    public static void Start()
    {
        // Change satate to Start
        isPause = false;
    }
    

    public static int GetScore()
    {
        return score;
    }

    // For GamePlay to disable space click
    public static bool IsPause()
    {
        return isPause;
    }

    
    Update score by addtion and push changes to UI side
    newScore: the score to add
    always be 1 for now, will add more bonus in the future
     
    public static void AddScore(int newScore)
    {
        score += newScore;
        uiController.UpdateScore(score);

        float x = GenerateRandomX();
        float y = GenerateRandomY();

        GameObject newPlanet = SpawnPlanet(x, y);
        uiController.ShiftCamera(planets[1].transform.position.y - planets[0].transform.position.x);

        DestoryPlanet(planets[0]);
        planets[0] = planets[1];
        planets[1] = newPlanet;

    }

    // Create new planet
    public static GameObject SpawnPlanet(float x, float y)
    {
        GameObject target = GenerateRandomPlanet();
        GameObject newPlanet = Instantiate(target, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
        return newPlanet;
    }

    // Randomly select a prefad
    public static GameObject GenerateRandomPlanet()
    {
        GameObject instance = Resources.Load("earth") as GameObject;
        return instance;
    }

    public static float GenerateRandomX()
    {
        var cam = Camera.main;
        var bottomleft = cam.ViewportToWorldPoint(Vector3.zero);
        var topright = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        float minX = bottomleft.x;
        float minY = bottomleft.y;

        float maxX = topright.x;
        float maxY = topright.y;

        float x = Random.Range(minX, maxX);
        return x;
    }

    public static float GenerateRandomY()
    {
        var cam = Camera.main;
        var bottomleft = cam.ViewportToWorldPoint(Vector3.zero);
        var topright = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        float minX = bottomleft.x;
        float minY = bottomleft.y;

        float maxX = topright.x;
        float maxY = topright.y;

        float y = Random.Range(minY, maxX);
        return y;
    }



    public static void GameOver()
    {
        uiController.EndOfGame();
    }

    public static void DestoryPlanet(GameObject planetToRemove)
    {
        Destroy(planetToRemove);
    }

    public static float CalculateDistance(float y)
    {
        return 0;
    }*/
}