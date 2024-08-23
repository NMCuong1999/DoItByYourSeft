using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] private Transform pickUpPoint;
    [SerializeField] private float throwPower;
    private bool isReadyPickUp;
    private GameObject objPickUp;
    private float pickOffSet;
    private Player player;
    private void Start()
    {
        isReadyPickUp = false;
        player = GetComponent<Player>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6 && pickUpPoint.childCount == 0)
        {
            isReadyPickUp = true;
            objPickUp = collision.gameObject;
        }
    }
    public void OnCollisionExit2D (Collision2D collision)
    {
        if (collision.gameObject.layer == 6 && pickUpPoint.childCount == 0)
        {
            isReadyPickUp = false;
            objPickUp = null;
        }
    }
    public void PickUp()
    {
        if (pickUpPoint.childCount == 0)
        {
            if (isReadyPickUp)
            {
                //pick something
                objPickUp.transform.SetParent(pickUpPoint, false);
                objPickUp.transform.localPosition = new Vector3(0, objPickUp.GetComponent<BoxCollider2D>().size.y / 2, 0);
                objPickUp.GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }
        else
        {
            //drow obj
            objPickUp.transform.SetParent(null);
            objPickUp.GetComponent<Rigidbody2D>().isKinematic = false;
            Vector2 throwDirection = player.faceDirection;
            Debug.Log(player.faceDirection);
            objPickUp.GetComponent<Rigidbody2D>().AddForce(throwDirection * throwPower, ForceMode2D.Impulse);
            objPickUp = null;
        }
    }
}
