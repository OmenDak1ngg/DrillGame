using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public event Action<float> VolumeChanged;

    public Slider Slider => _slider;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(OnValueChanged);
    }

    private void OnValueChanged(float volume)
    {
        VolumeChanged?.Invoke(volume);  
    }
}
