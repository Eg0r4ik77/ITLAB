using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    [SerializeField]
    private int _pointsCondition;

    [SerializeField]
    private Image _image;

    public int PointsCondition => _pointsCondition;
    public string Id => $"Achievement {_pointsCondition}";

    public bool IsReceived { get; private set; }

    private TMP_Text _conditionText;

    private void Awake()
    {
        _conditionText = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        _conditionText.SetText($"Get a score of {_pointsCondition} points");
    }

    public void SetReceived(bool isReceived)
    {
        IsReceived = isReceived;
        PlayerPrefs.SetInt(Id, Convert.ToInt32(isReceived));
    }

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
