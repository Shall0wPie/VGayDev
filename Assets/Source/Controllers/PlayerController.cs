using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintMultiplier;
    [SerializeField] private float moveTrashold;

    private PlayerInput input;
    private CharacterController controller;
    private Animator animator;

    private Vector3 moveDirection;
    private float currentSpeed;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        currentSpeed = moveSpeed;
    }

    private void Update()
    {
        animator.SetFloat("Vertical", moveDirection.magnitude);
        animator.speed = currentSpeed;
        if (moveDirection.magnitude > moveTrashold)
        {
            //controller.Move(moveDirection * currentSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }

    /*void OnAnimatorMove()
    {
        Debug.Log(animator.deltaPosition);
        transform.position += animator.deltaPosition;
    }*/

    public void Vertical(InputAction.CallbackContext context)
    {
        moveDirection.z = context.ReadValue<float>();
    }

    public void Horizontal(InputAction.CallbackContext context)
    {
        moveDirection.x = context.ReadValue<float>();
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        switch (context.phase) 
        {
            case InputActionPhase.Started:
                currentSpeed = moveSpeed * sprintMultiplier;
                break;
            case InputActionPhase.Canceled:
                currentSpeed = moveSpeed;
                break;
        }
    }
}
