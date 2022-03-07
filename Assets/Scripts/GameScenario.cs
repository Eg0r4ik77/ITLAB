using System;
using UnityEngine;

public class GameScenario : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;

    [SerializeField]
    private UiController _uiController;

    [SerializeField]
    private AchievementManager _achievementManager;

    private void Awake()
    {     
        _playerController.OnDied += ShowGameOverMenu;
        _achievementManager.SetInitialAchievements();
        PauseManager.Instance.SetPaused(true);
    }

    void Start()
    {
        _uiController.SetMainMenu(true);
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
        PlayerPrefs.SetInt("BestScore", Math.Max(score, PlayerPrefs.GetInt("BestScore", 0)));
    }
}
