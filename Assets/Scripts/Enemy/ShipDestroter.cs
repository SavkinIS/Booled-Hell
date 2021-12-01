using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDestroter : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ShipView ship))
        {
            ship.TakeDamage = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ShipView ship))
        {
            ship.TakeDamage = true;
        }
    }
}
