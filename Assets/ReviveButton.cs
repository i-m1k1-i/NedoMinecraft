using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ReviveButton : MonoBehaviour
{
    private Button _button;

    public static event UnityAction OnClick;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(InvokeClick);
    }

    private void InvokeClick()
    {
        OnClick?.Invoke();
        _button.onClick.RemoveAllListeners();
    }
}
