using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent (typeof(Animator))]
public class WeaponAnimation : MonoBehaviour
{
    [SerializeField] ParticleSystem shotParticles;
    private Weapon weapon;
    private Animator animator;
    private void Awake()
    {
        weapon = GetComponent<Weapon>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        weapon.OnFire += Weapon_OnFire;
    }

    private void Weapon_OnFire()
    {
        shotParticles.Play();
    }

    private void OnDestroy()
    {
        weapon.OnFire -= Weapon_OnFire;
    }
}
