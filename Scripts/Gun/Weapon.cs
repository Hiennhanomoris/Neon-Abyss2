using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Weapon : ScriptableObject
{
    public string weaponName;
    public GameObject weaponPrefab;
    public float attackTime;

    public abstract void TriggerWeaponAbility();
}
