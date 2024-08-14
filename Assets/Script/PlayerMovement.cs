using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Vector2 moveDirection;
    [SerializeField] private float moveSpeed;
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void SetMoveDirection(Vector2 moveDirection)
    {
        this.moveDirection = moveDirection;
    }
    private void Move()
    {
        playerRigidbody.velocity = new Vector3(moveDirection.x * moveSpeed, playerRigidbody.velocity.y);
    }
}
