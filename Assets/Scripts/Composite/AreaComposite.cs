using UnityEngine;

public class AreaComposite : Composite
{
    [SerializeField] private TransformableView _areaPrefab;
    private Area _area;
    private TransformableView _transformableView;

    public Area Model => _area;

    public override void Compose()
    {
        _transformableView = Instantiate(_areaPrefab);
        _area = new Area(Vector3.zero, 0, new Vector2(30, 30));
        _transformableView.Init(_area);
    }
}