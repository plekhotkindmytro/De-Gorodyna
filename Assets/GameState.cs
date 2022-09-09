using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private List<IFood> targetFoodList;
    private bool startNewLevel;

    public List<IFood> TargetFoodList { get; set; }
    public bool StartNewLevel { get => startNewLevel; set => startNewLevel = value; }


    private void Start()
    {
        startNewLevel = true;
    }

  
}
