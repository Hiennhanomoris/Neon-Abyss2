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
        var health = other.GetComponent<IHealth>();
        if(health != null && !other.CompareTag("Player"))
        {
            health.TakeDamage(damage);
            Destroy(this.gameObject);
        }   
    }
}
