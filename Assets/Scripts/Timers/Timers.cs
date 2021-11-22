using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Timers
{
    public Timers(List<Timer> timers)
    {
        this.timers = timers;
    }

    private List<Timer> timers;

    public void AddTime(float deltaTime)
    {
        foreach (var timer in timers)
        {
            timer.AddTime(deltaTime);
        }
        timers = timers.FindAll(x => !x.IsEnd);
    }

    public bool IsEnd()
    {
        return timers.Count == 0;
    }
}
