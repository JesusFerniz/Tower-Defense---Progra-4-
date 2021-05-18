using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBase : MonoBehaviour, IDamageable
{

    [SerializeField] int startHP = 100;

    public event Action onGameOver;
    public event Action<int> onDamage;

    private int currentHP;

    private void Start() => currentHP = startHP;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            Damage(enemy.GetDamagePoints());

            Destroy(other.gameObject);
        }
    }

    public void Damage(int amount)
    {
        currentHP -= amount;
        onDamage?.Invoke(currentHP);

        if (currentHP < 0f)
        {
            onGameOver?.Invoke();
        }
    }
}
