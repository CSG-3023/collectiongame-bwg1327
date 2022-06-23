/****
* Created by: Brennan Gillespie
* Date Created: June 16, 2022
*
* Last Edited by:Brennan
* Last Edited: June 17, 2022
*
* Description: A level timer that can be set and controlled
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    #region Timer Singleton
    static private Timer timer; //Timer instance
    static public Timer LevelTimer { get { return timer; } } //public access to read only timer
                                                             //Check to make sure only Timer instance in the scene

    void CheckTimerIsInScene()
    {
        //Check if instance is null
        if (timer == null)
        {
            timer = this; //set timer to this Timer instance
            Debug.Log(timer);
        }
        else //else if timer is not null a Timer must already exist
        {
            Destroy(this.gameObject); //In this case you need to delete this timer
        }
    }//end CheckTimerIsInScene()
    #endregion

    //Timer Singleton
    //I had above written in code like in step 4 of part 4 but caused compiler errors
    //In hindsight I assume it just meant it was above to represent the region
    [Tooltip("Start time in seconds")] 
    public float startTime = 10f; //time for level (if level is timed)

    [Tooltip("Time increase for PowerUp")]
    public float addTime = 10f;  //the amount of time that is added when a powerup is picked up
                                 // is used for the AddTime() method

    //public PowerUp addT;
    //part of experiment to make addtime apart of power up not time

    private float currentTime; //current time of timer

    [HideInInspector]
    public bool timerStopped = false; //check if timer is stopped

    // Awake is called on instantiation before Start
    void Awake()
    {
        //runs the method to check for the Timer
        CheckTimerIsInScene();
    }//end Awake()

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime; //set the current time to the startTime specified
    }//end Start()

    // Update is called once per frame
    void Update()
    {
        RunTimer();
    }//end Update()

    //Runs the timer countdown
    private void RunTimer()
    {
        if (timerStopped)
        {
            // check to see if timer has stoped
            LevelEnd();
        }
        else
        {
            if(currentTime > 0)
            {
                //if still time, update timer countdown
                currentTime -= Time.deltaTime;
                                //had typed Timer.deltaTime and cause startTime to not work properly
            }
            else
            {
                //if the timer is less than zero
                currentTime = 0; //set time to zero
                timerStopped = true; //stop the timer
            }

            Debug.Log(DisplayTime(currentTime)); //Log time

        }

    }//end RunTimer();

    //Runs events for the end of the level
    private void LevelEnd()
    {
        Debug.Log("level end");
    }//end LevelEnd()

    //Formats time as string
    private string DisplayTime(float timeToDispaly)
    {
        timeToDispaly += 1; //adds 1 to time, to accuratly refelect time in field

        float minutes = Mathf.FloorToInt(timeToDispaly / 60); //calculate timer mintues
        float seconds = Mathf.FloorToInt(timeToDispaly % 60); //calculate timer seconds

        return string.Format("{0:00}:{1:00}", minutes, seconds); //retrun time as string

    }//end DisplayTime

    //amount of time increase when picking up a powerUp
    public void AddTime()
    {
        currentTime += addTime;
    } //addition of this element will require rebalance of time from main branch
}
