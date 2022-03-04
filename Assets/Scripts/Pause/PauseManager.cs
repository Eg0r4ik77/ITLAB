using System;

public class PauseManager
{
    private bool _isPaused;

    private static PauseManager _instance;
    public static PauseManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new PauseManager();
            }
            return _instance;
        }
    }

    public event Action<bool> OnPaused;
    public void TrySetPaused(bool isPaused)
    {
        if (_isPaused != isPaused)
        {
            SetPaused(isPaused);
        }
    }
    private void SetPaused(bool isPaused)
    {
        _isPaused = isPaused;
        OnPaused.Invoke(isPaused);
    }
}
