using System;

public class Timer
{
    public Timer(float time, Action onEnd)
    {
        _time = time;
        _onEnd = onEnd;
        _currentTime = 0;
    }

    private float _time;
    private Action _onEnd;
    private float _currentTime;

    public bool IsEnd => _currentTime >= _time;

    public void AddTime(float deltaTime)
    {
        _currentTime += deltaTime;
        if (IsEnd)
            _onEnd?.Invoke();
    }
}
