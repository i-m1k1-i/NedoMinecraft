using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private readonly string Vertical = nameof(Vertical);
    private readonly string Horizontal = nameof(Horizontal);
    private readonly string MouseX = nameof(MouseX);
    private readonly string MouseY = nameof(MouseY);
    private readonly string Jump = nameof(Jump);

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private Transform _camera;
    [SerializeField] private GroundChecker _foots;

    private Rigidbody _rigidbody;
    private float _rotationAroundX;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleMove();
        HandleRotate();
        HandleJump();
    }

    private void HandleMove()
    {
        float verticalInput = Input.GetAxisRaw(Vertical);
        float horizontalInput = Input.GetAxisRaw(Horizontal);

        Vector3 direction = (verticalInput * transform.forward) + (horizontalInput * transform.right);
        direction.Normalize();

        Vector3 move = _moveSpeed * Time.deltaTime * direction;

        transform.position += move;
    }

    private void HandleRotate()
    {
        float mouseXInput = Input.GetAxis(MouseX);
        float mouseYInput = Input.GetAxis(MouseY);

        // rotate y
        Vector3 rotationAroundY = mouseXInput * _rotateSpeed * Time.deltaTime * transform.up;
        transform.Rotate(rotationAroundY);
        _rigidbody.angularVelocity = Vector3.zero;

        // rotate x
        _rotationAroundX -= mouseYInput * _rotateSpeed * Time.deltaTime;
        _rotationAroundX = Mathf.Clamp(_rotationAroundX, -90f, 90f);
        Quaternion targetRotation = Quaternion.Euler(_rotationAroundX, 0f, 0f);
        _camera.localRotation = targetRotation;
    }

    private void HandleJump()
    {
        Vector3 jumpForce = new(0f, _jumpPower, 0f);
        if (_foots.IsGrounded && Input.GetButtonDown(Jump))
        {
            _rigidbody.AddForce(jumpForce, ForceMode.Impulse);
        }
    }

    public void SetRotationToStartValues()
    {
        _rotationAroundX = 0f;
        transform.Rotate(Vector3.zero);
    }
}
