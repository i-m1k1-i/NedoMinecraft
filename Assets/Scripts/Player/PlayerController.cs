using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public event UnityAction PlayerRevived;

    [SerializeField] GameObject _revivePopUp;
    [SerializeField] Transform _camera;
    [SerializeField] DeathZone _deathZone;

    private Health _health;
    private PlayerMovement _movement;

    private bool _isDead = false;
    public bool IsDead => _isDead;

    private void Awake()
    {
        _revivePopUp.SetActive(false);
        _health = GetComponent<Health>();
        _movement = GetComponent<PlayerMovement>();
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
        _movement.enabled = false;

        Cursor.lockState = CursorLockMode.Confined;

        _revivePopUp.SetActive(true);

        _isDead = true;
    }

    public void Revive()
    {
        Vector3 revivePosition = Vector3.zero + transform.up;
        transform.position = revivePosition;
        _movement.enabled = true;
        _movement.SetRotationToStartValues();

        Cursor.lockState = CursorLockMode.Locked;
        _revivePopUp.SetActive(false);

        _isDead = false;

        PlayerRevived?.Invoke();
    }
}
