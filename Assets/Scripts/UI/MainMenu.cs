using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _bestScoreText;

    private void Awake()
    {
        _bestScoreText.SetText($"Best score\n{PlayerPrefs.GetInt("BestScore")}");
    }
}
