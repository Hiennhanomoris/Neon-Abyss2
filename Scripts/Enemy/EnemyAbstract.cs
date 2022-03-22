using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour, IHealth
{
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public float moveSpeed;
    public float moveDistance;
    protected Rigidbody2D enemyRb;

    public virtual void Start() 
    {
        enemyRb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if(amount >= currentHealth)
            Destroy(this.gameObject);
        else
            currentHealth -= amount;
    }

    public virtual void OnTriggerEnter2D(Collider2D other) 
    {
        var health = other.GetComponent<IHealth>();
        if(health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
