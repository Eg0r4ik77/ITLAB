using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField]
    private TMP_Text _bestScoreText;

    [SerializeField]
    private Button _toMenuButton;

    private void Awake()
    {
        _toMenuButton.onClick.AddListener(OnToMenuButtonClicked);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show(int score)
    {
        gameObject.SetActive(true);
        _scoreText.SetText($"Score:\n{score}");
        _bestScoreText.SetText($"Best score:\n{PlayerPrefs.GetInt("BestScore", 0)}");
    }

    private void OnToMenuButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
}
