using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab = default;

    Queue<GameObject> bulletPool;

    public static PoolManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        bulletPool = new Queue<GameObject>();
    }

    public GameObject RequestBullet(Vector3 position, Quaternion rotation)
    {
        if (bulletPool.Count == 0)
        {
            bulletPool.Enqueue(Instantiate(bulletPrefab));
        }

        GameObject bullet = bulletPool.Dequeue();
        bullet.transform.SetPositionAndRotation(position, rotation);
        bullet.SetActive(true);

        return bullet;
    }

    public void StoreBullet(GameObject bulletObject)
    {
        bulletObject.SetActive(false);
        bulletPool.Enqueue(bulletObject);
    }
}
