using Assets.Scripts.Controller;
using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class AsteroidManagerView : MonoBehaviour
{    
    [SerializeField] GameObjectPool asteroidPool;
    [SerializeField] AsteroidView asteroidView;

    /// <summary>
    /// range of positions by X
    /// </summary>
    float xRangePos;
    /// <summary>
    /// Maxrange of positions by Z
    /// </summary>
    float maxRangeZ;
    float speedZAster;    
    float asteroidSpanPeriod;
    int asteroidAmount;

    List<AsteroidController> asteroidControllers;
    AsteroidModel asteroidModel;
    

   

    public int AsteroidAmount { get => asteroidAmount; set => asteroidAmount = value; }
    // Start is called before the first frame update
    void Start()
    {
        #region Asteroid        
        asteroidControllers = new List<AsteroidController>();
        asteroidModel = new AsteroidModel(speedZAster);
        asteroidPool.InitPool(asteroidView.gameObject, asteroidAmount);
        #endregion

        Observable.Interval(System.TimeSpan.FromSeconds(Random.Range(0.7f, asteroidSpanPeriod))).RepeatUntilDestroy(this)
            .Subscribe(_ => SpawnAsteroids());
    }


    void SpawnAsteroids()
    {
        AsteroidView pooledProjectile = asteroidPool.GetPooledObject().GetComponent<AsteroidView>();
        pooledProjectile.MaxRangeZ = maxRangeZ;
        asteroidControllers.Add(new AsteroidController(asteroidModel, pooledProjectile));
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

    public void Init(float maxRangeZ, 
        float speedZAster, 
        float xRangePos, 
        float asteroidSpanPeriod,
        int asteroidAmount)
    {
        this.maxRangeZ = maxRangeZ;
        this.speedZAster = speedZAster;
        this.xRangePos = xRangePos;
        this.asteroidSpanPeriod = asteroidSpanPeriod;
        this.asteroidAmount = asteroidAmount;
    }
}
