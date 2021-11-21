using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransformableViewFactory<T> : MonoBehaviour where T: Transformable
{
    private Dictionary<Transformable, TransformableView> _views = new Dictionary<Transformable, TransformableView>();

    public void Create(T model)
    {
        TransformableView view = Instantiate(GetTemplate(model), model.Position, Quaternion.Euler(0, 0, model.Rotation));
        view.Init(model);
        _views.Add(model, view);
    }

    public void Destroy(T model)
    {
        TransformableView view = _views[model];
        _views.Remove(model);
        Destroy(view.gameObject);
    }

    protected abstract TransformableView GetTemplate(T model);
}
