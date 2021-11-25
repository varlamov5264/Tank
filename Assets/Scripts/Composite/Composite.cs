using UnityEngine;

public abstract class Composite : MonoBehaviour
{
    public abstract void Compose();

    protected virtual void DestroyModel(Model model) { }
}
