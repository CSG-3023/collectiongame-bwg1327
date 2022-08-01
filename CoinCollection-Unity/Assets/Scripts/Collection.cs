/****
 * Created by: Brennan Gillespie
 * Date Created: June 16, 2022
 *
 * Last Edited by: Brennan Gillespie
 * Last Edited: June 17, 2022
 *
 * Description: Manages collections and wining conditions.
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    GameManager gm; //reference to gameMAnager script

    /***VARIABLES***/
    [Tooltip("Number of collectables to beat level")]
    public int winCollectAmount; //number of collectables to beat the level

    [Tooltip("Use the total number of collectables for the win amount")]
    public bool useCollectableCount; //Do we use the collectable count

    [HideInInspector]
    private bool hasCollectedAll = false; //have all collectables been collected

    private int collectablesInCollection = 0; //number of collectables collected by player 

    private Timer timer;//reference to level timer

    void Awake()
    {
        gm = GameManager.GM; //setting the reference
    }//end of awake
    //awake did not exist prior to need for gm, was probably deleted, so I remade it

    // Start is called before the first frame update
    void Start()
    {
        timer = Timer.LevelTimer;//reference the level timer

        //if we are using the collectable count
        if(useCollectableCount)
        {
            //set the win amount to the amount of collectables in the scene
            winCollectAmount = Collectable.collectableCount;
        }//end if(useCollectableCount)

        Debug.Log("Win collect amount: " + winCollectAmount);

    }//end Start()

    // Update is called once per frame
    void Update()
    {
        if (collectablesInCollection == winCollectAmount)
        {
            hasCollectedAll = true;

            //if timer exsist, stop timer
            if (timer != null) { timer.timerStopped = true; }

            Debug.Log("You win!");
        }

        gm.collection = (collectablesInCollection + "/" + winCollectAmount);//values of collection in manager for use in HUD

    }//end Update()

    //Add to collection
    public void AddToCollection()
    {
        collectablesInCollection++; //add to cmount in collection
        Debug.Log("Collectable Added");
    }//end AddToCollection()

}
