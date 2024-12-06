using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public event UnityAction PlayerRevived;
    public event UnityAction PlayerDead;

    [SerializeField] GameObject _revivePopUp;
    [SerializeField] Transform _camera;
    [SerializeField] DeathZone _deathZone;

    private Health _health;
    private PlayerMovement _movement;
    private PlayerController _controller;

    private bool _isDead = false;
    public bool IsDead => _isDead;

    private void Awake()
    {
        _revivePopUp.SetActive(false);
        _health = GetComponent<Health>();
        _movement = GetComponent<PlayerMovement>();
        _controller = GetComponent<PlayerController>();
    }
 
    private void OnEnable()
    {
        _deathZone.PlayerEntered += Death;
        _health.HPRunOut += Death;
    }

    private void OnDisable()
    {
        _deathZone.PlayerEntered -= Death;
        _health.HPRunOut -= Death;
    }

    private void Death()
    {
        _isDead = true;
        _movement.enabled = false;
        _revivePopUp.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;

        PlayerDead?.Invoke();
    }

    public void Revive()
    {
        _isDead = false;
        _movement.enabled = true;
        _movement.ResetRotationValues();
        _revivePopUp.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

        Vector3 revivePosition = Vector3.zero + transform.up;
        transform.position = revivePosition;

        PlayerRevived?.Invoke();
    }
}
