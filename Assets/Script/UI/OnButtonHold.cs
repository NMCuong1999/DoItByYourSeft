using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPress {  get; private set; }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPress = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPress = false;
    }
}
