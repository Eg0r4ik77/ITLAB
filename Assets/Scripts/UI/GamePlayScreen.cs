using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GamePlayScreen : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField]
    private Button _pauseButton;

    public event UnityAction OnPauseButtonClicked;

    private void Start()
    { 
        _pauseButton.onClick.AddListener(OnPauseButtonClicked);
        gameObject.SetActive(false);
    }

    public void SetScoreText(int score)
    {
        _scoreText.SetText(score.ToString());
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
