using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGunBullet : MonoBehaviour
{
    private Rigidbody2D bulletRb;
    [HideInInspector] public int damage;

    private void Awake() 
    {
        bulletRb = GetComponent<Rigidbody2D>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.GetComponent<EnemyAbstract>() != null)
            other.GetComponent<EnemyAbstract>().TakeDamage(damage);
    }
}
