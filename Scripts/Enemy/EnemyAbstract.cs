using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour, IHealth, Enable2Explode
{
    [SerializeField] private GameObject coinPrefab;
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public float moveSpeed;
    public float moveDistance;
    public int reward;
    protected Rigidbody2D enemyRb;

    public virtual void Start() 
    {
        enemyRb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if(amount >= currentHealth)
        {
            Destroy(this.gameObject);

            //sound
            AudioManager.Instaince.Play("enemyDestroy");

            // for(int i = 0; i < reward; i++)
            // {
                var coin = Instantiate(coinPrefab, this.transform.position, Quaternion.identity);
                coin.GetComponent<Coin>().reward = reward;
            // }
        }
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

    public void Explode()
    {
        Destroy(this.gameObject);
    }
}
