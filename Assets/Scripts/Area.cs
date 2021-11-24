using UnityEngine;

public class Area : MonoBehaviour
{
    public Vector2 size;

    public bool IsInArea(Transformable model)
    {
        return model.Position.x > -size.x / 2 &&
               model.Position.x < size.x / 2 &&
               model.Position.z > -size.y / 2 &&
               model.Position.z < size.y / 2;
    }

    public void ClampInArea(Transformable model)
    {
        model.Position.x = Mathf.Clamp(model.Position.x, -size.x / 2, size.x / 2);
        model.Position.z = Mathf.Clamp(model.Position.z, -size.y / 2, size.y / 2);
    }
}
