using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamage : MonoBehaviour
{
    [SerializeField] private int increaseDamage;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            if(other.transform.GetChild(3).childCount != 0)
            {
                PlayerStatus.Instance.setDamage(PlayerStatus.Instance.getDamage() + 5);
                Destroy(this.gameObject);
            }
        }    
    }
}
