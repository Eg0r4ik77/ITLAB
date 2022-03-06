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
    }

    private void Start()
    {
        _soundButton.onClick.AddListener(ChangeSprite);
    }

    public void ChangeSprite()
    {
        _soundButtonImage.sprite = _soundButtonImage.sprite == _soundOnSprite ? _soundOffSprite : _soundOnSprite;
    }
}
