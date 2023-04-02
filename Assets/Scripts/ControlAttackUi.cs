using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlAttackUi : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool isAttackPressed = false;
    private float _time = 5;

    private void Update()
    {
        if(isAttackPressed)
        {
            _time -= Time.deltaTime;    
        }
        isAttackPressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(_time >= 5) 
        {
            isAttackPressed = true;
        }
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isAttackPressed = false;
        _time = 5;
    }
}
