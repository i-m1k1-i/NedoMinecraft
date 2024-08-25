using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public event UnityAction<GameObject> CurrentBlockChanged;

    [SerializeField] private GameObject[] _blockPrefabs;

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
        _currentBlockIndex = Mathf.Abs(_currentBlockIndex - 1);
        CurrentBlockChanged?.Invoke(_blockPrefabs[_currentBlockIndex]);
    }

    public GameObject GetCurrentBlock()
    {
        return _blockPrefabs[_currentBlockIndex];
    }
}
