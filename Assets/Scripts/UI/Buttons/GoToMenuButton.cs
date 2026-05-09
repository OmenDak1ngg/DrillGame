using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToMenuButton : MenuButton
{
    private readonly string _mainMenuName = "MainMenu";

    protected override void OnClick()
    {
        SceneManager.LoadScene(_mainMenuName);
    }
}