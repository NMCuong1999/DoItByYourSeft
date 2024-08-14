using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveController : MonoBehaviour
{
    [SerializeField] private Button switchPlayerBtn;
    [SerializeField] private Button playerJumpBtn;
    [SerializeField] private OnButtonHold movePlayerLeftBtn;
    [SerializeField] private OnButtonHold movePlayerRightBtn;
    public static MoveController instance;
    [SerializeField] private List<Player> listPlayer;
    private Player currentPlayer;
    private int currentPlayerIndex;
    public event EventHandler<Player> OnSwitchPlayer;
    public event EventHandler OnPlayerMoveLeft;
    public event EventHandler OnPlayerMoveRight;
    public event EventHandler OnPlayerStopMoving;
    public event EventHandler OnPlayerJump;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        List<Player> list = new List<Player>();
        Player.OnPlayerSpawn += Player_OnPlayerSpawn;
        switchPlayerBtn.onClick.AddListener(() =>
        {
            switchPlayer();
            OnSwitchPlayer?.Invoke(this, currentPlayer);
        });
        playerJumpBtn.onClick.AddListener(() =>
        {
            OnPlayerJump?.Invoke(this, EventArgs.Empty);
        });
    }
    private void Update()
    {
        if(movePlayerLeftBtn.isPress)
        {
            OnPlayerMoveLeft?.Invoke(this, EventArgs.Empty);
        }
        else if(movePlayerRightBtn.isPress)
        {
            OnPlayerMoveRight?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            OnPlayerStopMoving?.Invoke(this, EventArgs.Empty);
        }
    }
    private void Player_OnPlayerSpawn(object sender, EventArgs e)
    {
        listPlayer.Add(sender as Player);
    }

    private void LoadLevel()
    {
        listPlayer.Clear();
        currentPlayer = null;
    }
    private void switchPlayer()
    {
        if (currentPlayer != null)
        {
            currentPlayerIndex++;
            if(currentPlayerIndex >= listPlayer.Count)
            {
                currentPlayerIndex = 0;
            }
            currentPlayer = listPlayer[currentPlayerIndex];
        }
        else
        {
            currentPlayerIndex = 0;
            currentPlayer = listPlayer[currentPlayerIndex];
        }
    }
}
