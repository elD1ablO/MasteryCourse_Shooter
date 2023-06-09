using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;

    private void Update()
    {
        foreach (var weapon in weapons)
        {
            if (Input.GetKeyDown(weapon.WeaponHotkey))
            {
                SwitchToWeapon(weapon);
                break;
            }
        }
    }

    private void SwitchToWeapon(Weapon chosenWeapon)
    {
        foreach(var weapon in weapons)
        {
            weapon.gameObject.SetActive(weapon == chosenWeapon);
        }
    }
}
