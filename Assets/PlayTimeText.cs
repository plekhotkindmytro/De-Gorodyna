using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTimeText : MonoBehaviour
{
    void Start()
    {
        
        int playTimeSeconds = 0;
        if (PlayerPrefs.HasKey(PlayTimeCalculation.PLAY_TIME_KEY))
        {
            playTimeSeconds = PlayerPrefs.GetInt(PlayTimeCalculation.PLAY_TIME_KEY);
        }

        if (playTimeSeconds == 0) 
        {
            transform.GetComponent<TMPro.TMP_Text>().text = "";
        }
        transform.GetComponent<TMPro.TMP_Text>().text += convertToHumanReadableTime(playTimeSeconds);

    }

    private string convertToHumanReadableTime(int playTimeSeconds)
    {
        int days = playTimeSeconds / (60 * 60 * 24);
        int remainder = playTimeSeconds % (60 * 60 * 24);
        int hours = remainder / (60 * 60);
        remainder = remainder % (60 * 60);

        int minutes = remainder / 60;
        remainder = remainder % 60;
        int seconds = remainder;

        string result = "";
        if (days > 0)
        {
            result += days;
            if (days >= 10 & days <= 20)
            {
                result += " днів ";
            }
            else if (days % 10 == 1)
            {
                result += " день ";
            }
            else if (days % 10 == 2
                || days % 10 == 3
                || days % 10 == 4)
            {
                result += " дні ";
            }
            else
            {
                result += " днів ";
            }
        }

        if (hours > 0)
        {
            result += hours;
            if (hours >= 10 & hours <= 20)
            {
                result += " годин ";
            }
            else if (hours % 10 == 1)
            {
                result += " година ";
            }
            else if (hours % 10 == 2
                || hours % 10 == 3
                || hours % 10 == 4)
            {
                result += " години ";
            }
            else
            {
                result += " годин ";
            }
        }

        if (minutes > 0)
        {
            result += minutes;
            if (minutes >= 10 & minutes <= 20)
            {
                result += " хвилин ";
            }
            else if (minutes % 10 == 1)
            {
                result += " хвилина ";
            }
            else if (minutes % 10 == 2
                || minutes % 10 == 3
                || minutes % 10 == 4)
            {
                result += " хвилини ";
            }
            else
            {
                result += " хвилин ";
            }
        }

        if (seconds > 0)
        {
            result += seconds;
            if (seconds >= 10 & seconds <= 20)
            {
                result += " секунд ";
            }
            else if (seconds % 10 == 1)
            {
                result += " секунда ";
            }
            else if (seconds % 10 == 2
                || seconds % 10 == 3
                || seconds % 10 == 4)
            {
                result += " секунди ";
            }
            else
            {
                result += " секунд ";
            }
        }



        return result;
    }
}
