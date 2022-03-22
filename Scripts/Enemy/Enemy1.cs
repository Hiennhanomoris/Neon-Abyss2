using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyAbstract
{
    [SerializeField] private float xMin, xMax;
    private int dir = 1;
    private void FixedUpdate() 
    {
        Moving();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        var health = other.gameObject.GetComponent<IHealth>();
        if(health != null)
        {
            health.TakeDamage(damage);
        }
    }

    private void Moving()
    {
        if(transform.position.x < xMin)
        {
            dir *= -1;
            FlipToRight();
        }
        if(transform.position.x > xMax)
        {
            dir *= -1;
            FlipToLeft();
        }
        enemyRb.velocity = new Vector2(moveSpeed * dir, enemyRb.velocity.y);
    }

    private void FlipToLeft()
    {
        Vector3 temp = transform.localScale;
        temp.x = -1.5f;
        transform.localScale = temp;
    }
    private void FlipToRight()
    {
        Vector3 temp = transform.localScale;
        temp.x = 1.5f;
        transform.localScale = temp;
    }
}
