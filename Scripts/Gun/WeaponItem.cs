using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    public Weapon weapon;

    private void Update() 
    {
        if(CheckPlayerNearWeapon())
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                PlayerShooting.Instance.ChangeWeapon(weapon);
                Destroy(this.gameObject);
            }
        }
    }

    private bool CheckPlayerNearWeapon()
    {
        float distance = Vector2.Distance(PlayerStatus.Instance.transform.position, this.transform.position);
        if(distance < 0.5f)
        {
            //Debug.Log("near");
            return true;
        }
        else
        {
            //Debug.Log("not near");
        }
        return false;
    }
}
