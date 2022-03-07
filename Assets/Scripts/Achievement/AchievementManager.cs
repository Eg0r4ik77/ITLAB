using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField]
    private Sprite _lockedSprite;

    [SerializeField]
    private Sprite _unlockedSprite;

    [SerializeField]
    private Achievement[] _achievements;
    public void SetInitialAchievements()
    {
        foreach (Achievement achievement in _achievements)
        {
            achievement.SetReceived(false);
        }
        UpdateAchievementsSprites();
    }

    public void UpdateAchievementsSprites()
    {
        foreach (Achievement achievement in _achievements)
        {
            Sprite sprite = achievement.IsReceived == true ? _unlockedSprite : _lockedSprite;
            achievement.SetSprite(sprite);
        }
    }
}
