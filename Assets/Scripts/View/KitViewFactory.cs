using UnityEngine;

public abstract class KitViewFactory<T> : MonoBehaviour where T: Kit
{
    public void Create(T model, Transform parent)
    {
        KitView view = Instantiate(GetTemplate(model), parent: parent);
        view.Init(model);
    }

    protected abstract KitView GetTemplate(T model);
}
