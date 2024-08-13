using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectVisual : MonoBehaviour
{
    private void Start()
    {
        Hide();
    }
    public void HideOrShow(bool status)
    {
        if (status) 
        { 
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
}
