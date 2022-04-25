using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Weapon : ScriptableObject
{
    public string weaponName;
    public GameObject weaponPrefab;
    public float attackTime;
    public int damage;
    public int extraDamage;

    public abstract void TriggerWeaponAbility();
    public int CalculateDamage()
    {
        return damage + PlayerStatus.Instance.getDamage();
    }
}
