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

    private void OnDestroy()
    {
        Model.onChangeActive -= SetActive;
    }
}
