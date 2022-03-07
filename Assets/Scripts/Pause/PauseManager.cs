using System;

public class PauseManager
{
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
    public void SetPaused(bool isPaused)
    {
        OnPaused.Invoke(isPaused);
    }
}
