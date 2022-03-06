using System;
using UnityEngine;

public class GameScenario : MonoBehaviour
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

        _playerController.OnDied += ShowGameOverMenu;
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
            _uiController.SetGamePlayScreen(true);
            PauseManager.Instance.SetPaused(false);
        }   
    }

    private void OnDestroy()
    {
        _playerController.OnDied -= ShowGameOverMenu;
    }

    private void ShowGameOverMenu(int score)
    {
        TryUpdateBestScore(score);
        _uiController.SetGameOverMenu(true);
    }

    private void TryUpdateBestScore(int score)
    {
        PlayerPrefs.SetInt("BestScore", Math.Max(score, PlayerPrefs.GetInt("BestScore")));
    }
}
