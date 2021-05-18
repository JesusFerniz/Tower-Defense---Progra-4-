using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] LevelWaves level = default;
    [SerializeField] WayPointPath path = default;

    public Action onGameWin;

    private void Start() => StartCoroutine(CreateWavesCoroutine(level));

    private IEnumerator CreateWavesCoroutine(LevelWaves level)
    {
        for (int i = 0; i < level.waves.Length; i++)
        {
            //Crear una wave
            yield return StartCoroutine(SpawnWavesCoroutine(level.waves[i]));
            yield return new WaitForSeconds(level.waveDelay);
        }

        onGameWin?.Invoke();
    }

    private IEnumerator SpawnWavesCoroutine(Wave wave)
    {
        for (int i = 0; i < wave.enemies.Length; i++)
        {
            Spawn(wave.enemies[i]);
            yield return new WaitForSeconds(wave.spawnDelay);
        }
    }

    private void Spawn(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab, transform.position, transform.rotation);
        Movement movement = enemy.GetComponent<Movement>();
        movement.SetPath(path);
    }
}
