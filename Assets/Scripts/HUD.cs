using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text playerHPLabel;
    public GameObject gameOverScreen;

    private const string playerHp = "Player HP: {0}";
    private Tank _player;

    public void Subscribe(Tank player)
    {
        _player = player;
        OnPlayerDamage(_player.HP);
        _player.onDamage += OnPlayerDamage;
        _player.onDestroy += OnPlayerDead;
    }

    public void OnPlayerDamage(float hp)
    {
        playerHPLabel.text = string.Format(playerHp, hp);
    }

    public void OnPlayerDead(Model model)
    {
        gameOverScreen.SetActive(true);
    }

    public void OnDisable()
    {
        _player.onDamage -= OnPlayerDamage;
    }
}
