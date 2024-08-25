using UnityEngine;
using UnityEngine.Events;

public class DeathZone : MonoBehaviour
{
    [SerializeField] PlayerController _player;
    [SerializeField, Range(-500, -20)] float _deathZoneStart;

    public event UnityAction PlayerEntered;

    private void Update()
    {
        if (_player.transform.position.y < _deathZoneStart && _player.IsDead == false)
        {
            PlayerEntered?.Invoke();
        }
    }
}
