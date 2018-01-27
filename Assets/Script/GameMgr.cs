using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public GameMgr instance = null;

    private UIMgr uiController;
    private bool isPause;
    private int score;
    // private GameObject[] planets;
    private Queue<GameObject> planets;
    private GameObject planetPrefab;
    private GameObject rocketPrefab;
    private float currentY;

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
        
        GameObject UIManagerObject = GameObject.Find("UICanvas");

        uiController = UIManagerObject.GetComponent<UIMgr>();

        InitGame();
    }

    public void InitGame()
    {
        // Initiate UI panel
        uiController.InitMenu();

        planetPrefab = Resources.Load("Earth") as GameObject;
        rocketPrefab = Resources.Load("Rocket") as GameObject;

        planets = new Queue<GameObject>();

        // First two planets, hard-coded
        SpawnPlanet(0, -1.9f);
        SpawnPlanet(0, 4.29f).GetComponent<Planet>().RandomizeSprite();
        currentY = 4.29f;

    }

    // For rocket to get to the correct planet
    public Transform getMotherTransform()
    {
        return planets.Peek().transform;
    }


    public void StopGame()
    {
        // Change state to Pause
        isPause = true;
    }

    public void StartGame()
    {
        // Change satate to Start
        isPause = false;
    }
    

    public int GetScore()
    {
        return score;
    }

    // For GamePlay to disable space click
    public bool IsPause()
    {
        return isPause;
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

    // Randomly select a prefad
    public GameObject GenerateRandomPlanet()
    {
        GameObject instance = Resources.Load("earth") as GameObject;
        return instance;
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
        uiController.EndOfGame();
    }

    public float CalculateDistance(float y)
    {
        return 0;
    }
}