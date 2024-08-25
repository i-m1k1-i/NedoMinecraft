using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] private GameObject _grenadePrefab;
    [SerializeField] private float _throwForce;
    [SerializeField] private Transform _camera;

    private readonly KeyCode _throwKeyCode = KeyCode.F;

    private Grenade _currentGrenade;

    private void Update()
    {
        if (Input.GetKeyDown(_throwKeyCode))
        {
            Vector3 grenadePosition = _camera.transform.position + _camera.forward;
            GameObject grenadeObject = Instantiate(_grenadePrefab, grenadePosition, Quaternion.identity, transform);

            _currentGrenade = grenadeObject.GetComponent<Grenade>();
            _currentGrenade.PullOutPin();
            _currentGrenade.SetInHand(true);
        }

        else if (Input.GetKeyUp(_throwKeyCode))
        {
            _currentGrenade.transform.parent = null;

            Vector3 throwDirection = _camera.forward;
            print(throwDirection);
            _currentGrenade.SetInHand(false);
            _currentGrenade.Throw(throwDirection * _throwForce);
        }
    }
}
