using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReward : MonoBehaviour
{
    [SerializeField] int goldAmount = 10;

    private Enemy enemy;

    private void Awake() => enemy = GetComponent<Enemy>();

    private void OnEnable() => enemy.onDead += RewardGold;

    private void OnDisable() => enemy.onDead -= RewardGold;

    private void RewardGold()
    {
        Inventory inventory = FindObjectOfType<Inventory>();
        inventory.AddGold(goldAmount);
    }
}
