using UnityEngine;
using UnityEngine.UI;

public class EndLevelButton : MonoBehaviour
{
    [SerializeField] private Canvas _endLevelScreen;

    [SerializeField] private Button _button;
    [SerializeField] private LevelCompletionHandler _levelhandler;

    [SerializeField] private Color32 _activeColor;
    [SerializeField] private Color32 _inactiveColor;

    private Image _image;

    private void OnEnable()
    {
        _levelhandler.ReachedAnyGoal += SetActive;
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _levelhandler.ReachedAnyGoal -= SetActive;
        _button.onClick.RemoveListener(OnClick);
    }

    private void Awake()
    {
        _image = _button.GetComponent<Image>();
        _image.color = _inactiveColor;
        _button.interactable = false;
    }

    private void OnClick()
    {
        _endLevelScreen.gameObject.SetActive(true);
    }

    private void SetActive()
    {
        _image.color = _activeColor;
        _button.interactable = true;
    }
}