using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [HideInInspector] public Transform weaponSlot;
    public static PlayerShooting Instance;
    public Weapon weapon;
    private float timeCount = 0;
    private PlayerMovement playerMovement;
    

    private void Awake() 
    {
        Instance = this;
        playerMovement = GetComponent<PlayerMovement>();
        weapon = null;
    }

    private void Start() 
    {
        weaponSlot = transform.Find("WeaponSlot");    
    }
    
    public void ChangeWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        foreach(Transform i in weaponSlot)
        {
            Destroy(i.gameObject);
        }
        Instantiate(weapon.weaponPrefab, weaponSlot.position,Quaternion.identity, weaponSlot);
    }

    private void Update() 
    {
        if(Input.GetButtonDown("Fire1") && timeCount < 0 && weapon != null)
        {
            Shoot();
            timeCount = weapon.attackTime;
        }    
        timeCount -= Time.deltaTime;
    }

    private void Shoot()
    {
        if(transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
        {
            playerMovement.Flip(1);
        }
        else if(transform.position.x > Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
        {
            playerMovement.Flip(-1);
        }
        weapon.TriggerWeaponAbility();
    }
}
