using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Laser_Gun")]
public class LaserGun : Weapon
{
    public LineRenderer lineRenderer;
    [SerializeField] private float laserLenght;
    
    public override void TriggerWeaponAbility()
    {
        Transform firePoint = PlayerShooting.Instance.weaponSlot.GetChild(0).Find("FirePoint");
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direct = mousePos - (Vector2)firePoint.position;
        RaycastHit2D[] raycastHitList2D = Physics2D.RaycastAll(firePoint.position, direct.normalized, direct.magnitude);

        //Debug.DrawRay(firePoint.position, direct, Color.black, 0.5f);
        DrawLine(firePoint, mousePos);

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

    public void DrawLine(Transform firePoint, Vector2 mousePos)
    {
        lineRenderer = PlayerShooting.Instance.weaponSlot.GetChild(0).GetChild(1).GetComponent<LineRenderer>();
        if(lineRenderer != null)
            Debug.Log("yes");
        //lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, CalculateGPos(firePoint, mousePos));
    }

    private Vector2 CalculateGPos(Transform firePoint, Vector2 mousePos)
    {
        float distance = Vector2.Distance(firePoint.position, mousePos);
        Vector2 temp = Vector2.zero;
        temp.x = (laserLenght/distance)*(mousePos.x - firePoint.position.x) + firePoint.position.x;
        temp.y = (laserLenght/distance)*(mousePos.y - firePoint.position.y) + firePoint.position.y;

        return temp;
    }
}
