using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;

public class RandomRatate : MonoBehaviour
{
    [SerializeField] float rotateVal;

    void Start()
    {
        
        //Observable.EveryFixedUpdate().RepeatUntilDestroy(this).Subscribe(t => { transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y +rotateVal * Time.deltaTime, 0); });

    }
    void OnDestroy()
    {
        DOTween.Clear(destroy: true);
    }

}
