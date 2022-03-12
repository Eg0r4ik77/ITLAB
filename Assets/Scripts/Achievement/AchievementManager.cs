using System;
using System.Threading.Tasks;
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
            achievement.SetReceived(Convert.ToBoolean(PlayerPrefs.GetInt(achievement.Id, 0)));
            SetReceivedSprite(achievement);
        }
    }

    public void UpdateAchievementsSprites(int score)
    {
        foreach (Achievement achievement in _achievements)
        {
            achievement.SetReceived(score >= achievement.PointsCondition);
            SetReceivedSprite(achievement);
        }
    }

    private void SetReceivedSprite(Achievement achievement)
    {
        Sprite sprite = achievement.IsReceived == true ? _unlockedSprite : _lockedSprite;
        achievement.SetSprite(sprite);
    }

    public async void ShowAchievements()
    {
        foreach(Achievement achievement in _achievements)
        {
            achievement.gameObject.SetActive(false);
        }

        foreach (Achievement achievement in _achievements)
        {
            achievement.Show();
            await Task.Delay(200);
        }

    }
}
