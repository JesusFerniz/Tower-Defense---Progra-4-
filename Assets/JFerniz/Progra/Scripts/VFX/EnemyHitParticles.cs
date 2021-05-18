using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitParticles : MonoBehaviour
{
    [SerializeField] GameObject particlesPrefab = default;

    private Enemy enemy;

    private void Awake() => enemy = GetComponent<Enemy>();

    private void OnEnable() => enemy.onDamageTaken += SpawnParticles;

    private void OnDisable() => enemy.onDamageTaken -= SpawnParticles;

    private void SpawnParticles() => Instantiate(particlesPrefab, transform.position, transform.rotation);
}
