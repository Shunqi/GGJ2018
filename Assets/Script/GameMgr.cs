using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public GameMgr instance = null;

    private UIMgr uiMgr;
    private bool isPause;
    private int score;
    public GameObject[] planets;
    GameObject planetPrefab;
    GameObject rocketPrefab;

    //public Queue planets;


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

        uiMgr = UIManagerObject.GetComponent<UIMgr>();

        InitGame();
    }

    public void InitGame()
    {
        // Initiate UI panel
        uiMgr.InitMenu();
        planets = new GameObject[2];
        //planets = new Queue.<game>();


        // initial position
        planets[0] = SpawnPlanet(-2, -2);

        float x = GenerateRandomX();
        float y = GenerateRandomY();
        planets[1] = SpawnPlanet(x, y);

        GameObject rocket = GenerateRocket();
        
    }

    public void Pause()
    {
        // Change state to Pause
        isPause = true;
    }

    public void Start()
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
        uiMgr.UpdateScores(score);

        float x = GenerateRandomX();
        float y = GenerateRandomY();

        GameObject newPlanet = SpawnPlanet(x, y);

        uiMgr.ShiftCamera(planets[1].transform.position.y - planets[0].transform.position.x);

        FindObjectOfType<Bullet>().motherPlanet = planets[1].transform;

        DestroyPlanet(planets[0]);

        planets[0] = planets[1];
        planets[1] = newPlanet;

    }

    // Create new planet
    public GameObject SpawnPlanet(float x, float y)
    {
        GameObject target = GenerateRandomPlanet();
        Instantiate(target);
        target.GetComponent<Planet>().Initialize(new Vector3(x,y,0));
        return target;
    }

    // Randomly select a prefad
    public GameObject GenerateRandomPlanet()
    {
        GameObject instance = Resources.Load("Earth") as GameObject;
        return instance;
    }

    public GameObject GenerateRocket()
    {
        GameObject instance = Resources.Load("Rocket") as GameObject;
        GameObject newRocket = Instantiate(instance);
        var mother = planets[0].transform;
        instance.GetComponent<Bullet>().Initialize(mother);
        return newRocket;
    }

    public float GenerateRandomX()
    {
        var cam = Camera.main;
        var bottomleft = cam.ViewportToWorldPoint(Vector3.zero);
        var topright = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        float minX = bottomleft.x;

        float maxX = topright.x;

        float x = Random.Range(minX, maxX);
        return x;
    }

    public float GenerateRandomY()
    {
        var cam = Camera.main;
        var bottomleft = cam.ViewportToWorldPoint(Vector3.zero);
        var topright = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        float minY = bottomleft.y;
        
        float maxY = topright.y;

        float y = Random.Range((maxY + minY) / 2, maxY);
        return y;
    }



    public void GameOver()
    {
        uiMgr.EndOfGame();
    }

    public void DestroyPlanet(GameObject planetToRemove)
    {
        Destroy(planetToRemove);
    }

    public float CalculateDistance(float y)
    {
        return 0;
    }
}