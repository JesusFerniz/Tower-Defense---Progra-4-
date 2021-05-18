using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField] int startGold = 100;

    public event Action<int> onGoldChanged;

    public int Gold { get; private set; }

    private void Awake()
    {
        Gold = startGold;
        onGoldChanged?.Invoke(Gold);
    }

    public void AddGold(int amount)
    {
        Gold += amount;
        onGoldChanged?.Invoke(Gold);
    }

    public bool SpendGold(int amount)
    {
        if (HaveEnoughGold(amount))
        {
            Gold -= amount;
            onGoldChanged?.Invoke(Gold);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool HaveEnoughGold(int amount)
    {
        return Gold >= amount;
    }

    [ContextMenu("Add 100 Gold")]

    private void Add100Gold() => AddGold(100);
}
