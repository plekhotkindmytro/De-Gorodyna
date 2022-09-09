using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        DOTween.Clear();
        SceneManager.LoadScene(1);
    }

}
