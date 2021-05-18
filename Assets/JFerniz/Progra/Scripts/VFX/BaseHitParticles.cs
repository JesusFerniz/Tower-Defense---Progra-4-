using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHitParticles : MonoBehaviour
{
    [SerializeField] GameObject particlesPrefab = default;
    [SerializeField] Transform spawnOrigin = default;

    private PlayerBase playerBase;

    private void Awake() => playerBase = GetComponent<PlayerBase>();

    private void OnEnable() => playerBase.onDamage += SpawnParticles;

    private void OnDisable() => playerBase.onDamage -= SpawnParticles;

    private void SpawnParticles(int currentHP)
    {
        GameObject particles = Instantiate(particlesPrefab, transform.position, transform.rotation);
        Destroy(particles, 2f);
    }
}
