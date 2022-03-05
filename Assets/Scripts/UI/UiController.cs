using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;

    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField]
    private PauseMenu _pauseMenu;

    [SerializeField]
    private MainMenu _mainMenu;

    private void Update()
    {
        SetScoreText(_playerController.Score);
    }

    private void SetScoreText(int score)
    {
        _scoreText.SetText(score.ToString());
    }

    public void SetMainMenu(bool isEnable)
    {
        _mainMenu.gameObject.SetActive(isEnable);
    }

    public void SetPauseMenu(bool isEnable)
    {
        _pauseMenu.gameObject.SetActive(isEnable);
        if (isEnable == true)
        {
            _pauseMenu.Show(_playerController.Score);
        }
    }
}
