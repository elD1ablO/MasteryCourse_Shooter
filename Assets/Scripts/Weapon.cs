using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public event Action OnFire = delegate { };
    public KeyCode WeaponHotkey { get { return weaponHotkey; } }


    [SerializeField] private KeyCode weaponHotkey;
    [SerializeField] private float fireDelay = 0.25f;

    private float fireTimer;

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (CanShoot())
            {
                Shoot();
            }
        }
    }

    private bool CanShoot()
    {
        return fireTimer >= fireDelay;
    }
    private void Shoot()
    {

        fireTimer = 0;

        OnFire?.Invoke();
        Debug.Log("PEW PEW PEW from"+ gameObject.name);
    }
}
