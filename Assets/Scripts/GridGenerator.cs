using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

// Generates gird
// Manipulates grid?

public class GridGenerator : MonoBehaviour
{
    public GameState gameState;
    public GameObject tileMasterPrefab;

    public int rowCount;
    public int columnCount;

    private int menuRowSize = 2;
    private GameObject[,] grid;
    private List<IFood> allFoodList;

    void Start()
    {
        string allTileNames = "";
        for (int i = 0; i < tileMasterPrefab.transform.childCount; i++)
        {

            allTileNames += tileMasterPrefab.transform.GetChild(i).name + " ";
        }

        if (PlayerPrefs.HasKey(DifficultyModeController.DIFFICULTY_MODE_KEY))
        {
            rowCount = columnCount = PlayerPrefs.GetInt(DifficultyModeController.DIFFICULTY_MODE_KEY);

        }
    }

    public GameObject[,] GenerateGrid()
    {
        

        DestroyPreviousGrid();
        grid = new GameObject[rowCount, columnCount];
        allFoodList = new List<IFood>();

        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                GameObject tile = CreateTile(rowIndex, columnIndex);
                
               
                addAnimation(tile);
                grid[rowIndex, columnIndex] = tile;
                IFood food = tile.GetComponent<IFood>();
                allFoodList.Add(food);
                 
            }
        }

        MoveCamera(grid[0, 0]);

        DefineCurrentFoodList();
        return grid;

    }

    private void addAnimation(GameObject tile)
    {
        Tweener tweener = tile.transform.DOShakeScale(2, 0.5f, 5, 50, true);
        tweener.OnComplete(() =>
        {
            tweener.Kill();
        });
    }

    private void DefineCurrentFoodList()
    {
        int tileIndex = UnityEngine.Random.Range(0, allFoodList.Count);
        IFood currentFood = allFoodList[tileIndex];
        List<IFood> sameTypeFoodList = new List<IFood>();

        foreach (IFood food in allFoodList)
        {
            if (currentFood.Type.Equals(food.Type))
            {
                sameTypeFoodList.Add(food);
                
            }
        }

        gameState.TargetFoodList = sameTypeFoodList;

        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {

                GameObject tile = grid[rowIndex, columnIndex];
                IFood food = tile.GetComponent<IFood>();
                if (currentFood.Type.Equals(food.Type))
                {
                    AddWaitingAnimation(tile);

                }
                
            }
        }
    }

    private void AddWaitingAnimation(GameObject gameObject) 
    {
        float y = gameObject.transform.localScale.y;
        float x = gameObject.transform.localScale.x;
        float z = gameObject.transform.localScale.z;
        float scale = 0.4f;
        Tweener tweener1 = gameObject.transform.DOScale(new Vector3(x + scale, y + scale, z), 0.5f);
        tweener1.SetDelay(5);


        tweener1.OnComplete(() =>
        {


        });

        tweener1.SetLoops(-1, LoopType.Yoyo);
    }

    private void DestroyPreviousGrid()
    {
        if (grid != null)
        {
            //DOTween.Clear();
            for (int rowIndex = 0; rowIndex < grid.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < grid.GetLength(1); columnIndex++)
                {
                    Destroy(grid[rowIndex, columnIndex]);
                }
            }

            grid = null;
            allFoodList = null;
            gameState.TargetFoodList = null;
        }
    }

  /*  private void appendRandomShake(Sequence sequence)
    {
        int randomRow = UnityEngine.Random.Range(0, rowCount);
        int randomColumn = UnityEngine.Random.Range(0, columnCount);

        sequence.Append(grid[randomRow, randomColumn].transform.DOShakeScale(2));
    }*/

    private void MoveCamera(GameObject tile)
    {
        float x = (columnCount - 1) * tile.transform.localScale.x / 2;
        float y = (rowCount - 1) * tile.transform.localScale.y / 2;

        Camera.main.transform.position = new Vector3(x, y, Camera.main.transform.position.z);
    }

    private GameObject CreateTile(int rowIndex, int columnIndex)
    {
        int randomChildPrefabIndex = UnityEngine.Random.Range(0, tileMasterPrefab.transform.childCount);
        GameObject randomChildPrefab = tileMasterPrefab.transform.GetChild(randomChildPrefabIndex).gameObject;
        GameObject tile = Instantiate(randomChildPrefab);

        SetScale(tile);
        SetPosition(tile, rowIndex, columnIndex);
        return tile;
    }

    private void SetScale(GameObject tile)
    {
        float x = Camera.main.aspect * Camera.main.orthographicSize * 2 / columnCount;
        float y = (Camera.main.orthographicSize * 2 - menuRowSize) / rowCount;

        if (x > y)
        {
            x = y;
        }
        else
        {
            y = x;
        }

        tile.transform.localScale = new Vector3(x, y, tile.transform.localScale.z);
    }

    private void SetPosition(GameObject tile, int rowIndex, int columnIndex)
    {
        float x = tile.transform.localScale.x * columnIndex;
        float y = tile.transform.localScale.y * rowIndex;

        tile.transform.position = new Vector3(x, y, tile.transform.position.z);
    }
}
