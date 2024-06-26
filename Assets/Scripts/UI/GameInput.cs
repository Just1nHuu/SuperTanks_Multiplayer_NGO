using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : NetworkBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerInputAction playerInputActions;
    private Vector2 movementInput;
    private Vector2 rotationInput;
    public event EventHandler OnPauseAction;
    public event EventHandler HaveMissileAction;
    public event EventHandler MoveAction;
    public event EventHandler RotationAction;
    public event EventHandler EnterAction;
    public event EventHandler SpaceAction;
    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputAction();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Pause.performed += Pause_performed;
        playerInputActions.Player.Enter.performed += Enter_performed;
        playerInputActions.Player.Space.performed += Space_performed;

    }


    private void OnDestroy()
    {

        playerInputActions.Player.Pause.performed -= Pause_performed;
        playerInputActions.Player.Enter.performed -= Enter_performed;
        playerInputActions.Player.Space.performed -= Space_performed;
        playerInputActions.Dispose();
    }
    private void Pause_performed(InputAction.CallbackContext context)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }
    
    private void Enter_performed(InputAction.CallbackContext context)
    {
        EnterAction?.Invoke(this, EventArgs.Empty);
    }
    
    private void Space_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Space");
        SpaceAction?.Invoke(this, EventArgs.Empty);
    }

    

    // Returns input values of 0, 1 or -1 based on whether Player tries to move forward or back
    public float GetMovementInput()
    {
        // Bind actions to methods
        playerInputActions.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        playerInputActions.Player.Move.canceled += ctx => movementInput = Vector2.zero;
        return movementInput.y;
    }

    // Returns input values of 0, 1 or -1 based on whether Player tries to rotate right or left
    public float GetRotationInput()
    {
        playerInputActions.Player.Rotate.performed += ctx => rotationInput = ctx.ReadValue<Vector2>();
        playerInputActions.Player.Rotate.canceled += ctx => rotationInput = Vector2.zero;
        return rotationInput.x;
    }
}

