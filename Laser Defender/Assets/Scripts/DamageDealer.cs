using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int Damage = 10;
    public int GetDamage()
    {
        return Damage;
    }
    public void Hit()
    {
        Destroy(gameObject);
    }
}
