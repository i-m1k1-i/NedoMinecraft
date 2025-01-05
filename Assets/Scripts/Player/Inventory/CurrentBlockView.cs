using UnityEngine;

public class CurrentBlockView : MonoBehaviour
{
    [SerializeField] Transform _renderCamera;

    private Inventory _inventory;
    private Block _block;
    private Vector3 _position = new (0f, 0f, 1f);
    private Vector3 _scale = new (1f, 1f, 1f);

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
    }

    private void Start()
    {
        Block block = _inventory.GetCurrentBlock();
        SetBlock(block);
    }

    private void SetBlock(Block block)
    {
        Debug.Log(block);
        _block = Instantiate(block, _renderCamera);
        _block.transform.localPosition = _position;
        _block.transform.localScale = _scale;
    }

    private void ChangeBlock(Block block)
    {
        _block.Destroy();
        SetBlock(block);
    }

    private void OnEnable()
    {
        _inventory.CurrentBlockChanged += ChangeBlock;
    }

    private void OnDisable()
    {
        _inventory.CurrentBlockChanged -= ChangeBlock;
    }
}
