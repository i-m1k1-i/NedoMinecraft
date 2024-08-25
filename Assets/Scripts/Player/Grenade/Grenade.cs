using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Grenade : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionDelay = 2;
    [SerializeField] private ParticleSystem _explosionEffect;

    private Rigidbody _rigidbody;
    private Collider _collider;
    
    private bool isActivated = false;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_explosionDelay <= 0)
        {
            Explode();
        }
        else if (isActivated) 
        {
            _explosionDelay -= Time.deltaTime;
        }
    }

    public void Throw(Vector3 force)
    {
        _rigidbody.AddForce(force, ForceMode.Impulse);
    }

    private void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        Block block;
        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent<Block>(out block))
            {
                block.Destroy();
            }
        }
        Instantiate(_explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void SetInHand(bool isInHand)
    {
        _collider.isTrigger = isInHand;
        _rigidbody.isKinematic = isInHand;
    }

    public void PullOutPin()
    {
        isActivated = true;
    }
}
