using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObjectPool shootPool;
    [SerializeField] Bullet bullet;
    [SerializeField] int amountbullet;

    GameManager gameManager;
    float shootRate;

    public float ShootRate { get => shootRate; set => shootRate = value; }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        shootPool.InitPool(bullet.gameObject, amountbullet);
        Observable.Interval(System.TimeSpan.FromSeconds(shootRate)).RepeatUntilDestroy(this)
            .Subscribe(_ => Shoot());

    void Shoot()
    {
        if (!transform.parent.gameObject.activeSelf)return;
        GameObject pooledProjectile = shootPool.GetPooledObject();
        if (pooledProjectile != null&& gameManager.isPlaying)
        {
            pooledProjectile.SetActive(true);
            pooledProjectile.transform.position = transform.position;
                pooledProjectile.transform.parent = null;
        }
    }
}
}
