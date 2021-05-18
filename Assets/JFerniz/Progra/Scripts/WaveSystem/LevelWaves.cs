using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Game/Waves/Level", order = 1)]
public class LevelWaves : ScriptableObject
{
    public Wave[] waves;
    public float waveDelay;
}
