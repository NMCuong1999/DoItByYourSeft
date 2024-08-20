using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isActive { get; private set; }
    [SerializeField] private PlayerSelectVisual selectVisual;
    private PlayerMovement playerMovement;
    private PlayerJump playerJump;
    private PlayerPickUp playerPickUp;
    public static event EventHandler OnPlayerSpawn;
    private Vector2 moveDirection;
    private void Start()
    {
        isActive = false;
        playerMovement = GetComponent<PlayerMovement>();
        playerJump = GetComponent<PlayerJump>();
        playerPickUp = GetComponent<PlayerPickUp>();
        OnPlayerSpawn?.Invoke(this, EventArgs.Empty);
        MoveController.instance.OnSwitchPlayer += MoveController_OnSwitchPlayer;
        MoveController.instance.OnPlayerMoveLeft += MoveController_OnPlayerMoveLeft;
        MoveController.instance.OnPlayerMoveRight += MoveController_OnPlayerMoveRight;
        MoveController.instance.OnPlayerStopMoving += MoveController_OnPlayerStopMoving;
        MoveController.instance.OnPlayerJump += MoveController_OnPlayerJump;
        MoveController.instance.OnPlayerPickUp += MoveController_OnPlayerPickUp;
    }

    private void MoveController_OnPlayerPickUp(object sender, EventArgs e)
    {
        if(isActive)
        {
            playerPickUp.PickUp();
        }
    }

    private void MoveController_OnPlayerJump(object sender, EventArgs e)
    {
        if(isActive)
        {
            playerJump.Jump();
        }
    }

    private void MoveController_OnPlayerStopMoving(object sender, EventArgs e)
    {
        if (isActive)
        {
            moveDirection = Vector2.zero;
        }
    }

    private void MoveController_OnPlayerMoveLeft(object sender, EventArgs e)
    {
        if(isActive)
        {
            moveDirection = Vector2.left;
        }
    }

    private void MoveController_OnPlayerMoveRight(object sender, EventArgs e)
    {
        if (isActive)
        {
            moveDirection = Vector2.right;
        }
    }

    private void MoveController_OnSwitchPlayer(object sender, Player currentPlayer)
    {
        if (currentPlayer != null)
        {
            if (this.Equals(currentPlayer))
            {
                SetActive(true);
                selectVisual.HideOrShow(true);
            }
            else
            {
                SetActive(false);
                selectVisual.HideOrShow(false);
            }
        }
    }

    private void SetActive(bool status)
    {
        isActive = status;
        selectVisual.HideOrShow(status);
    }

    private void Update()
    {
        if (!isActive)
        {
            moveDirection = Vector2.zero;
        }
        playerMovement.SetMoveDirection(moveDirection);
    }
}
