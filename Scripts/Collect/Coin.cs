using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D coinRb;
    [HideInInspector] public int reward;
    private void Awake() 
    {
        coinRb = GetComponent<Rigidbody2D>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            PlayerStatus.Instance.IncreaseCoin(reward);
            Debug.Log(PlayerStatus.Instance.getCoin());
        }    
    }
}
