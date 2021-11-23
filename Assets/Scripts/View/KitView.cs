using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitView : View<Kit>
{
    public override void Init(Kit model)
    {
        base.Init(model);
        model.onChangeActive += SetActive;
    }

    private void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        Model.onChangeActive -= SetActive;
    }
}
