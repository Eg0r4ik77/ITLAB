using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;

    [SerializeField]
    private GameOverMenu _gameOverMenu;

    [SerializeField]
    private PauseMenu _pauseMenu;

    [SerializeField]
    private MainMenu _mainMenu;

    [SerializeField]
    private GamePlayScreen _gamePlayScreen;

    public bool IsMainMenuEnabled => _mainMenu.IsEnabled;

    private void Awake()
    {
        _gamePlayScreen.OnPauseButtonClicked += ShowPauseMenu;
    }

    private void Update()
    {
        if (_gamePlayScreen.enabled)
        {
            _gamePlayScreen.SetScoreText(_playerController.Score);
        }
    }

    private void OnDestroy()
    {
        _gamePlayScreen.OnPauseButtonClicked -= ShowPauseMenu;
    }

    public void SetMainMenu(bool isEnable)
    {
        _mainMenu.gameObject.SetActive(isEnable);
    }

    public void SetGameOverMenu()
    {
         PauseManager.Instance.SetPaused(true);
        //_gamePlayScreen.gameObject.SetActive(false);
        _gameOverMenu.Show(_playerController.Score);
    }

    private void ShowPauseMenu()
    {
        PauseManager.Instance.SetPaused(true);
        _pauseMenu.Show(_playerController.Score);
    }

    public void SetGamePlayScreen(bool isEnable)
    {
        if (isEnable == true)
        {
            _gamePlayScreen.Show();
        }
        else
        {
            _gamePlayScreen.gameObject.SetActive(false);
        }
    }
}
