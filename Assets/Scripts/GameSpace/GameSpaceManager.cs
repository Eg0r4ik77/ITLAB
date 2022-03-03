using UnityEngine;

public class GameSpaceManager : MonoBehaviour
{
    private GameSpace _currentSpace;

    public delegate void GameSpaceHandler(GameSpace gameSpace);
    public event GameSpaceHandler GameSpaceChanged;

    public GameSpaceManager()
    {
        _currentSpace = GameSpace.Space3D;
    }

    private void SetSpace(GameSpace gameSpace)
    {
        _currentSpace = gameSpace;
        GameSpaceChanged?.Invoke(gameSpace);
    }

    public void TryChangeSpace(GameSpace targetSpace)
    {
        if(_currentSpace != targetSpace)
        {
            SetSpace(targetSpace);
        }
    }
}
