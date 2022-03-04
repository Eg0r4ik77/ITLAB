using UnityEngine;

public class GameSpaceManager : MonoBehaviour
{
    private GameSpace _currentSpace;

    public delegate void GameSpaceChanged(GameSpace gameSpace);
    public event GameSpaceChanged OnGameSpaceChanged;

    public GameSpaceManager()
    {
        _currentSpace = GameSpace.Space3D;
    }

    public void TryChangeSpace(GameSpace targetSpace)
    {
        if(_currentSpace != targetSpace)
        {
            SetSpace(targetSpace);
        }
    }

    private void SetSpace(GameSpace gameSpace)
    {
        _currentSpace = gameSpace;
        OnGameSpaceChanged?.Invoke(gameSpace);
    }
}
