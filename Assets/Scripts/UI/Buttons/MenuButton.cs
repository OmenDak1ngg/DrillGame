
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class MenuButton : MonoBehaviour
{
    private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    protected abstract void OnClick();
}
