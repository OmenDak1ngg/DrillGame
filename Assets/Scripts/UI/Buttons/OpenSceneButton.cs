using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OpenSceneButton : UIButton
{
    [SerializeField] private GameScenes _sceneName;

    protected override void OnClick()
    {
        base.OnClick();
        LoadScene();
    }

    protected virtual void LoadScene()
    {
        SceneManager.LoadScene(_sceneName.ToString());
    }
}