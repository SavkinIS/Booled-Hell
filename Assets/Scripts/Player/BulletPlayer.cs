using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class BulletPlayer : Bullet
{
    [SerializeField] float speed;
    [SerializeField] float maxRangeZ;
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().Select(t => transform.position).RepeatUntilDestroy(this).Subscribe(tr => transform.Translate(Vector3.forward * speed * Time.deltaTime));
        Observable.EveryUpdate().Where(tp => transform.position.z > maxRangeZ)
            .Select(t => transform.position).RepeatUntilDestroy(this)
            .Subscribe(g => DisableGO());

    }

}
