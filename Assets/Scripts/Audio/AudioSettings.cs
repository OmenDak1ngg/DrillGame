using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    private readonly string _soundVolumeParameter = "SoundsVolume";
    private readonly string _musicVolumeParameter = "MusicVolume";

    [SerializeField] private AudioMixer _mixer;

    [SerializeField] private VolumeSlider _soundsSlider;
    [SerializeField] private VolumeSlider _musicSlider;

    [SerializeField] private Toggle _soundToggle;
    [SerializeField] private Toggle _musicToggle;

    private float _lastMusicVolume;
    private float _lastSoundVolume;

    private void OnEnable()
    {
        _soundsSlider.VolumeChanged += SetSoundsVolume;
        _musicSlider.VolumeChanged += SetMusicVolume;
        _soundToggle.onValueChanged.AddListener(ToggleSound);
        _musicToggle.onValueChanged.AddListener(ToggleMusic);
    }

    private void OnDisable()
    {
        _soundsSlider.VolumeChanged -= SetSoundsVolume;
        _musicSlider.VolumeChanged -= SetMusicVolume;
        _soundToggle.onValueChanged.RemoveListener(ToggleSound);
        _musicToggle.onValueChanged.RemoveListener(ToggleMusic);
    }

    private void Start()
    {
        _mixer.GetFloat(_soundVolumeParameter, out float soundVolume);
        _mixer.GetFloat(_musicVolumeParameter, out float musicVolume);

        _soundsSlider.Slider.value = Mathf.Pow(10, soundVolume / 20);
        _musicSlider.Slider.value = Mathf.Pow(10, musicVolume / 20);

        _lastSoundVolume = _soundsSlider.Slider.value;
        _lastMusicVolume = _musicSlider.Slider.value;
    }


    private void ToggleMusic(bool isOn)
    {
        float volume = isOn ? _lastMusicVolume : 0;

        SetVolume(_musicVolumeParameter, ref volume);
    }

    private void ToggleSound(bool isOn)
    {
        float volume = isOn ? _lastSoundVolume : 0;

        SetVolume(_soundVolumeParameter, ref volume);
    }

    private void SetSoundsVolume(float volume)
    {
        _lastSoundVolume = volume;
        SetVolume(_soundVolumeParameter, ref volume);
    }

    private void SetMusicVolume(float volume)
    {
        _lastMusicVolume = volume;
        SetVolume(_musicVolumeParameter, ref volume);
    }

    private void SetVolume(string parameter, ref float volume)
    {
        volume = Mathf.Clamp(volume, 0.00001f, 1f);
        volume = Mathf.Log10(volume) * 20;

        _mixer.SetFloat(parameter, volume);
    }
}
