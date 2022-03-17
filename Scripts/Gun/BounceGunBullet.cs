using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceGunBullet : MonoBehaviour
{
    private Rigidbody2D bounceRb;
    [SerializeField] private int timesBouncing;
    private int bouncing;
    [HideInInspector] public int damage;
    [HideInInspector] public float bulletForce;
    private void Start() 
    {
        bounceRb = GetComponent<Rigidbody2D>();
        bouncing = 0;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Map"))
        {
            if(bouncing >= timesBouncing)
            {
                Destroy(this.gameObject);
                bouncing = 0;
            }
            else 
            {
                var speed = bounceRb.velocity.magnitude;
                var direct = Vector3.Reflect(bounceRb.velocity.normalized, Vector3.up);

                bounceRb.velocity = direct * bulletForce;

                bouncing++;
            }
        }        
    }
}
