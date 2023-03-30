using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlAttackUi : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool isAttackPressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isAttackPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isAttackPressed = false;
    }
}
