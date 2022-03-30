using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Laser_Gun")]
public class LaserGun : Weapon
{
    [SerializeField] private float laserLenght;
    [SerializeField] private GameObject laserPrefabs;
    
    public override void TriggerWeaponAbility()
    {
        Transform firePoint = PlayerShooting.Instance.weaponSlot.GetChild(0).Find("FirePoint");
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direct = mousePos - (Vector2)firePoint.position;
        RaycastHit2D[] raycastHitList2D = Physics2D.RaycastAll(firePoint.position, direct.normalized, laserLenght);

        //Debug.DrawRay(firePoint.position, direct, Color.black, 0.5f);
        var lasers = Instantiate(laserPrefabs, firePoint.position, Quaternion.identity);
        var temp = lasers.GetComponent<Laser>();
        temp.firePoint = firePoint;
        temp.laserLenght = laserLenght;
        temp.mousePos = mousePos;


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
