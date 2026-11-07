
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class UIButton : MonoBehaviour
{
    private Button _button;

    public event Action Clicked;

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

    protected virtual void OnClick()
    {
        Clicked?.Invoke();
    }
}
