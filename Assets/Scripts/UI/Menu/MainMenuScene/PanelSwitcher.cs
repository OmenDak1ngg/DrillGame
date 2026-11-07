using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] private MenuBottomButton[] _bottomButtons;

    private void OnEnable()
    {
        foreach (var button in _bottomButtons)
        {
            button.ClickedOnPanel += OnPanelClicked;
        }
    }

    private void OnDisable()
    {
        foreach (var button in _bottomButtons)
        {
            button.ClickedOnPanel -= OnPanelClicked;
        }

    }

    private void OnPanelClicked(MenuBottomButton clickedButton)
    {
        foreach (var button in _bottomButtons)
        {
            if (button == clickedButton)
                button.ActivePanel();
            else
                button.DeactivePanel();
        }
    }
}
