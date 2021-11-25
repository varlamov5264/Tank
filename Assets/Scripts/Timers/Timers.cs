using System.Collections.Generic;

public class Timers
{
    public Timers(List<Timer> timers)
    {
        _timers = timers;
    }

    private List<Timer> _timers;

    public void AddTime(float deltaTime)
    {
        foreach (var timer in _timers)
        {
            timer.AddTime(deltaTime);
        }
        _timers = _timers.FindAll(x => !x.IsEnd);
    }

    public bool IsEnd()
    {
        return _timers.Count == 0;
    }
}
