using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingUI : MonoBehaviour {

    GameMgr gameMgr;
    public Text endingText;
    public Image endingImage;
    string part1 = "You have \n  delivered messages \n to ";
    string part2 = " planets, \n";
    string part3 = "we have \n made some friends \n across the galaxy! ";
    
    
    public void ShowEnding()
    {
        
        int score = gameMgr.GetScore();
        endingText.text = part1 + score + part2 + part3;
        
        endingImage.gameObject.SetActive(true);
        endingText.gameObject.SetActive(true);
    }

    public void UnShowEnding()
    {
        endingImage.gameObject.SetActive(false);
        endingText.gameObject.SetActive(false);

    }
	// Use this for initialization
	void Start () {
        gameMgr = FindObjectOfType<GameMgr>().instance;
        //endingText = new Text();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
