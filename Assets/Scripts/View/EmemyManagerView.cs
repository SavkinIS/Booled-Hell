using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Assets.Scripts.Controller;
using Assets.Scripts.Model;

public class EmemyManagerView : MonoBehaviour
{
    
    [SerializeField] GameObjectPool enemyshipPool;
    [SerializeField] EnemyView enemyView;
    float shootRate;
    float speedZEnemy;
    float maxRangeZ;
    float spawnPeriod;
    float xRangePos;
    int enemyAmount;
    
    

    List<EnemyController> enemyControllers;
    EnemyModel enemyModel;

    

    void Start()
    {
        #region EnemyShip
        enemyControllers = new List<EnemyController>();
        enemyModel = new EnemyModel(speedZEnemy, shootRate);
        enemyshipPool.InitPool(enemyView.gameObject, enemyAmount);        
        #endregion
        
        Observable.Interval(System.TimeSpan.FromSeconds(spawnPeriod )).RepeatUntilDestroy(this)
            .Subscribe(_ => SpawnEnemy());
    }
    void SpawnEnemy()
    {
        var  pooledProjectileGO = enemyshipPool.GetPooledObject();
        if (pooledProjectileGO == null) return;
        var pooledProjectile = pooledProjectileGO.GetComponent<EnemyView>();
        pooledProjectile.MaxRangeZ = maxRangeZ;
        
        enemyControllers.Add(new EnemyController(enemyModel, pooledProjectile));
        pooledProjectile.destroyed = false;
        Spawn(pooledProjectile.gameObject);
        
    }

    private void Spawn(GameObject pooledProjectile)
    {
        if (pooledProjectile != null)
        {
            var rndPosX = Random.Range(-xRangePos, xRangePos);
            pooledProjectile.gameObject.SetActive(true);
            pooledProjectile.transform.position = new Vector3(rndPosX, pooledProjectile.transform.localScale.y / 2, transform.position.z);

        }
    }

    public void Init(float shootRate,
    float speedZEnemy,
    float maxRangeZ,
    float spawnPeriod,
    float xRangePos, int enemyCount)
    {
        this.shootRate = shootRate;
         this.speedZEnemy= speedZEnemy;
         this.maxRangeZ= maxRangeZ;
         this.spawnPeriod = spawnPeriod;
         this.xRangePos= xRangePos;
        this.enemyAmount = enemyCount;
    }

}
