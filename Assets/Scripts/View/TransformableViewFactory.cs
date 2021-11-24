using System.Collections.Generic;
using UnityEngine;

public abstract class TransformableViewFactory<T> : MonoBehaviour where T: Transformable
{
    private Dictionary<Model, TransformableView> _views = new Dictionary<Model, TransformableView>();

    public virtual TransformableView Create(T model)
    {
        TransformableView view = Instantiate(GetTemplate(model), model.Position, Quaternion.Euler(0, 0, model.Rotation));
        view.Init(model);
        _views.Add(model, view);
        model.onDestroy += Destroy;
        return view;
    }

    public void Destroy(Model model)
    {
        model.onDestroy -= Destroy;
        if (_views.ContainsKey(model))
        {
            TransformableView view = _views[model];
            _views.Remove(model);
            model = null;
            Destroy(view.gameObject);
        }
    }

    protected abstract TransformableView GetTemplate(T model);
}
