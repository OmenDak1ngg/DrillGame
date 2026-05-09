using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MenuButton
{
    [SerializeField] private Image _closableImage;

    protected override void OnClick()
    {
        _closableImage.gameObject.SetActive(false);
    }
}