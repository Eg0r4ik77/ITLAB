using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class SoundButtonSpriteChanger : MonoBehaviour
{
    [SerializeField]
    private Sprite _soundOnSprite;

    [SerializeField]
    private Sprite _soundOffSprite;

    private Button _soundButton;
    private Image _soundButtonImage;

    private void Awake()
    {
        _soundButton = GetComponent<Button>();
        _soundButtonImage = GetComponent<Image>();

        _soundButtonImage.sprite = PlayerPrefs.GetInt("Muted", 0) == 0 ? _soundOnSprite : _soundOffSprite;
        _soundButton.onClick.AddListener(ChangeSoundMode);
    }

    private void ChangeSoundMode()
    {
        _soundButtonImage.sprite = _soundButtonImage.sprite == _soundOnSprite ? _soundOffSprite : _soundOnSprite;
    }
}
