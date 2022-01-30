using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [HideInInspector] public PlayerControls playerControls;

    public Action OnJump;

    private new void Awake()
    {
        base.Awake();

        playerControls = new PlayerControls();
        playerControls.Player.Jump.performed += (context) => OnJump?.Invoke();

        playerControls.Enable();
    }
}
