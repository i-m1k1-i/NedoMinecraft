using System.Collections;
using TMPro;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _healthText;

    private Health _health;

    private float hpChangeTime = 0.01f;
    private float _currentViewHealth;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _currentViewHealth = 100;
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

    private void SetHealth(float health)
    {     
        _currentViewHealth = health;
        _healthText.text = health.ToString();
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
            _healthText.text = _currentViewHealth.ToString();

            yield return wait;
        }
    }
}
