using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesComposite : Composite
{
    [SerializeField] private EnemiesViewFactory enemiesViewFactory;
    [SerializeField] private int _limit;
    [SerializeField] private Area area;
    [SerializeField] private TankComposite tankComposite;
    private List<Enemy> enemies = new List<Enemy>();
    private List<Coroutine> timers = new List<Coroutine>();

    public override void Compose()
    {
        for (int i = 0; i < _limit; i++)
        {
            var timer = StartCoroutine(Timer(i * 5f, CreateRandomEnemy));
            timers.Add(timer);
        }
    }

    private IEnumerator Timer(float time, Action onEnd)
    {
        yield return new WaitForSeconds(time);
        onEnd?.Invoke();
    }

    private void CreateRandomEnemy()
    {
        var rand = UnityEngine.Random.Range (0, 2);
        Enemy enemy = null;
        var position = GetRandomPositionOutsideScreen();
        switch (rand)
        {
            case 0:
                enemy = new MonsterOrange(position, 0, tankComposite.Model);
                break;
            case 1:
                enemy = new MonsterRed(position, 0, tankComposite.Model);
                break;
        }
        enemiesViewFactory.Create(enemy);
        enemies.Add(enemy);
    }

    private Vector3 GetRandomPositionOutsideScreen()
    {
        var x = GetRandomValue(true);
        var y = GetRandomValue(x < -1 || x > 1);
        return new Vector3(x, 0, y) * area.size.x;
    }

    private float GetRandomValue(bool inside)
    {
        var positive = UnityEngine.Random.Range(0, 2) == 0;
        var output = UnityEngine.Random.Range(inside ? 0f: 1f, 1.25f) * (positive ? 1 : -1);
        return output;
    }
}
