using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    public bool destroyed;

    internal  void Move(float speedZ)
    {
        transform.Translate(Vector3.back * speedZ * Time.deltaTime);
    }


    public void DisableGO()
    {
        gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out BulletPlayer bullet))
        {
            bullet.DisableGO();
            //enemyshoot.gameobject.setactive(false);
            destroyed = true;
            gameObject.SetActive(false);
            //gameobjectpool.removego(gameobject);
        }
    }
}
