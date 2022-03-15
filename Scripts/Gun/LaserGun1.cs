using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Laser_Gun")]
public class LaserGun1 : Weapon
{
    public LineRenderer lineRenderer;
    public int damage;
    public override void TriggerWeaponAbility()
    {
        Transform firePoint = PlayerShooting.Instance.weaponSlot.GetChild(0).Find("FirePoint");
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direct = mousePos - (Vector2)firePoint.position;
        RaycastHit2D[] raycastHitList2D = Physics2D.RaycastAll(firePoint.position, direct.normalized, direct.magnitude);
        Debug.DrawRay(firePoint.position, direct, Color.black, 0.5f);

        foreach(var hit in raycastHitList2D)
        {
            if(hit.collider != null && hit.transform.GetComponent<EnemyAbstract>() != null)
            {
                hit.transform.GetComponent<EnemyAbstract>().TakeDamage(damage);
            }
        }
    }

    public int CalculateDamage()
    {
        return damage;
    }
}
