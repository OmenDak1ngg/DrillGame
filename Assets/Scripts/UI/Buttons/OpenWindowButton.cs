using UnityEngine;
using UnityEngine.UI;

public class OpenWindowButton : UIButton
{
    [SerializeField] private RectTransform _window;

    protected override void OnClick()
    {
        _window.gameObject.SetActive(true);
    }
}
