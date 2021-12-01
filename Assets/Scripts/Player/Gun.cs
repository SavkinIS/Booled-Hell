using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObjectPool shootPool;
    [SerializeField] Bullet bullet;
    [SerializeField] int amountbullet;
    void Start()
    {
        shootPool.InitPool(bullet.gameObject, amountbullet);
        Observable.EveryUpdate().Select(_ => Input.GetButtonDown("Fire1")).RepeatUntilDestroy(this).Subscribe(s=> { if (s) Shoot(); });
    }

    void Shoot()
    {
        if (transform.parent.gameObject.activeInHierarchy)
        {
            GameObject pooledProjectile = shootPool.GetPooledObject();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true);
                pooledProjectile.transform.position = transform.position;
                pooledProjectile.transform.parent = null;
            }
        }
    }



}
