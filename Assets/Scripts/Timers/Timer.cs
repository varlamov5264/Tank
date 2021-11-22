using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public Timer(float time, Action onEnd)
    {
        this.time = time;
        this.onEnd = onEnd;
        currentTime = 0;
    }

    private float time;
    private Action onEnd;
    private float currentTime;

    public bool IsEnd => currentTime >= time;

    public void AddTime(float deltaTime)
    {
        currentTime += deltaTime;
        if (IsEnd)
            onEnd?.Invoke();
    }
}
