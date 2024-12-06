using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    private Health _health;

    private float hpChangeTime = 0.01f;
    private float _currentViewHealth;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _currentViewHealth = 100;
    }

    private void SetHealth(float health)
    {     
        _currentViewHealth = health;
        _healthBar.value = health;
    }

    private void TakeDamage(float currentHealth)
    {
        Debug.Log("taking damage");
        StartCoroutine(DecreaseHealthSmoothly(currentHealth));
    }

    private IEnumerator DecreaseHealthSmoothly(float target)
    {
        var wait = new WaitForSeconds(hpChangeTime);

        while (target < _currentViewHealth)
        {

            Debug.Log(_currentViewHealth);
            _currentViewHealth = (int)Mathf.Lerp(_currentViewHealth, target, 0.1f);
            _healthBar.value = _currentViewHealth;

            yield return wait;
        }
    }

    private void OnEnable()
    {
        _health.Damaged += TakeDamage;
        _health.HealthSetted += SetHealth;
    }

    private void OnDisable()
    {
        _health.Damaged -= TakeDamage;
        _health.HealthSetted -= SetHealth;
    }
}
