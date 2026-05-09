using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButton : MenuButton
{
    private readonly string _mapSceneName = "MapScene";

    protected override void OnClick()
    {
        SceneManager.LoadScene(_mapSceneName);
    }

}