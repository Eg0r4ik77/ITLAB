using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _bestScoreText;

    [SerializeField]
    private Button _toAchievementsMenuButton;

    [SerializeField]
    private Button _keyboardConfigurationButton;

    [SerializeField]
    private AchievementsMenu _achievementsMenu;

    [SerializeField]
    private KeyboardConfiguration _keyboardConfiguration;

    private void Awake()
    {
        _bestScoreText.SetText($"Best score\n{PlayerPrefs.GetInt("BestScore")}");
    }

    private void Start()
    {
        _toAchievementsMenuButton.onClick.AddListener(ShowAchievementsMenu);
        _keyboardConfigurationButton.onClick.AddListener(ShowKeyboardConfiguration);
    }

    private void ShowAchievementsMenu()
    {
        _achievementsMenu.Show();
    }

    private void ShowKeyboardConfiguration()
    {
        _keyboardConfiguration.Show();
    }
}
