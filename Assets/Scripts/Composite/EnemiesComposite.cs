using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesComposite : Composite
{

    public Action<int> onEnemyKill;

    [SerializeField] private EnemiesViewFactory _enemiesViewFactory;
    [SerializeField] private int _limit;
    [SerializeField] private float _spawnInterval = 5f;
    [SerializeField] private Area _area;
    [SerializeField] private TankComposite _tankComposite;
    [SerializeField] private HUD _hud;
    private List<Model> _enemies = new List<Model>();
    private Timers _timers;
    private int _killCount;

    public override void Compose()
    {
        List<Timer> timersList = new List<Timer>();
        for (int i = 0; i < _limit; i++)
        {
            var timer = new Timer(i * _spawnInterval, CreateRandomEnemy);
            timersList.Add(timer);
        }
        _timers = new Timers(timersList);
        _hud.Subscribe(this);
    }

    public void Update()
    {
        if (_timers != null)
        {
            _timers.AddTime(Time.deltaTime);
            if (_timers.IsEnd())
                _timers = null;
        }
    }

    private void CreateRandomEnemy()
    {
        var rand = UnityEngine.Random.Range (0, 2);
        Enemy enemy = null;
        var position = GetRandomPositionOutsideArea();
        switch (rand)
        {
            case 0:
                enemy = new MonsterOrange(position, 0, _area, _tankComposite.Model);
                break;
            case 1:
                enemy = new MonsterRed(position, 0, _area, _tankComposite.Model);
                break;
        }
        enemy.onDestroy += DestroyModel;
        _enemiesViewFactory.Create(enemy);
        _enemies.Add(enemy);
    }

    protected override void DestroyModel(Model model)
    {
        _enemies.Remove(model);
        _enemiesViewFactory.Destroy(model);
        CreateRandomEnemy();
        onEnemyKill?.Invoke(++_killCount);
    }

    private Vector3 GetRandomPositionOutsideArea()
    {
        var x = GetRandomValue(true);
        var y = GetRandomValue(x < -1 || x > 1);
        return new Vector3(x, 0, y) * _area.size.x;
    }

    private float GetRandomValue(bool inside)
    {
        var positive = UnityEngine.Random.Range(0, 2) == 0;
        var output = UnityEngine.Random.Range(inside ? 0f: 1f, 1.25f) * (positive ? 1 : -1);
        return output;
    }
}
