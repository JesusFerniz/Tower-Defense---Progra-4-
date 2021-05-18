using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerStats", menuName = "Game/TowerStats", order = 1)]
public class TowerStats : ScriptableObject
{
    public Sprite sprite = default;
    public string towerName = "Tower";
    [TextArea]public string description = "";
    public float timeBetweenShoots = 0.5f;
    public float range = 5f;
    public int damage = 10;
    public ElementType type = ElementType.Terrestre;

    public GameObject towerPrefab = default;
    public GameObject bulletPrefab = default;
    public Evolution[] evolutions = default; 
}

[System.Serializable]
public struct Evolution
{
    public TowerStats stats;
    public int price;
}