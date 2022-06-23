using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    private Timer timer;  //Timer script reference

    //public float aT = 10f;

    // Start is called before the first frame update
    void Start()
    {
        timer = Timer.LevelTimer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //context suggests using an OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PowerUp Trigger");

        if (other.tag == "Player")
        {
            timer.AddTime();

            Destroy(gameObject);//destroy this gameObject (PowerUp object / instance)
        }

    }//end OnTriggerEnter()

    /**
    public float getAddTime()
    {
        return aT;
    }
    **/
}
