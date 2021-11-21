using UnityEngine;

public class TransformableView : MonoBehaviour
{
    private Transformable _model;

    public void Init(Transformable model)
    {
        _model = model;
    }

    public void LateUpdate()
    {
        _model.Update();
        transform.position = _model.Position;
        transform.rotation = Quaternion.Euler(0, _model.Rotation, 0);
    }
}
