using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuBottomButton : UIButton
{
    [SerializeField] private RectTransform _panel;

    public event Action<MenuBottomButton> ClickedOnPanel;

    public void ActivePanel()
    {
        _panel.gameObject.SetActive(true);
    }

    public void DeactivePanel()
    {
        _panel.gameObject.SetActive(false);
    }

    protected override void OnClick()
    {
        ClickedOnPanel?.Invoke(this);
    }
}