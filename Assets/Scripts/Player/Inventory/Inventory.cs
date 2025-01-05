using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public event UnityAction<Block> CurrentBlockChanged;

    [SerializeField] private Block[] _blocks;

    const string MouseWheelAxis = "Mouse ScrollWheel";

    private int _currentBlockIndex = 0;

    private void Update()
    {
        if (Input.GetAxis(MouseWheelAxis) != 0)
        {
            ChangeCurrentBlock();
        }
    }

    private void ChangeCurrentBlock()
    {
        int lastBlockIndex = _blocks.Length - 1;
        _currentBlockIndex++;
        if (_currentBlockIndex > lastBlockIndex)
        {
            _currentBlockIndex = 0;
        }
        CurrentBlockChanged?.Invoke(_blocks[_currentBlockIndex]);
    }

    public Block GetCurrentBlock()
    {
        return _blocks[_currentBlockIndex];
    }
}
