public class TransformableView : View<Transformable>
{
    public override void Update()
    {
        base.Update();
        transform.position = Model.Position;
        transform.rotation = Model.GetQuaternion();
    }
}
