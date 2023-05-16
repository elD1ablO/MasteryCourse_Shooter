using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string SPEED = "Speed";

    [SerializeField] private float rotationSpeed = 30f;
    [SerializeField] private float  moveSpeed = 30;

    private Animator animator;
    private CharacterController characterController;
    

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        animator.SetFloat(SPEED, vertical);

        transform.Rotate(Vector3.up, horizontal * Time.deltaTime * rotationSpeed);

        characterController.SimpleMove(transform.forward * Time.deltaTime * moveSpeed * vertical);
    }
}
