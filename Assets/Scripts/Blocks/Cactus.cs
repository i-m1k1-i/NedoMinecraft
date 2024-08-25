using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Cactus : MonoBehaviour
{
    private int _damage = 10;

    private void Start()
    {
        Collider collider = GetComponent<Collider>();
        collider.isTrigger = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Touched");
        if (collision.transform.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(_damage);
        }
    }
}
