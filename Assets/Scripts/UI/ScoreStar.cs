using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class ScoreStar : MonoBehaviour
{
    [SerializeField] private Color32 _inactiveColor = new Color32(80,80,80,255);
    [SerializeField] private Color32 _activeColor = new Color32(255,255,255, 255); 
    
    private Image _image;

    public RectTransform RectTransform { get; private set; }

    private void Awake()
    {
        _image = GetComponent<Image>();
        RectTransform = GetComponent<RectTransform>();
        _image.color = _inactiveColor;
    }

    public void SetActive()
    {
        _image.color = _activeColor;
    }
}