using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyView : EnemyParent
{

    [SerializeField] EnemyShoot enemyShoot;
    [SerializeField] GameObjectPool gameObjectPool { get; set; }

    EnemyLevelManager enemyLevelManager;
    GameManager gameManager;

    float speedZ;
    float maxRangeZ;
    public float MaxRangeZ { get => maxRangeZ; set => maxRangeZ = value; }
    public float SpeedZ { get; set; }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Observable.EveryUpdate().RepeatUntilDestroy(this).Subscribe(m => Move(speedZ));
       
        Observable.EveryUpdate().Where(tp => transform.position.z < maxRangeZ)
            .Select(t => transform.position).RepeatUntilDestroy(this)
            .Subscribe(g => DisableGO());
        this.ObserveEveryValueChanged(d => d.destroyed).Where(f=>destroyed==true).RepeatUntilDestroy(this).Subscribe(enM => { gameManager.AddEnemy(); gameManager.ChangeEnemyCount(); });
    }


    public void Init(float speedZ, float shootRate)
    {
        this.speedZ = speedZ;
        enemyShoot.ShootRate = shootRate;
    }

}
