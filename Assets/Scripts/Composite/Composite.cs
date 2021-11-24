using UnityEngine;

public abstract class Composite : MonoBehaviour
{
    public abstract void Compose();

    protected abstract void DestroyModel(Model model);
}
