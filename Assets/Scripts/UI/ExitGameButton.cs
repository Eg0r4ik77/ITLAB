using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitGameButton : MonoBehaviour
{
    private Button _button;

    public static event UnityAction OnExitButtonClicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
         _button.onClick.AddListener(OnExitButtonClicked);
    }
}
