using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Game/Waves/Wave", order = 1)]
public class Wave : ScriptableObject
{
    public GameObject[] enemies;
    public float spawnDelay;
}
