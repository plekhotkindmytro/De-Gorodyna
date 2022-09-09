using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTimeCalculation : MonoBehaviour
{
    public static readonly string PLAY_TIME_KEY = "playTime";
    // Start is called before the first frame update

    private float timePassed = 0;
    

    

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        

        if (timePassed >= 5)
        {

            int prevTime = 0;
            if (PlayerPrefs.HasKey(PLAY_TIME_KEY))
            {
                prevTime = PlayerPrefs.GetInt(PLAY_TIME_KEY);
            }
            PlayerPrefs.SetInt(PLAY_TIME_KEY, prevTime + (int)timePassed);
            Debug.Log(PlayerPrefs.GetInt(PLAY_TIME_KEY));
            timePassed = 0;
        }
    }
}
