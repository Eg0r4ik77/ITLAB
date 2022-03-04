using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        PauseManager.Instance.OnPaused += SetPause;
    }

    private void OnDestroy()
    {
        PauseManager.Instance.OnPaused -= SetPause;
    }

    private void SetPause(bool isPaused)
    {
        gameObject.SetActive(isPaused);
    }
}
