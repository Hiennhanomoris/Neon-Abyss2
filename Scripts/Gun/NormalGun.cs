using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Normal_Gun")]

public class NormalGun : Weapon
{
    [SerializeField] private GameObject bullet;
    public float force;

    public override void TriggerWeaponAbility()
    {
        Transform firePoint = PlayerShooting.Instance.weaponSlot.GetChild(0).Find("FirePoint");
        GameObject bullets = Instantiate(bullet, firePoint.position, Quaternion.identity);

        bullets.GetComponent<NormalGunBullet>().damage = CalculateDamage();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direct = mousePos - (Vector2)firePoint.position;
        bullets.GetComponent<Rigidbody2D>().AddForce(direct.normalized * force, ForceMode2D.Impulse);
    }

    public int CalculateDamage()
    {
        return damage;
    }    
}
