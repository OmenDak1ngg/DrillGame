using UnityEngine.SceneManagement;

public class PlayButton : MenuButton
{
    private readonly string _gameSceneName = "GameScene";

    protected override void OnClick()
    {
        SceneManager.LoadScene(_gameSceneName);
    }
}
