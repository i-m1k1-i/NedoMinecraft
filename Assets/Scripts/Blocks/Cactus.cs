using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Cactus : MonoBehaviour
{
    [SerializeField, Range(1, 100)] private int _damage = 10;
    [SerializeField] private float _damageDelay = 0.5f;

    private float _elapsedTime;

    private void Start()
    {
        Collider collider = GetComponent<Collider>();
        collider.isTrigger = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(_damage);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.TryGetComponent<Health>(out Health health))
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _damageDelay)
            { 
                health.TakeDamage(_damage);
                _elapsedTime = 0f;
            }
        }
    }
}
