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
    private AchievementsMenu _achievementsMenu;

    private void Awake()
    {
        _bestScoreText.SetText($"Best score\n{PlayerPrefs.GetInt("BestScore")}");
    }

    private void Start()
    {
        _toAchievementsMenuButton.onClick.AddListener(ShowAchievementsMenu);
    }

    private void ShowAchievementsMenu()
    {
        _achievementsMenu.Show();
    }
}
