using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator = default;
    [SerializeField] Enemy enemy = default;

    private void OnEnable()
    {
        enemy.onDamageTaken += OnHit;   
    }

    private void OnDisable()
    {
        enemy.onDamageTaken -= OnHit;
    }

    private void OnHit()
    {
        animator.SetTrigger("Hit");
    }
}
