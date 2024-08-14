using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    [SerializeField] private float jumpPower;
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    public void Jump()
    {
        if (CheckGround())
        {
            playerRigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);
        }
    }
    private bool CheckGround()
    {
        return false;
    }
}
