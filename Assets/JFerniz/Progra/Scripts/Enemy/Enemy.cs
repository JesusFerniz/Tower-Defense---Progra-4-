using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] int startHP = 100;
    [SerializeField] int damage = 10;
    [SerializeField] ElementType type;
    [SerializeField] AudioClip clip = default;

    public event Action onDamageTaken;
    public event Action onDead;

    public ElementType Type { get { return type; }}

    private int currentHP;

    private void Start() => currentHP = startHP;

    public void Damage(int value)
    {
        currentHP -= value;
        onDamageTaken?.Invoke();

        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);

        //Instantiate(particulas);
        //AudioSource.Play("Auch.mp4");
        //Animator.SetTrigger("HitAnimation");

        if (currentHP <= 0)
        {
            onDead?.Invoke();
            Destroy(this.gameObject);
        }
    }

    public int GetDamagePoints()
    {
        return damage;
    }
}

public enum ElementType { Terrestre, Aereo }