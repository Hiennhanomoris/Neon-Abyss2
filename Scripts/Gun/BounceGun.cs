using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Bounce_Gun")]
public class BounceGun : Weapon
{
    [SerializeField] private GameObject bullet;
    public float force;

    public override void TriggerWeaponAbility()
    {
        Transform firePoint = PlayerShooting.Instance.weaponSlot.GetChild(0).Find("FirePoint");
        GameObject bullets = Instantiate(bullet, firePoint.position, Quaternion.identity);

        //sound
        AudioManager.Instaince.Play("bounceGun");

        bullets.GetComponent<BounceGunBullet>().damage = CalculateDamage();
        bullets.GetComponent<BounceGunBullet>().bulletForce = force;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direct = mousePos - (Vector2)firePoint.position;
        bullets.GetComponent<Rigidbody2D>().AddForce(direct.normalized * force, ForceMode2D.Impulse);
    }
}
