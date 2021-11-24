using System;

public class Kit : Model
{
    public Action<bool> onChangeActive;
    public bool IsActive { get; private set; }

    public void SetActive(bool active)
    {
        IsActive = active;
        onChangeActive?.Invoke(active);
    }
}