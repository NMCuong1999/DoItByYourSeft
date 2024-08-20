using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    [SerializeField] private float jumpPower;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask layerMask;
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
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, layerMask);
        if (raycastHit2D.collider == null)
        {
            return false;
        }
        return true;
    }
}
