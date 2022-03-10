using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip _pausedMenuClip;

    [SerializeField]
    private AudioClip[] _gameplayClips;

    [SerializeField]
    private AudioClip _explosion;

    [SerializeField]
    private AudioClip _buttonClicked;

    [SerializeField]
    private Button[] _buttons;

    [SerializeField]
    private Button _pauseButton;

    [SerializeField]
    private Button _soundButton;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        foreach(Button button in _buttons)
        {
            button.onClick.AddListener(PlayButtonClicked);
        }

        _pauseButton.onClick.AddListener(_audioSource.Pause);
        _soundButton.onClick.AddListener(ChangeMuted);

        _audioSource.mute = Convert.ToBoolean(PlayerPrefs.GetInt("Muted", 0));
    }

    private void SetAudioClip(AudioClip clip, bool isLooped)
    {
        _audioSource.loop = isLooped;
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void SetPausedMenuAudioClip()
    {
        SetAudioClip(_pausedMenuClip, true);
    }

    public void SetGameplayAudioClip()
    {
        SetAudioClip(_gameplayClips[UnityEngine.Random.Range(0, _gameplayClips.Length)], true);
    }

    public void PlayExplosion()
    {
        _audioSource.PlayOneShot(_explosion);
    }

    public void PlayButtonClicked()
    {
        _audioSource.PlayOneShot(_buttonClicked);
    }

    private void ChangeMuted()
    {
        _audioSource.mute = !_audioSource.mute;
        PlayerPrefs.SetInt("Muted", Convert.ToInt32(_audioSource.mute));
        SetPausedMenuAudioClip();
    }
}
