using UnityEngine;
using UnityEngine.UI;

public class ExitButton : UIButton
{
    [SerializeField] private Image _closableImage;

    protected override void OnClick()
    {
        _closableImage.gameObject.SetActive(false);
    }
}