using UnityEngine;
using UnityEngine.UI;

public class KeyboardConfiguration : MonoBehaviour
{
    [SerializeField]
    private Button _backButton;

    private void Awake()
    {
        gameObject.SetActive(false);
        _backButton.onClick.AddListener(OnBackButtonClicked);
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public void OnBackButtonClicked()
    {
        gameObject.SetActive(false);
    }
}
