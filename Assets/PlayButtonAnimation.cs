using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayButtonAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float y = transform.localScale.y;
        float x = transform.localScale.x;
        float z = transform.localScale.z;
        float scale = 0.1f;
        Tweener tweener1 = transform.DOScale(new Vector3(x + scale, y + scale, z), 0.5f);



        tweener1.OnComplete(() =>
        {


        });

        tweener1.SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
