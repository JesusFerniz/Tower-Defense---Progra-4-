using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float secondsToExplode = 2f;
    [SerializeField] TowerStats stats = default;

    private void Start() => StartCoroutine(ExplodeCoroutine());

    private IEnumerator ExplodeCoroutine()
    {
        yield return new WaitForSeconds(secondsToExplode);
        Explode();
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, stats.range);

        for (int i = 0; i < colliders.Length; i++)
        {
            IDamageable damageable = colliders[i].GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(stats.damage);
            }
        }

        Destroy(this.gameObject);
    }
}
