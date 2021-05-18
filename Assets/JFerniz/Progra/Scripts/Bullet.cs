using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    private TrailRenderer trail;
    private Transform target;
    private Rigidbody rb;
    private int damage;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        trail = GetComponentInChildren<TrailRenderer>();
    }

    // Update is called once per frame
    private void Start() => rb.velocity = transform.forward * speed;

    private void Update()
    {
        this.transform.LookAt(target);
        rb.velocity = transform.forward * speed;
    }

    public void Init(Transform target, int damage)
    {
        trail.Clear();
        this.target = target;
        this.damage = damage;
        StartCoroutine(LifeSpanCoroutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(damage);
                PoolManager.Instance.StoreBullet(this.gameObject);
            }
        }
    }

    private IEnumerator LifeSpanCoroutine()
    {
        yield return new WaitForSeconds(5f);

        if (this.gameObject.activeSelf)
            PoolManager.Instance.StoreBullet(this.gameObject);
    }
}
