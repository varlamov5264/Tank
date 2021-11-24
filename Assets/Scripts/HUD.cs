using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text playerHPLabel;
    public Text enemyKillCounterLabel;
    public GameObject gameOverScreen;

    private const string _playerHp = "Player HP: {0}";
    private const string _enemyKillCount = "EnemyKillCount: {0}";
    private Tank _player;
    private EnemiesComposite _enemiesComposite;

    public void Subscribe(Tank player)
    {
        _player = player;
        OnPlayerDamage(_player.HP);
        _player.onDamage += OnPlayerDamage;
        _player.onDestroy += OnPlayerDead;
    }

    public void Subscribe(EnemiesComposite enemiesComposite)
    {
        _enemiesComposite = enemiesComposite;
        _enemiesComposite.onEnemyKill += OnEnemyKill;
        OnEnemyKill(0);
    }

    private void OnPlayerDamage(float hp)
    {
        playerHPLabel.text = string.Format(_playerHp, hp);
    }

    private void OnEnemyKill(int count)
    {
        enemyKillCounterLabel.text = string.Format(_enemyKillCount, count);
    }

    private void OnPlayerDead(Model model)
    {
        gameOverScreen.SetActive(true);
    }

    public void OnDisable()
    {
        _player.onDamage -= OnPlayerDamage;
        _enemiesComposite.onEnemyKill -= OnEnemyKill;
    }
}
