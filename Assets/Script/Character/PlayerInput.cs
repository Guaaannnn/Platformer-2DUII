using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement tPlayerMovement;
    private MainInputAction tMainInput;

    void Start()
    {
        tPlayerMovement = GetComponent<PlayerMovement>();

        tMainInput = new MainInputAction();
        tMainInput.Enable();
        tMainInput.Player.Enable();

        tMainInput.Player.Move.performed += OnMove;
        tMainInput.Player.Jump.performed += OnJump;
        tMainInput.Player.Attack.performed += OnAttacking;
    }

    private void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        float val = ctx.ReadValue<float>();

        Debug.Log(val);
        tPlayerMovement.SeXInput(val);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jumping");
        tPlayerMovement.ApplyJump();

    }

    private void OnAttacking(InputAction.CallbackContext context)
    {
        Debug.Log("Attacking");
        tPlayerMovement.ApplyAttacking();

    }

   

   
}
