using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isActive {  get; private set; }
    [SerializeField] private PlayerSelectVisual selectVisual;
    public static event EventHandler OnPlayerSpawn;
    private void Start()
    {
        isActive = false;
        OnPlayerSpawn?.Invoke(this, EventArgs.Empty);
        MoveController.instance.OnSwitchPlayer += MoveController_OnSwitchPlayer;
    }

    private void MoveController_OnSwitchPlayer(object sender, Player currentPlayer)
    {
        if (currentPlayer != null)
        {
            if (this.Equals(currentPlayer))
            {
                selectVisual.HideOrShow(true);
            }
            else
            {
                selectVisual.HideOrShow(false);
            }
        }
    }

    private void SetActive(bool status)
    {
        isActive = status;
        selectVisual.HideOrShow(status);
    }

    
}
