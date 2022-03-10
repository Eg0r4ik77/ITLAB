using UnityEngine;

public class GameComplicator
{
    public int DifficultyLevel { get; set; } = 0;
    public readonly int[] _complicationPoints = { 20, 40, 60, 100, 120, 150, 170, 180, 200, 220, 250, 260, 270, 280, 300, 320, 350, 370, 400, 420, 450, 470, 500, 550, 600 };

    private readonly float _startPlayerSpeed;
    private readonly float _targetPlayerSpeed;

    private readonly float _startCarsAheadSpeed;
    private readonly float _targetCarsAheadSpeed;

    private readonly float _startCarsCooldownLeftBound;
    private readonly float _targetCarsCooldownLeftBound;

    private readonly float _startCarsCooldownRightBound;
    private readonly float _targetCarsCooldownRightBound;

    public GameComplicator(float startPlayerSpeed, float startCarsAheadSpeed, float startCarsCooldownLeftBound, float startCarsCooldownRightBound)
    {
        _startPlayerSpeed = startPlayerSpeed;
        _startCarsAheadSpeed = startCarsAheadSpeed;
        _startCarsCooldownLeftBound = startCarsCooldownLeftBound;
        _startCarsCooldownRightBound = startCarsCooldownRightBound;

        _targetPlayerSpeed = _startPlayerSpeed * 2;
        _targetCarsAheadSpeed = _startCarsAheadSpeed * 4;
        _targetCarsCooldownLeftBound = _startCarsCooldownLeftBound / 2;
        _targetCarsCooldownRightBound = _startCarsCooldownRightBound / 2;
    }

    public float GetComplicatedValue(float startValue, float targetValue)
    {
        return Mathf.Lerp(startValue, targetValue, (float)DifficultyLevel / _complicationPoints.Length);
    }

    public float GetComplicatedSpeed()
    {
        return GetComplicatedValue(_startPlayerSpeed, _targetPlayerSpeed);
    }

    public float GetComplicatedCarsAheadSpeed()
    {
        return GetComplicatedValue(_startCarsAheadSpeed, _targetCarsAheadSpeed);
    }

    public float GetComplicatedCarsCooldownLeftBound()
    {
        return GetComplicatedValue(_startCarsCooldownLeftBound, _targetCarsCooldownLeftBound);
    }

    public float GetComplicatedCarsCooldownRightBound()
    {
        return GetComplicatedValue(_startCarsCooldownRightBound, _targetCarsCooldownRightBound);
    }
}
