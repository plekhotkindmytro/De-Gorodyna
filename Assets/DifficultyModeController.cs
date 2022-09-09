using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DifficultyModeController : MonoBehaviour
{
    // Start is called before the first frame update

    public static readonly string DIFFICULTY_MODE_KEY = "difficultyMode";
    void Start()
    {
        int currentDifficulty = 3;

        if (PlayerPrefs.HasKey(DIFFICULTY_MODE_KEY))
        {
            currentDifficulty = PlayerPrefs.GetInt(DIFFICULTY_MODE_KEY);
        }
        int thisDifficulty = Int32.Parse(this.name.Replace("mode", ""));
        if (thisDifficulty == currentDifficulty)
        {
            SetAllInactive();
            SetThisActive();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDifficulty()
    {
        PlayerPrefs.SetInt(DIFFICULTY_MODE_KEY, Int32.Parse(this.name.Replace("mode", "")));

        SetAllInactive();
        SetThisActive();
    }

    private void SetAllInactive()
    {
        Transform parent = transform.parent;
        for (int i = 0; i < parent.childCount; i++)
        {
            parent.GetChild(i).GetComponentInChildren<TMP_Text>().color = Color.black;
        }
    }

    private void SetThisActive()
    {
        this.GetComponentInChildren<TMP_Text>().color = Color.white;
    }
}
