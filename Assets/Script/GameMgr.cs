using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr instance = null;

    private UIController uiController;
    private GameController gameController;
    private bool isPause;
    
    private int score;


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

        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        GameObject uiControllerObject = GameObject.FindWithTag ("UIController");

        uiController = uiControllerObject.GetComponent<UIManager>();
        gameController = gameControllerObject.GetComponent<GamePlayManager>();

        InitGame();
    }

    void InitGame()
    {
        uiController.InitMenu();
    }

    
    public static void Pause()
    {
        uiController.Pause();
        isPause = true;
    }

    // For both start and restart
    public static void Start()
    {
        uiController.InitGame();
        isPause = false;
    }

    public static void Resume()
    {
        uiController.Resume();
        isPause = false;
    }

    public static int GetScore()
    {
        return score;
    }

    public static bool IsPause()
    {
        return isPause;
    }

    /* 
    Update score by addtion
    newScore: the score to add
    always be 1 for now, will add more bonus in the future
     */
    public static void AddScore(int newScore)
    {
        score += newScore;
        uiController.UpdateScore(score);
    }

}