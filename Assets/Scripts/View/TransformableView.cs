using UnityEngine;

public class TransformableView : MonoBehaviour
{
    public Transformable Model { get; private set; }

    public void Init(Transformable model)
    {
        Model = model;
    }

    public void Update()
    {
        Model.Update(Time.deltaTime);
        transform.position = Model.Position;
        transform.rotation = Model.GetQuaternion();
    }
}
