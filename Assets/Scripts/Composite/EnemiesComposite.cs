using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesComposite : Composite
{
    [SerializeField] private EnemiesViewFactory enemiesViewFactory;
    [SerializeField] private int _limit;
    [SerializeField] private float _spawnInterval = 5f;
    [SerializeField] private Area _area;
    [SerializeField] private TankComposite tankComposite;
    private List<Enemy> enemies = new List<Enemy>();
    private Timers timers;

    public override void Compose()
    {
        List<Timer> timersList = new List<Timer>();
        for (int i = 0; i < _limit; i++)
        {
            var timer = new Timer(i * _spawnInterval, CreateRandomEnemy);
            timersList.Add(timer);
        }
        timers = new Timers(timersList);
    }

    public void Update()
    {
        if (timers != null)
        {
            timers.AddTime(Time.deltaTime);
            if (timers.IsEnd())
                timers = null;
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
                enemy = new MonsterOrange(position, 0, _area, tankComposite.Model);
                break;
            case 1:
                enemy = new MonsterRed(position, 0, _area, tankComposite.Model);
                break;
        }
        enemy.onDead += DeadEnemy;
        enemiesViewFactory.Create(enemy);
        enemies.Add(enemy);
    }

    private void DeadEnemy(Transformable enemy)
    {
        enemiesViewFactory.Destroy(enemy);
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
