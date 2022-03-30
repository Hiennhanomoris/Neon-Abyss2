using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Rigidbody2D boxRb;
    private void Awake() 
    {
        boxRb = GetComponent<Rigidbody2D>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player Bullet"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }        
    }
}
