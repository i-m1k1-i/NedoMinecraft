using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Canvas _deathCanvas;
    [SerializeField] private Transform _camera;
    [SerializeField] private DeathZone _deathZone;

    private Health _health;
    private PlayerMovement _movement;
    private PlayerController _controller;
    private Vector3 _revivePosition;

    private bool _isDead = false;
    public bool IsDead => _isDead;

    public event UnityAction PlayerRevived;
    public event UnityAction PlayerDead;

    private void Awake()
    {
        _deathCanvas.gameObject.SetActive(false);
        _health = GetComponent<Health>();
        _movement = GetComponent<PlayerMovement>();
        _controller = GetComponent<PlayerController>();
        _revivePosition = Vector3.up;
    }

    public void SetRevivePosition(Vector3 position)
    {
        _revivePosition = position;
    }

    private void Death()
    {
        _isDead = true;
        _movement.enabled = false;
        _deathCanvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;

        PlayerDead?.Invoke();
    }

    private void Revive()
    {
        _isDead = false;
        _movement.enabled = true;
        _movement.ResetRotationValues();
        _deathCanvas.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

        transform.position = _revivePosition;

        PlayerRevived?.Invoke();
    }

    private void OnEnable()
    {
        _deathZone.PlayerEntered += Death;
        _health.HPRanOut += Death;
        ReviveButton.OnClick += Revive;
    }

    private void OnDisable()
    {
        _deathZone.PlayerEntered -= Death;
        _health.HPRanOut -= Death;
        ReviveButton.OnClick -= Revive;
    }
}
