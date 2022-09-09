using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float y = transform.position.y;
        float x = transform.position.x;
        float z = transform.position.z;
        Tweener tweener1 = transform.DOMove(new Vector3(x, y + 30, z), 2);
       


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
