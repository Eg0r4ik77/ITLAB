using UnityEngine;
using UnityEngine.UI;

public class AchievementsMenu : KeyboardConfiguration
{
    [SerializeField]
    private AchievementManager _achievementManager;

    public override void Show()
    {
        gameObject.SetActive(true);
        _achievementManager.ShowAchievements();
    }
}
