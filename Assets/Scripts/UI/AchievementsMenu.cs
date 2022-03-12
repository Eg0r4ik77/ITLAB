using UnityEngine;
using UnityEngine.UI;

public class AchievementsMenu : MonoBehaviour
{
    [SerializeField]
    private Button _backButton;

    [SerializeField]
    private AchievementManager _achievementManager;

    private void Awake()
    {
        gameObject.SetActive(false);
        _backButton.onClick.AddListener(OnBackButtonClicked);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _achievementManager.ShowAchievements();
    }

    public void OnBackButtonClicked()
    {
        gameObject.SetActive(false);
    }
}
