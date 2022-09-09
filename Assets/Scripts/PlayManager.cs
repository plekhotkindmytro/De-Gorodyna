using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public GameState gameState;
    public GridGenerator gridGenerator;
    public SoundManager soundManager;

    void Update()
    {
        if (gameState.StartNewLevel)
        {
            GameObject[,] grid = gridGenerator.GenerateGrid();
            IFood questionFood = soundManager.PlayQuestionSound();

            gameState.StartNewLevel = false;
        }
    }
    
}
