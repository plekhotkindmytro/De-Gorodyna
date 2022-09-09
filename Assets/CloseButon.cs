using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseButon : MonoBehaviour
{
    public void Close()
    {
        DOTween.Clear();
        SceneManager.LoadScene(0);
    }
}
