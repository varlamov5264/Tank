using System;

public class Model
{
    public Action<Model> onDestroy;

    public virtual void Update(float deltaTime) { }
    public virtual void FixedUpdate(float deltaTime) { }
    public virtual void OnDisable() { }
}
