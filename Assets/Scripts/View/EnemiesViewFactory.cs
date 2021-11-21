using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesViewFactory : TransformableViewFactory<Enemy>
{
    [SerializeField] private TransformableView monsterRedPrefab;
    [SerializeField] private TransformableView monsterOrangePrefab;

    protected override TransformableView GetTemplate(Enemy model)
    {
        if (model is MonsterRed)
            return monsterRedPrefab;
        if (model is MonsterOrange)
            return monsterOrangePrefab;
        throw new NotImplementedException();
    }
}