using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : GameOverMenu
{
    [SerializeField]
    private Button _resumeButton;

    private void Start()
    {
        _resumeButton.onClick.AddListener(OnResumeButtonClicked);
        gameObject.SetActive(false);
    }

    private void OnResumeButtonClicked()
    {
        PauseManager.Instance.SetPaused(false);
        gameObject.SetActive(false);
    }
}
