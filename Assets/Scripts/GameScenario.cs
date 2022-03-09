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

    [SerializeField]
    private CarPool _carPool;

    [SerializeField]
    private PlayerCarMovement _playerCarMovement;

    [SerializeField]
    private AudioManager _audioManager;

    private GameComplicator _gameComplicator;

    private bool isGameStarted;

    private void Awake()
    {     
        _playerController.OnDied += EndGame;
        _playerController.OnDied += TryUpdateBestScore;

        ExitGameButton.OnExitButtonClicked += ExitGame;

        _achievementManager.SetInitialAchievements();

        PauseManager.Instance.SetPaused(true);
    }

    void Start()
    {
        _uiController.SetMainMenu(true);
        _audioManager.SetPausedMenuAudioClip();
        _gameComplicator = new GameComplicator(_playerCarMovement.Speed, _carPool.GetCarsAheadSpeed(), _carPool.CarsCooldownLeftBound, _carPool.CarsCooldownRightBound);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isGameStarted == false)
        {
            isGameStarted = true;
            _uiController.SetMainMenu(false);
            _uiController.SetGamePlayScreen(true);
            PauseManager.Instance.SetPaused(false);
            _audioManager.SetGameplayAudioClip();
        }   

        if(isGameStarted == true)
        {
            TryComplicateGame();
        }
    }

    private void OnDestroy()
    {
        _playerController.OnDied -= EndGame;
        _playerController.OnDied -= TryUpdateBestScore;

        ExitGameButton.OnExitButtonClicked -= ExitGame;
    }

    private void EndGame(int score)
    {
        _audioManager.PlayExplosion();
        _audioManager.SetPausedMenuAudioClip();

        _uiController.SetGameOverMenu(true);
    }

    private void TryUpdateBestScore(int score)
    {
        int bestScore = Math.Max(score, PlayerPrefs.GetInt("BestScore", 0));
        PlayerPrefs.SetInt("BestScore", bestScore);
        _achievementManager.UpdateAchievementsSprites(bestScore);
    }

    private void TryComplicateGame()
    {
        if(_gameComplicator.DifficultyLevel < _gameComplicator._complicationPoints.Length && _playerController.Score >= _gameComplicator._complicationPoints[_gameComplicator.DifficultyLevel])
        {
            _gameComplicator.DifficultyLevel++;

            _playerCarMovement.Speed = _gameComplicator.GetComplicatedSpeed();
            _carPool.SetCarsAheadSpeed(_gameComplicator.GetComplicatedCarsAheadSpeed());
            _carPool.CarsCooldownLeftBound = _gameComplicator.GetComplicatedCarsCooldownLeftBound();
            _carPool.CarsCooldownRightBound = _gameComplicator.GetComplicatedCarsCooldownRightBound();
        }
    }

    private void ExitGame()
    {   
        TryUpdateBestScore(_playerController.Score);
        Application.Quit();
    }
}
