using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField]
    private TMP_Text _bestScoreText;

    [SerializeField]
    private Button _restartButton;

    private void Awake()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show(int score)
    {
        _scoreText.SetText($"Score:\n{score}");
        _bestScoreText.SetText($"Best score:\n{PlayerPrefs.GetInt("BestScore")}");
    }

    private void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
}
