using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            damageDealer.Hit();
            TakeDamage(damageDealer.GetDamage());
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
            Destroy(gameObject);
    }
}
