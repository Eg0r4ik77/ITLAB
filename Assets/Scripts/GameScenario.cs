using System;
using System.Threading.Tasks;
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

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private GameObject _explosion;

    private GameComplicator _gameComplicator;

    private bool isGameStarted;

    private void Awake()
    {     
        _playerController.OnDied += EndGame;
        _playerController.OnDied += TryUpdateBestScore;

        _achievementManager.SetInitialAchievements();
        _gameComplicator = new GameComplicator(_playerCarMovement.Speed, _carPool.GetCarsAheadSpeed(), _carPool.CarsCooldownLeftBound, _carPool.CarsCooldownRightBound);


        ExitGameButton.OnExitButtonClicked += ExitGame;
        PauseManager.Instance.SetPaused(true);
    }

    void Start()
    {
        _uiController.SetMainMenu(true);
        _audioManager.SetPausedMenuAudioClip();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isGameStarted == false && _uiController.IsMainMenuEnabled == true)
        {   
            isGameStarted = true;

            _uiController.SetMainMenu(false);
            _uiController.SetGamePlayScreen(true);

            _audioManager.SetGameplayAudioClip();
          
            PauseManager.Instance.SetPaused(false);
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

    private async void EndGame(int score)
    {
        _audioManager.PlayExplosion();
        _audioManager.SetPausedMenuAudioClip();
        _playerController.gameObject.SetActive(false);

        Instantiate(_explosion, _playerController.transform.position, Quaternion.identity);
        await Task.Delay(500);

        _animator.SetTrigger("isGameOver");
        _uiController.SetGameOverMenu();
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
