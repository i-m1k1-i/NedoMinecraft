using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Health : MonoBehaviour
{
    public event UnityAction<float> Damaged;
    public event UnityAction<float> HealthSetted;
    public event UnityAction HPRunOut;

    [SerializeField] private int _maxHealth = 100;

    private PlayerController _playerController;

    private int _currentHealth;
    public int CurrentHealth { get; }
    public int MaxHealth { get; }

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _playerController = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        _playerController.PlayerRevived += SetFullHP;
    }

    private void OnDisable()
    {
        _playerController.PlayerRevived -= SetFullHP;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        Damaged?.Invoke(_currentHealth);

        if (_currentHealth == 0)
        {
            HPRunOut?.Invoke();
        }
    }

    private void SetHealth(int health)
    {
        _currentHealth = health;
        HealthSetted?.Invoke(_maxHealth);
    }

    private void SetFullHP()
    {
        SetHealth(_maxHealth);
    }
}
