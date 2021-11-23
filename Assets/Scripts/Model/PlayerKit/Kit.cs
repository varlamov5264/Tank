using System;

public class Kit : Model
{
    public Action<bool> onChangeActive;

    public void SetActive(bool active)
    {
        onChangeActive?.Invoke(active);
    }
}
