using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Bullet : MonoBehaviour
{
    private Rigidbody2D bulletRb;
    public int damage;

    private void Start() 
    {
        bulletRb = GetComponent<Rigidbody2D>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        var health = other.GetComponent<IHealth>();
        if(health != null && !other.CompareTag("Enemy"))
        {
            health.TakeDamage(damage);
            Destroy(this.gameObject);
        }      
    }
}
