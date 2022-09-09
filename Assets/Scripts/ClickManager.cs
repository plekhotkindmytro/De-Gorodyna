using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickManager : MonoBehaviour
{
    public SoundManager soundManager;
    public GameState gameState;
    void Start()
    {

    }

    void Update()
    {
        if (Input.touches != null && Input.touches.Length > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    CheckClickAndDoAction(touch.position);
                }
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            CheckClickAndDoAction(Input.mousePosition);
        }
    }

    private void CheckClickAndDoAction(Vector2 position)
    {
        Camera cam = Camera.main;

        //Raycast depends on camera projection mode
        Vector2 origin = Vector2.zero;
        Vector2 dir = Vector2.zero;

        if (cam.orthographic)
        {
            origin = Camera.main.ScreenToWorldPoint(position);
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(position);
            origin = ray.origin;
            dir = ray.direction;
        }

        RaycastHit2D hit = Physics2D.Raycast(origin, dir);

        //Check if we hit anything
        if (hit.collider && hit.collider.gameObject)
        {
            if (hit.collider.gameObject.name.Equals("BackButton"))
            {
                SceneManager.LoadScene("MenuScene");
            }
            else
            {
                GameObject tile = hit.collider.gameObject;
                IFood food = tile.GetComponent<IFood>();
               // Debug.LogError("Target food count before: " + gameState.TargetFoodList.Count);
                if (gameState.TargetFoodList.Contains(food))
                {
                    animateClicked(tile);
                    soundManager.PlayCorrectSound();

                }
                else 
                {
                    soundManager.PlayIncorrectSound();
                }
                


            }
        }
    }

    void animateClicked(GameObject tile)
    {
        Vector3 newScale = new Vector3(tile.transform.localScale.x + 1, tile.transform.localScale.y + 1, tile.transform.localScale.z);
        Tweener tweener = tile.transform.DOScale(newScale, 1);
        tile.transform.GetComponent<Renderer>().material.DOFade(0, 1);
        
        tweener.OnComplete(() =>
        {
            tile.SetActive(false);
            tweener.Kill();
            UpdateGameState(tile);
        });
    }

    private void UpdateGameState(GameObject tile)
    {
        IFood food = tile.GetComponent<IFood>();
        gameState.TargetFoodList.Remove(food);
        if (gameState.TargetFoodList.Count == 0)
        {
            //  Debug.LogError("Target food count after: " + gameState.TargetFoodList.Count);
            gameState.StartNewLevel = true;
        }
        else 
        {
            soundManager.PlayMoreSound();
        }
    }
}