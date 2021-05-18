using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IDamageable
{
    [SerializeField] Transform head = default;
    [SerializeField] Transform bulletOrigin = default;

    [SerializeField] TowerStats stats = default;

    public TowerStats Stats { get { return stats; } }

    //[SerializeField] GameObject bulletPrefab = default;

    //[SerializeField] float timeBetweenShoots = 0.5f;
    //[SerializeField] float range = 5f;

    //[SerializeField] ElementType type = default;

    //[SerializeField] TowerStats stats = default;

    private float timeOfLastShoot;

    private void Update()
    {
        //Rotacion
        Enemy target = FindTarget();

        if (target != null)
        {
            head.LookAt(target.transform);
            Shoot(target);
        }

    }

    private void Shoot(Enemy target)
    {
        //Disparar
        if (Time.time > timeOfLastShoot + stats.timeBetweenShoots)
        {
            //GameObject bullet = Instantiate(stats.bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);

            GameObject bullet = PoolManager.Instance.RequestBullet(bulletOrigin.position, bulletOrigin.rotation);
            bullet.GetComponent<Bullet>().Init(target.transform, stats.damage);
            timeOfLastShoot = Time.time;

            //Instantiate(stats.bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
            //timeOfLastShoot = Time.time;
        }
    }

    private Enemy FindTarget()
    {
        //Buscar al enemigo mas cercano
        //Que sea del tipo que puede atacar esta torreta //if(type.equals(enemytype.terrestre))
        //Que este en la distancia disponible para la torre

        Enemy target = null;
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        float shortestDistance = 9999f;

        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy enemy = enemies[i];

            if (enemy.Type.Equals(stats.type))
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);

                if (distance < stats.range)
                {
                    if (distance < shortestDistance)
                    {
                        shortestDistance = distance;
                        target = enemy;
                    }
                }
            }
        }
        return target;
    }

    private void OnMouseDown()
    {
        FindObjectOfType<Shop>().OpenEvolutionShop(this.gameObject, stats);
        //SelectedEffect(1f);
    }

    //private void OnMouseUp()
    //{
    //    SelectedEffect(0f);
    //}

    //private void SelectedEffect(float amount)
    //{
    //    Render[] renderers = GetComponentInChildren<Renderer>();

    //    for (int i = 0; i < renderers.Length; i++)
    //    {
    //        Material[] materials = renderers[i].materials;

    //        for (int j = 0; j < materials.Length; j++)
    //        {
    //            materials[j].SetFloat("_FresnelIntensity", amount);
    //        }
    //    }
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stats.range);
    }

    public void Damage(int amount) => Destroy(this.gameObject);
}
