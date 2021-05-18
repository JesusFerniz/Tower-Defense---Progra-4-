using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatusUI : MonoBehaviour
{
    [SerializeField] PlayerBase playerBase = default;
    [SerializeField] EnemySpawner enemySpawner = default;

    [SerializeField] GameObject gameWinUIMessage = default;
    [SerializeField] GameObject gameLoseUIMessage = default;

    private void OnEnable()
    {
        playerBase.onGameOver += ShowLoseMessage;
        enemySpawner.onGameWin += ShowWinMessage;
    }

    private void OnDisable()
    {
        playerBase.onGameOver -= ShowLoseMessage;
        enemySpawner.onGameWin -= ShowWinMessage;
    }

    private void ShowWinMessage()
    {
        gameWinUIMessage.SetActive(true);
    }

    private void ShowLoseMessage()
    {
        gameLoseUIMessage.SetActive(true);
    }
}
