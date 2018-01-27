using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour {

    // title UIs
    public GameObject titleUIs;
    public Image titleImage;
    public Button titleStartButton;

    // gameplay UIs
    public GameObject gameplayUIs;
    public Button gameplayPauseButton;
    public Button gameplayCreditButton;
    public TextMesh gameplayScoreText;

    // pauseMenu UIs
    public GameObject pauseUIs;
    public Button pauseResumeButton;
    public Button pauseRestartButton;

    // endGame UIs
    public GameObject endGameUIs;
    public Image endGameRetryButton;

    // credit UIs
    public GameObject creditUIs;

    // animation variables
    float startTime;
    int animationType = 0;
    float[] animationDuration = { 0, 1, 2 };

    float initialCameraPositionY;
    float targetCameraPositionY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (animationType) {
            case 1:
                Camera.main.orthographicSize = Mathf.Lerp(2.6f, 5, (Time.time - startTime) / animationDuration[1]);
                if (Camera.main.orthographicSize >= 5)
                { 
                    animationType = 0;
                    InitGame();
                }
                break;
            case 2:
                Vector3 position = Camera.main.transform.position;
                position.y = Mathf.Lerp(targetCameraPositionY, initialCameraPositionY, (Time.time - startTime) / animationDuration[2]);
                Camera.main.transform.position = position;
                if (position.y >= targetCameraPositionY)
                {
                    animationType = 0;
                }
                break;
            default: break;
        }
	}
    
    // this function is intended to disable the UI temporary
    public void HideUI()
    {
        titleUIs.SetActive(false);
        gameplayUIs.SetActive(false);
        gameplayScoreText.gameObject.SetActive(false);
        pauseUIs.SetActive(false);
        endGameUIs.SetActive(false);
        creditUIs.SetActive(false);
    }

    // this function is intended to display the title layouts
    public void InitMenu()
    {
        titleUIs.SetActive(true);
        gameplayUIs.SetActive(false);
        gameplayScoreText.gameObject.SetActive(false);
        pauseUIs.SetActive(false);
        endGameUIs.SetActive(false);
        creditUIs.SetActive(false);
    }
    
    // this function is intended to display the gameplay layouts
    public void InitGame()
    {
        titleUIs.SetActive(false);
        gameplayUIs.SetActive(true);
        gameplayScoreText.gameObject.SetActive(true);
        pauseUIs.SetActive(false);
        endGameUIs.SetActive(false);
        creditUIs.SetActive(false);
    }

    // this function is intended to display the pauseMenu layouts
    public void Pause()
    {
        pauseUIs.SetActive(true);
        // GameMgr.ChangeState();
    }
    public void Resume()
    {
        pauseUIs.SetActive(false);
        // GameMgr.ChangeState();
    }

    // this function is intended to display the endGame layouts
    public void EndOfGame()
    {
        titleUIs.SetActive(false);
        gameplayUIs.SetActive(false);
        gameplayScoreText.gameObject.SetActive(true);
        pauseUIs.SetActive(false);
        endGameUIs.SetActive(true);
        creditUIs.SetActive(false);
    }

    // this function is intended to translate the camera to a y posit
    public void ShiftCamera(int length)
    {
        initialCameraPositionY = Camera.main.transform.position.y;
        targetCameraPositionY = initialCameraPositionY + length;
        animationType = 2;
        //Camera.main.transform.Translate(new Vector3(0, length, 0));
    }

    // this function is intended to update scores
    public void UpdateScores(int scores)
    {
        gameplayScoreText.text = "" + scores;
    }

    // 

    // this function is intended to handle start game effects and related start game calls
    public void StartGame()
    {
        animationType = 1;
        startTime = Time.time;
        HideUI();
    }

    // this function is intended to show credits
    public void ShowCredits()
    {
        titleUIs.SetActive(false);
        gameplayUIs.SetActive(false);
        gameplayScoreText.gameObject.SetActive(true);
        pauseUIs.SetActive(false);
        endGameUIs.SetActive(false);
        creditUIs.SetActive(true);
    }
}
