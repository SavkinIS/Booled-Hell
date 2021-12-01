using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class AsteroidView : EnemyParent
{
    [SerializeField] RandomRatate[] randomRatates;
    float maxRangeZ;
    float speedZ;
    public float SpeedZ { get => speedZ; set => speedZ = value; }
    public float MaxRangeZ { get => maxRangeZ; set => maxRangeZ = value; }


    GameManager gameManager;

    private void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
        Observable.EveryUpdate().RepeatUntilDestroy(this).Subscribe(m => Move(speedZ));
        Instantiate(randomRatates[Random.Range(0, randomRatates.Length - 1)], transform);
        Observable.EveryUpdate().Where(tp => transform.position.z < maxRangeZ)
                .Select(t => transform.position).RepeatUntilDestroy(this)
                .Subscribe(g => DisableGO());
        this.ObserveEveryValueChanged(d => d.destroyed).Where(f => destroyed == true).Subscribe(enM => { gameManager.AddAstr(); });

    }

    

}
