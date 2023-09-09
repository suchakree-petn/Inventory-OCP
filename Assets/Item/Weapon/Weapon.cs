using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public ElementalType elementalType;
    public float fireDelay;
    virtual public void Attack(GameObject attacker) { Debug.Log("Performed: Attack"); }
    virtual public void HoldAttack(GameObject attacker) { Debug.Log("Performed: HoldAttack"); }
    private void Awake()
    {
        _itemType = ItemType.Weapon;

    }
}
