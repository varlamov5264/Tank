using System;
using UnityEngine;

public class EnemiesViewFactory : TransformableViewFactory<Enemy>
{
    [SerializeField] private TransformableView monsterRedPrefab;
    [SerializeField] private TransformableView monsterOrangePrefab;

    public override TransformableView Create(Enemy model)
    {
        var view = base.Create(model);
        if (view.TryGetComponent(out AnimationView animationView))
            animationView.Subscribe(model);
        return view;
    }

    protected override TransformableView GetTemplate(Enemy model)
    {
        if (model is MonsterRed)
            return monsterRedPrefab;
        else if (model is MonsterOrange)
            return monsterOrangePrefab;
        throw new NotImplementedException();
    }
}