using Assets.Scripts.Controller;
using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class RandomEnviromentManager : MonoBehaviour
{ 
    [SerializeField] GameObjectPool cubePool;
    [SerializeField] AsteroidView cubeView;


    [SerializeField] float xRangePos;
    [SerializeField] float maxRangeZ;
    [SerializeField] float speedZAster;
    [SerializeField] float cubeSpanPeriod;
    [SerializeField] int cubeAmount;

    List<AsteroidController> cubeControllers;
    AsteroidModel cubeModel;




    public int CubeAmount { get => cubeAmount; set => cubeAmount = value; }
    // Start is called before the first frame update
    void Start()
    {
        #region Asteroid        
        cubeControllers = new List<AsteroidController>();
        cubeModel = new AsteroidModel(speedZAster);
        cubePool.InitPool(cubeView.gameObject, cubeAmount);
        #endregion

        Observable.Interval(System.TimeSpan.FromSeconds(Random.Range(0.7f, cubeSpanPeriod))).RepeatUntilDestroy(this)
            .Subscribe(_ => SpawnAsteroids());
    }


    void SpawnAsteroids()
    {
        AsteroidView pooledProjectile = cubePool.GetPooledObject().GetComponent<AsteroidView>();
        pooledProjectile.MaxRangeZ = maxRangeZ;
        cubeControllers.Add(new AsteroidController(cubeModel, pooledProjectile));
        Spawn(pooledProjectile.gameObject);
    }

    private void Spawn(GameObject pooledProjectile)
    {
        if (pooledProjectile != null)
        {
            var rndPosX = Random.Range(-xRangePos, xRangePos);
            pooledProjectile.gameObject.SetActive(true);

            pooledProjectile.transform.position = new Vector3(rndPosX, transform.position.y + pooledProjectile.transform.localScale.y, transform.position.z);

        }
    }
}

