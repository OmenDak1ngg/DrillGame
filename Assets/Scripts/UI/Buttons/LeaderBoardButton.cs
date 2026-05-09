using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardButton : MenuButton
{
    [SerializeField] private Image _leaderboard;

    protected override void OnClick()
    {
        _leaderboard.gameObject.SetActive(true);
    }
}