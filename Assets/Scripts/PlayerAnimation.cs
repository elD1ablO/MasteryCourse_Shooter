using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private float drawWeaponSpeed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(FadeToShootingLayer());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(FadeFromShootingLayer());
        }
    }

    private IEnumerator FadeToShootingLayer()
    {
        float currentWeight = animator.GetLayerWeight(1);
        float elasped = 0;

        while(elasped < currentWeight)
        {
            elasped += Time.deltaTime;
            currentWeight += Time.deltaTime / drawWeaponSpeed;
            animator.SetLayerWeight(1, currentWeight);
            yield return null;
        }
        animator.SetLayerWeight(1, 1);
    }

    private IEnumerator FadeFromShootingLayer()
    {
        float currentWeight = animator.GetLayerWeight(1);
        float elasped = 0;

        while (elasped < currentWeight)
        {
            elasped += Time.deltaTime;
            currentWeight -= Time.deltaTime / drawWeaponSpeed;
            animator.SetLayerWeight(1, currentWeight);
            yield return null;
        }
        animator.SetLayerWeight(1, 0);
    }

}
