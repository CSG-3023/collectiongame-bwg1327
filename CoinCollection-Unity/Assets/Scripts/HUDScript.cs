/****
* Created by: Brennan Gillespie
* Date Created: July 5, 2022
*
* Last Edited by: Brennan Gillespie
* Last Edited: July 20, 2022
*
* Description: Manages the UI elements for the menu scenes
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //libraries for UI components
using TMPro; //libraries for TextMeshPro components

public class HUDScript : MonoBehaviour
{
    GameManager gm; //reference to game manager

    //GM Data
    private int level;
    private int totalLevels;
    private int lives;
    private int score;
    private int highscore;
    //added for gdc 2
    private string timer;
    private string collection;

    [Header("Stats Placement")]
    public TMP_Text levelCountTextbox; //textbox for level count
    public TMP_Text livesTextbox; //textbox for the lives
    public TMP_Text healthTextbox; //textbox for health
    public TMP_Text scoreTextbox; //textbox for the score
    public TMP_Text highScoreTextbox; //textbox for highscore
    public TMP_Text collectableCountTextbox; //textbox for amount of collectables
    public TMP_Text timerTextbox; //textbox for Timer display
    public TMP_Text fastestTimeTextbox; //textbox for the Fastest Time

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GM; //find the game manager
        //reference to levle info
        level = gm.gameLevelsCount;
        totalLevels = gm.gameLevels.Length;

    }//end Start()

    // Update is called once per frame
    void Update()
    {
        GetGameStats();
        SetHUD();
    }//end Update()

    void GetGameStats()
    {
        lives = gm.Lives;
        score = gm.Score;
        highscore = gm.HighScore;
        timer = gm.timer;
        collection = gm.collection;

    }//end GetGameStats()

    void SetHUD()
    {
        //if texbox exsists update value
        if (levelCountTextbox)
        {
            levelCountTextbox.text = "Level " + level + "/" + totalLevels;
        }
        if (livesTextbox) { livesTextbox.text = "Lives " + lives; }
        if (scoreTextbox) { scoreTextbox.text = "Score " + score; }
        if (highScoreTextbox) { highScoreTextbox.text = "High Score " + highscore; }
        if (timerTextbox) { timerTextbox.text = "Time: " + timer; }
        if (collectableCountTextbox) { collectableCountTextbox.text = "Collected: " + collection; }

    }//end SetHUD()
}
