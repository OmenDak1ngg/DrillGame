using UnityEngine;
using UnityEngine.UI;

public class ScoreStar : MonoBehaviour
{
    [SerializeField] private Vector3 _inactiveColor = new Vector3(80,80,80);
    [SerializeField] private Vector3 _activeColor = new Vector3(255,255,255); 
    
    private Image _image;

    public RectTransform RectTransform { get; private set; }

    private void Awake()
    {
        _image = GetComponent<Image>();
        RectTransform = GetComponent<RectTransform>();
        SetColor(_inactiveColor);
    }

    public void SetActive()
    {
        SetColor(_activeColor);
    }

    private void SetColor(Vector3 color)
    {
        _image.color = new Color(color.x, color.y, color.z);
    }
}