using System;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;

    [SerializeField]
    private UiController _uiController;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("BestScore") == false)
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }

        _playerController.OnDied += ShowPauseMenu;
    }

    void Start()
    {
        _uiController.SetMainMenu(true);
        PauseManager.Instance.SetPaused(true);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _uiController.SetMainMenu(false);
            PauseManager.Instance.SetPaused(false);
        }   
    }

    private void OnDestroy()
    {
        _playerController.OnDied -= ShowPauseMenu;
    }

    private void ShowPauseMenu(int score)
    {
        PauseManager.Instance.SetPaused(true);
        TryUpdateBestScore(score);
        _uiController.SetPauseMenu(true);
    }

    private void TryUpdateBestScore(int score)
    {
        PlayerPrefs.SetInt("BestScore", Math.Max(score, PlayerPrefs.GetInt("BestScore")));
    }
}
