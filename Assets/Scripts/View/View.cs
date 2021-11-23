using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class View<T> : MonoBehaviour where T : Model
{
    public T Model { get; private set; }

    public virtual void Init(T model)
    {
        Model = model;
    }

    public virtual void Update()
    {
        Model.Update(Time.deltaTime);
    }

    protected virtual void OnDisable() { }
}
