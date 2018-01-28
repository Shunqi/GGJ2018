using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public GameMgr instance = null;

    private UIMgr uiController;
    private int status;
    private int score;
    // private GameObject[] planets;
    private Queue<GameObject> planets;
    private GameObject planetPrefab;
    private GameObject rocketPrefab;
    private float currentY;
    private GameObject rocket;

    public static int PAUSE = 0;
    public static int RUNNING = 1;
    public static int MENU = 2;

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
        status = MENU;
        
        GameObject UIManagerObject = GameObject.Find("UICanvas");

        uiController = UIManagerObject.GetComponent<UIMgr>();

        // Initiate UI panel
        uiController.InitMenu();

        InitGame();
    }

    public void InitGame()
    {
        
        planetPrefab = Resources.Load("Earth") as GameObject;
        rocketPrefab = Resources.Load("Rocket") as GameObject;

        planets = new Queue<GameObject>();

        // First two planets, hard-coded
        SpawnPlanet(0, -1.5f);
        SpawnPlanet(0, 4.65f).GetComponent<Planet>().RandomizeSprite();
        currentY = 4.5f;

        GenerateRocket();

    }

    // For rocket to get to the correct planet
    public Transform getMotherTransform()
    {
        return planets.Peek().transform;
    }


    public void StopGame()
    {
        // Change state to Pause
        status = PAUSE;
    }

    public void StartGame()
    {
        // Change satate to Start
        status = RUNNING;
    }

    public void RestartGame()
    {
        status = RUNNING;
        // Destroy all existing planets
        while (planets.Count > 0)
        {
            Destroy(planets.Dequeue());
        }

        // Destroy rocket
        // Bullet rocket = GameObject.FindObjectOfType<Bullet>();
        Destroy(rocket);

        InitGame();
    }

    public void GenerateRocket()
    {
        GameObject newRocket = Instantiate(rocketPrefab);
        newRocket.GetComponent<Bullet>();
        rocket = newRocket;
    }
    

    public int GetScore()
    {
        return score;
    }

    // For GamePlay to disable space click
    public int GetStatus()
    {
        return status;
    }

    /*
        Update score by addtion and push changes to UI side
        newScore: the score to add
        always be 1 for now, will add more bonus in the future
    */
    public void AddScore(int newScore)
    {
        score += newScore;
        uiController.UpdateScores(score);


        GameObject planetToRemove = planets.Dequeue();
        float diff = planets.Peek().transform.position.y - planetToRemove.transform.position.y;
        uiController.ShiftCamera(diff);


        float x = GenerateRandomX();
        float y = GenerateRandomY();

        SpawnPlanet(x, y).GetComponent<Planet>().RandomizeSprite();
        Destroy(planetToRemove);
    }

    // Create new planet
    public GameObject SpawnPlanet(float x, float y)
    {
        GameObject newPlanet = Instantiate(planetPrefab);
        newPlanet.GetComponent<Planet>().Initialize(new Vector3(x, y, 0));

        Debug.Log("New Planet: " + x + ", " + y);

        planets.Enqueue(newPlanet);

        return newPlanet;
    }

    public float GenerateRandomX()
    {
        var cam = Camera.main;
        var bottomleft = cam.ViewportToWorldPoint(Vector3.zero);
        var topright = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        float minX = bottomleft.x;

        float maxX = topright.x;

        float x = Random.Range(minX + 2f, maxX - 2f);
        return x;
    }

    public float GenerateRandomY()
    {
        var cam = Camera.main;
        var bottomleft = cam.ViewportToWorldPoint(Vector3.zero);
        var topright = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));

        float minY = bottomleft.y;
        
        float maxY = topright.y;

        float y = Random.Range((maxY - minY) * 1 / 2 + currentY - 2f, currentY + (maxY - minY) - 3f);
        currentY = y;
        return y;
    }

    public void GameOver()
    {
        Debug.Log("here");
        uiController.EndOfGame();
    }

    public float CalculateDistance(float y)
    {
        return 0;
    }
}