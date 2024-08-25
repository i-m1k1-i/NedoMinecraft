using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private float _maxDistance;
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private BuildPreview _buildPreview;
    [SerializeField] private Inventory _inventory;

    private GameObject _blockPrefab;
    private RaycastHit _hitInfo;
    private Vector3 BuildPosition => _hitInfo.transform.position + _hitInfo.normal;
    private bool _previewEnabled = true, _canBuild;

    private PlayerController _controller;

    private void Start()
    {
        _blockPrefab = _inventory.GetCurrentBlock();
        _controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (_canBuild == false)
        {
            return;
        }

        if (_hitInfo.transform == null || _hitInfo.transform.GetComponent<Block>() == null)
        {
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Build();
        }

        if (Input.GetMouseButtonDown(0))
        {
            DestroyBlock();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SwitchPreviewEnabled();
        }

    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(_raycastPoint.position, _raycastPoint.forward, out _hitInfo, _maxDistance) && _previewEnabled)
        {
            if (_buildPreview.Enabled == false)
            {
                _buildPreview.Enable();
            }
            _buildPreview.SetPosition(BuildPosition);
        }
        else if (_buildPreview.Enabled)
        {
            _buildPreview.Disable();
        }
    }

    private void Build()
    {
        Instantiate(_blockPrefab, BuildPosition, Quaternion.identity);
    }

    private void DestroyBlock()
    {
        Block block = _hitInfo.transform.GetComponent<Block>();
        block.Destroy();
    }

    private void SwitchPreviewEnabled()
    {
        if (_previewEnabled)
        {
            _previewEnabled = false;
        }
        else
        {
            _previewEnabled = true;
        }
    }

    private void SetCurrentBlock(GameObject blockPrefab)
    {
        _blockPrefab = blockPrefab;
    }

    private void SwitchCanBuild()
    {
        _canBuild = !_canBuild;
    }

    private void OnEnable()
    {
        _inventory.CurrentBlockChanged += SetCurrentBlock;
        _controller.PlayerDead += SwitchCanBuild;
    }

    private void OnDisable()
    {
        _inventory.CurrentBlockChanged -= SetCurrentBlock;
        _controller.PlayerDead -= SwitchCanBuild;
    }
}
