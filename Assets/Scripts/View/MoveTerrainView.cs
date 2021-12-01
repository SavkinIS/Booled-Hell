using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MoveTerrainView : MonoBehaviour
{
    float speed;
    float step;
    public void SetProperties(float speed, float step)
    {
        this.speed = speed;
        this.step = step;
    }

    void Start()
    {
        Observable.EveryUpdate().RepeatUntilDestroy(this).Subscribe(x => Mover());
        
    }
    void Mover()
    {
        var z = transform.position.z- step;
        transform.DOMoveZ(z, speed);
    }
    void OnDestroy()
    {
        DOTween.Clear(destroy: true);
    }
}
