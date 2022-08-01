/****
 * Created by: Brennan Gillespie
 * Date Created: June 15, 2022
 * 
 * Last Edited by:
 * Last Edited:
 * 
 * Description: Collectable object behaviors for counting the total amount of collectables and checking for collision with the player.
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    GameManager gm; //fixing bugs

    /***VARIABLES***/

    static public int collectableCount;//counts the number of collectables in the scene

    //Awake is called on instantiation before Start
    void Awake()
    {
        collectableCount++; //add to collectable
        Debug.Log("Number of Colletables " + collectableCount);

        gm = GameManager.GM;

    }//end Awake()

    //Called when a GameObject collides with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collectable Triggered");

        if(other.tag == "Player")
        {
            other.GetComponent<Collection>().AddToCollection(); //call method on the Collection component of other object

            Destroy(gameObject);//destroy this gameObject (collectable object)
        }

    }//end OnTriggerEnter()

    //created because of a bug that occurs when you restart a level and the amount of collectable required to win doubles
    /*
    void update()
    {
        if (gm.GetCurrentState() == GameState.gameLevelEnded)
        {
            collectableCount = 0;
        }
    }
    */
}
