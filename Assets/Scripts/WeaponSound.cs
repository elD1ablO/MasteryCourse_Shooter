using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(AudioSource))]
public class WeaponSound : MonoBehaviour
{

    AudioSource audioSource;
    private Weapon weapon;
    private void Awake()
    {
        weapon = GetComponent<Weapon>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        weapon.OnFire += Weapon_OnFire;
    }

    private void Weapon_OnFire()
    {
        audioSource.Play();
    }

    private void OnDestroy()
    {
        weapon.OnFire -= Weapon_OnFire;
    }
}
