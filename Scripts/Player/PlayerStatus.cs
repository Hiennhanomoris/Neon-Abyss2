using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour, IHealth
{
    public static PlayerStatus Instance;

    public PlayerSO playerStatus;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private Sprite halfHeart;

    public int getCurrentHealth()
    {
        return playerStatus.currentHealth;
    }

    public void setCurrentHealth(int amount)
    {
        playerStatus.currentHealth = amount;
    }

    public int getMaxHealth()
    {
        return playerStatus.maxHealth;
    }

    public int getMoveSpeed()
    {
        return playerStatus.moveSpeed;
    }

    public void setMoveSpeed(int amount)
    {
        playerStatus.moveSpeed = amount;
    }

    public int getJumpForce()
    {
        return playerStatus.jumpForce;
    }

    public void setJumpForce(int amount)
    {
        playerStatus.jumpForce = amount;
    }

    public int getCoin()
    {
        return playerStatus.coin;
    }

    public void setCoin(int amount)
    {
        playerStatus.coin = amount;
    }

    public int getCurrentJump()
    {
        return playerStatus.currentJump;
    }

    public void setCurrentJump(int amount)
    {
        playerStatus.currentJump = amount;
    }

    public int getExtraJump()
    {
        return playerStatus.extraJump;
    }

    public void setExtraJump(int amount)
    {
        playerStatus.extraJump = amount;
    }

    public int getDamage()
    {
        return playerStatus.damage;
    }

    public void setDamage(int amount)
    {
        playerStatus.damage = amount;
    }

    private void Awake() 
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }    
        Instance = this;

        playerStatus.coin = 0;
    }

    private void Start() 
    {
       //transform.SetParent  
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        var health = other.GetComponent<IHealth>();
        if(health != null)
        {
            health.TakeDamage(getDamage());
        }
    }

    public void TakeDamage(int amount)
    {
        //sound
        AudioManager.Instaince.Play("hurt");

        if(playerStatus.currentHealth <= amount)
        {
            Destroy(this.gameObject);
        }
        else
        {
            playerStatus.currentHealth -= amount;
            HeartPanelController.heartPanelController.ChangeHeart();
        }
    }

    public void IncreaseCoin(int amount)
    {
        playerStatus.coin += amount;
    }
}
