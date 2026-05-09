using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MenuButton
{
    [SerializeField] private Image _settingsMenu;

    protected override void OnClick()
    {
        _settingsMenu.gameObject.SetActive(true);
    }
}