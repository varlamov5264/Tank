using UnityEngine;

public class TransformableView : MonoBehaviour
{
    private Transformable _model;

    public void Init(Transformable model)
    {
        _model = model;
    }

    public void Update()
    {
        _model.Update(Time.deltaTime);
        transform.position = _model.Position;
        transform.rotation = _model.GetQuaternion();
    }
}
