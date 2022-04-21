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

    private void rotateWeapon()
    {
        var direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - PlayerStatus.Instance.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
        this.transform.GetChild(3).GetChild(0).transform.rotation = rotation;
    }

    private void Shoot()
    {   
        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x < PlayerStatus.Instance.transform.position.x)
        {
            this.transform.GetChild(3).GetChild(0).transform.localScale = new Vector3(-1, -1, 0);
        }
        else 
        {
            this.transform.GetChild(3).GetChild(0).transform.localScale = new Vector3(1, 1, 0);
        }

        if(weapon != null)
        {
            rotateWeapon();
        }

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
